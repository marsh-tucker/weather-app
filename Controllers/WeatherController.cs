using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

public class WeatherController : Controller
{

    //creating a private readonly variable for the IWeatherAPIService
    private readonly WeatherAPIService _weatherService;
    public WeatherController(WeatherAPIService weatherService)
    {
        _weatherService = weatherService;
    }
    public bool isValidZip(string zip)
    {
        return zip.All(char.IsDigit) && !(string.IsNullOrWhiteSpace(zip)) && (zip.Length == 5);
    }

    //so basically we need a method to return the first view of the application through this weatherAPI controller
    [HttpGet]
    public IActionResult EnterZipPage()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> DisplayWeather(string zipCode, string unit)
    {
        Console.WriteLine($"Unit: {unit}");
        //checking if zip code is valid before requesting API services
        if (!isValidZip(zipCode))
        {
            ViewData["zipCode"] = null;
            return View("ZipError");
        }

        ViewData["zipCode"] = zipCode;

        //now lets get the coordiantes and then input that into the actual weather API but were going to use a while loop to control

        GeoResponseModel location = await _weatherService.GetLocationByZipAsync(zipCode);
        WeatherResponseModel weatherInfo;

        Console.WriteLine("Getting weather info...");

        if (location == null) {
            throw new Exception("Error retrieving location data");
        }
        else
        {
        weatherInfo = await _weatherService.GetWeatherInformationAsync(location.lat, location.lon);
        }

        //creating int varibales for each unit, im going to convert the current temp (double) and then use Convert.ToInt32() to get a cleaner number with no decimals
        int currentTempFahrenheightInt;
        int currentTempCelciusInt;
        int currentTempKelvinInt;
        double currentTemp = weatherInfo.current.temp;

        switch (unit)
        {
            case "fahrenheight":
                Console.WriteLine("Converting to farhenheight");
                //converting current kelvin temp to fahrenheight using double to get an accurate caluclation before cutting off the decimal to get an int
                double convertToF = (1.8 * (currentTemp - 273.15)) + 32;
                currentTempFahrenheightInt = Convert.ToInt32(convertToF);
                ViewData["temperature"] = currentTempFahrenheightInt;
                ViewData["unitSymbol"] = "°F";
                break;
            case "celcius":
                Console.WriteLine("Converting to celcius");
                //converting current temp from kelvint to celcius using double to get an accurate calculation before cuting off the decimal when we cobvert to int
                double convertToC = currentTemp - 273.15;
                currentTempCelciusInt = Convert.ToInt32(convertToC);
                ViewData["temperature"] = currentTempCelciusInt;
                ViewData["unitSymbol"] = "°C";
                break;
            case "kelvin":
                Console.WriteLine("Converting to kelvin");
                currentTempKelvinInt = Convert.ToInt32(currentTemp);
                ViewData["temperature"] = currentTempKelvinInt;
                ViewData["unitSymbol"] = "°K";
                break;
            default:
                currentTempKelvinInt = Convert.ToInt32(currentTemp);
                ViewData["temperature"] = currentTempKelvinInt;
                ViewData["unitSymbol"] = "°K";
                break;

        }

        ViewData["conditions"] = weatherInfo.current.weather[0].main;
        ViewData["location"] = location.name;

        return View("ReturnedWeatherData");

    }



}