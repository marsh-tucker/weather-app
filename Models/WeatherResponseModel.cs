using System.Text.Json.Serialization;
using System.Collections.Generic;

public class WeatherResponseModel
{
    [JsonPropertyName("lat")]
    public double lat { get; set; }

    [JsonPropertyName("lon")]
    public double lon { get; set; }

    [JsonPropertyName("timezone")]
    public string timezone { get; set; }

    [JsonPropertyName("timezone_offset")]
    public int timezone_offset { get; set; }

    [JsonPropertyName("current")]
    public Current current { get; set; }

    [JsonPropertyName("minutely")]
    public List<Minutely> minutely { get; set; }

    [JsonPropertyName("hourly")]
    public List<Hourly> hourly { get; set; }

    [JsonPropertyName("daily")]
    public List<Daily> daily { get; set; }

    [JsonPropertyName("alerts")]
    public List<Alert> alerts { get; set; }
}

public class Current
{
    [JsonPropertyName("dt")]
    public long dt { get; set; }

    [JsonPropertyName("sunrise")]
    public long sunrise { get; set; }

    [JsonPropertyName("sunset")]
    public long sunset { get; set; }

    [JsonPropertyName("temp")]
    public double temp { get; set; }

    [JsonPropertyName("feels_like")]
    public double feels_like { get; set; }

    [JsonPropertyName("pressure")]
    public int pressure { get; set; }

    [JsonPropertyName("humidity")]
    public int humidity { get; set; }

    [JsonPropertyName("dew_point")]
    public double dew_point { get; set; }

    [JsonPropertyName("uvi")]
    public double uvi { get; set; }

    [JsonPropertyName("clouds")]
    public int clouds { get; set; }

    [JsonPropertyName("visibility")]
    public int visibility { get; set; }

    [JsonPropertyName("wind_speed")]
    public double wind_speed { get; set; }

    [JsonPropertyName("wind_deg")]
    public int wind_deg { get; set; }

    [JsonPropertyName("wind_gust")]
    public double wind_gust { get; set; }

    [JsonPropertyName("weather")]
    public List<Weather> weather { get; set; }
}

public class Minutely
{
    [JsonPropertyName("dt")]
    public long dt { get; set; }

    [JsonPropertyName("precipitation")]
    public double precipitation { get; set; }
}

public class Hourly
{
    [JsonPropertyName("dt")]
    public long dt { get; set; }

    [JsonPropertyName("temp")]
    public double temp { get; set; }

    [JsonPropertyName("feels_like")]
    public double feels_like { get; set; }

    [JsonPropertyName("pressure")]
    public int pressure { get; set; }

    [JsonPropertyName("humidity")]
    public int humidity { get; set; }

    [JsonPropertyName("dew_point")]
    public double dew_point { get; set; }

    [JsonPropertyName("uvi")]
    public double uvi { get; set; }

    [JsonPropertyName("clouds")]
    public int clouds { get; set; }

    [JsonPropertyName("visibility")]
    public int visibility { get; set; }

    [JsonPropertyName("wind_speed")]
    public double wind_speed { get; set; }

    [JsonPropertyName("wind_deg")]
    public int wind_deg { get; set; }

    [JsonPropertyName("wind_gust")]
    public double wind_gust { get; set; }

    [JsonPropertyName("weather")]
    public List<Weather> weather { get; set; }

    [JsonPropertyName("pop")]
    public double pop { get; set; }
}

public class Daily
{
    [JsonPropertyName("dt")]
    public long dt { get; set; }

    [JsonPropertyName("sunrise")]
    public long sunrise { get; set; }

    [JsonPropertyName("sunset")]
    public long sunset { get; set; }

    [JsonPropertyName("moonrise")]
    public long moonrise { get; set; }

    [JsonPropertyName("moonset")]
    public long moonset { get; set; }

    [JsonPropertyName("moon_phase")]
    public double moon_phase { get; set; }

    [JsonPropertyName("summary")]
    public string summary { get; set; }

    [JsonPropertyName("temp")]
    public Temp temp { get; set; }

    [JsonPropertyName("feels_like")]
    public FeelsLike feels_like { get; set; }

    [JsonPropertyName("pressure")]
    public int pressure { get; set; }

    [JsonPropertyName("humidity")]
    public int humidity { get; set; }

    [JsonPropertyName("dew_point")]
    public double dew_point { get; set; }

    [JsonPropertyName("wind_speed")]
    public double wind_speed { get; set; }

    [JsonPropertyName("wind_deg")]
    public int wind_deg { get; set; }

    [JsonPropertyName("wind_gust")]
    public double wind_gust { get; set; }

    [JsonPropertyName("weather")]
    public List<Weather> weather { get; set; }

    [JsonPropertyName("clouds")]
    public int clouds { get; set; }

    [JsonPropertyName("pop")]
    public double pop { get; set; }

    [JsonPropertyName("rain")]
    public double rain { get; set; }

    [JsonPropertyName("uvi")]
    public double uvi { get; set; }
}

public class Temp
{
    [JsonPropertyName("day")]
    public double day { get; set; }

    [JsonPropertyName("min")]
    public double min { get; set; }

    [JsonPropertyName("max")]
    public double max { get; set; }

    [JsonPropertyName("night")]
    public double night { get; set; }

    [JsonPropertyName("eve")]
    public double eve { get; set; }

    [JsonPropertyName("morn")]
    public double morn { get; set; }
}

public class FeelsLike
{
    [JsonPropertyName("day")]
    public double day { get; set; }

    [JsonPropertyName("night")]
    public double night { get; set; }

    [JsonPropertyName("eve")]
    public double eve { get; set; }

    [JsonPropertyName("morn")]
    public double morn { get; set; }
}

public class Weather
{
    [JsonPropertyName("id")]
    public int id { get; set; }

    [JsonPropertyName("main")]
    public string main { get; set; }

    [JsonPropertyName("description")]
    public string description { get; set; }

    [JsonPropertyName("icon")]
    public string icon { get; set; }
}

public class Alert
{
    [JsonPropertyName("sender_name")]
    public string sender_name { get; set; }

    [JsonPropertyName("event")]
    public string @event { get; set; }

    [JsonPropertyName("start")]
    public long start { get; set; }

    [JsonPropertyName("end")]
    public long end { get; set; }

    [JsonPropertyName("description")]
    public string description { get; set; }

    [JsonPropertyName("tags")]
    public List<string> tags { get; set; }
}