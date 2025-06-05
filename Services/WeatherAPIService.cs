using System.Text;
using System.Text.Json;

public class WeatherAPIService : IWeatherAPIService
{
    private readonly string apiKey = "5b2ba97a20af72d8eb71597ee008587d";

    //creates a private variable of httpClient that the class can access
    private readonly HttpClient _httpClient;

    // HttpClient is injected via .NET's dependency injection system.
    public WeatherAPIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<GeoResponseModel> GetLocationByZipAsync(string zip)
{
    var response = await _httpClient.GetAsync($"http://api.openweathermap.org/geo/1.0/zip?zip={zip},US&appid=5b2ba97a20af72d8eb71597ee008587d");
    response.EnsureSuccessStatusCode();

    var json = await response.Content.ReadAsStringAsync();
    GeoResponseModel? location = JsonSerializer.Deserialize<GeoResponseModel>(json);

    if (location == null)
        throw new Exception("Failed to fetch location");

    return location;
}
        public async Task<WeatherResponseModel> GetWeatherInformationAsync(double latitude, double longiude)
    {
        Console.WriteLine("Succesfully retrieved coordinates, getting weather data...");
        await Task.Delay(200);

        var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/3.0/onecall?lat={latitude}&lon={longiude}&appid={apiKey}");
        WeatherResponseModel? weatherInfo = null;

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Getting weather information...");
            string jsonData = await response.Content.ReadAsStringAsync();
            weatherInfo = JsonSerializer.Deserialize<WeatherResponseModel>(jsonData);
        }

        if (weatherInfo == null)
        {
            throw new Exception("Failed to fetch weather information");
        }

        return weatherInfo;
    }

}