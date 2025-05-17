using Microsoft.AspNetCore.Mvc;

public class WeatherAPIController : Controller {
    [HttpGet]
    public IActionResult GetWeatherActionMethod(string zipCode) {
        //later will call the getweatherAPI service


        //placeholder return so we don't have errors in the code appearing
        ViewData["zipCode"] = zipCode;
        return View("ReturnedWeatherData");
    }
}