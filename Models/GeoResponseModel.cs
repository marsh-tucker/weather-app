using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class GeoResponseModel
{
    [JsonPropertyName("zip")]
    public string zip { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("lat")]
    public double lat { get; set; }

    [JsonPropertyName("lon")]
    public double lon { get; set; }

    [JsonPropertyName("country")]
    public string country { get; set; }

}