using System;
using System.Text.Json.Serialization;
using FavoriteMovies.Models;

namespace FavoriteMovies.Responses;

public class ApiResponse
{
    [JsonPropertyName("results")]
    public List<FavoriteModel>? Results { get; set; }

}
