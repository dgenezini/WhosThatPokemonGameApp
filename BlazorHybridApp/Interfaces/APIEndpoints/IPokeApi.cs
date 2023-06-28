using BlazorHybridApp.Domain.PokeApi;
using Refit;

namespace BlazorHybridApp.Interfaces.APIEndpoints;

public interface IPokeApi
{
    [Get("/pokemon-species")]
    Task<PokemonPagination<PokemonHateoas>> GetAllPokemonSpecies([AliasAs("limit")] int limit = 2000);
}