using System.Text.Json.Serialization;

namespace BlazorHybridApp.Domain.PokeApi;

public class PokemonPagination<T>
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
    [JsonPropertyName("next")]
    public required string Next { get; set; }
    [JsonPropertyName("previous")]
    public required string Previous { get; set; }
    [JsonPropertyName("results")]
    public required T[] Results { get; set; }
}