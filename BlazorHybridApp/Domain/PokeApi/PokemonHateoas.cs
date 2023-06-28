using System.Text.Json.Serialization;

namespace BlazorHybridApp.Domain.PokeApi;

public class PokemonHateoas
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("url")]
    public required string Url { get; set; }
}