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
    public async Task<IActionResult> DisplayWeather(string zipCode)
    {
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

        ViewData["temperature"] = weatherInfo.current.temp;
        ViewData["conditions"] = weatherInfo.current.weather[0].main;
        ViewData["location"] = location.name;

        return View("ReturnedWeatherData");

    }



}