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

    //action method to display the first page and set a default timezone
    public IActionResult EnterZipPage()
    {
        //pre set the time zone on the home page using the system time
        string systemTimeZoneID = TimeZoneInfo.Local.Id;
        ViewData["timezone"] = systemTimeZoneID;

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
    //setting string condiitons beforehand to use in the switch statement for the emoji
        string conditions = weatherInfo.current.weather[0].main;

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

        //getting time zone and the offset as a string
        string timeZone = weatherInfo.timezone;
        int offsetInSeconds = weatherInfo.timezone_offset;    

        //getting time zone thats accurate to the users time zone
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById($"{timeZone}");
        DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
        int localHour = localTime.Hour;

        //sending retrieved time zone to frontend
        ViewData["timezone"] = timeZone;

        //switch statetment to dymanically change conditions emoji
        switch (conditions.ToLower())
        {
            case "clouds":
                //setting the dynamic emoji 
                ViewData["conditionsIcon"] = "☁️";
                break;
            case "clear":
            case "sunny":
                if (localHour < 6 || localHour > 17)
                {
                    ViewData["conditionsIcon"] = "🌛";
                }
                else
                {
                    ViewData["conditionsIcon"] = "🌞";
                }
                break;

            case "rain":
                ViewData["conditionsIcon"] = "🌧️";
                break;
            case "thunderstorm":
                ViewData["conditionsIcon"] = "⛈️";
                break;
            case "snow":
                ViewData["conditionsIcon"] = "🌨️";
                break;
            case "fog":
            case "mist":
            case "haze":
                ViewData["conditionsIcon"] = "🌫️";
                break;
            case "drizzle":
                ViewData["conditionsIcon"] = "🌦️";
                break;
            default:
                ViewData["conditionsIcon"] = "🌡️";
                break;

        }

        ViewData["conditions"] = weatherInfo.current.weather[0].main;
        ViewData["location"] = location.name;

        return View("ReturnedWeatherData");

    }



}