using Microsoft.AspNetCore.Mvc;
using System;

public class WeatherController : Controller
{
    public bool isValidZip(string zip)
    {
        return zip.All(char.IsDigit) && string.IsNullOrWhiteSpace(zip) && zip.Length == 5;
    }

    //so basically we need a method to return the first view of the application through this weatherAPI controller
    [HttpGet]
    public IActionResult EnterZipPage()
    {
        return View();
    }

    [HttpGet]
    public IActionResult DisplayWeather(string zipCode)
    {
        if (isValidZip(zipCode))
        {
            ViewData["zipCode"] = zipCode;

            //this is where the method will go for requesting the API
            return View("ReturnedWeatherData");
        }
        else
        {
            ViewData["zipCode"] = null;
            return View("ZipError");
        }

    }



}