using BlazorHybridApp.Domain;
using BlazorHybridApp.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorHybridApp.Components;

public partial class WhosThatPokemon
{
    [Inject]
    private PokemonDataService PokemonDataService { get; init; } = default!;

    private PokemonInfo _pokemonData = default!;
    private PokemonSelector _pokemonSelector = default!;
    private bool _correct;
    private bool _showResult;
    private bool _loading;

    protected override async Task OnInitializedAsync()
    {
        _pokemonData = await GetRandomPokemon();
    }

    private async Task<PokemonInfo> GetRandomPokemon()
    {
        try
        {
            _loading = true;

            var pokemonCount = await PokemonDataService.GetPokemonCountAsync();

            Random r = new Random();
            var pokemonId = r.Next(1, pokemonCount);

            return await PokemonDataService.GetPokemonByIdAsync(pokemonId);
        }
        finally
        {
            _loading = false;
        }
    }

    protected void Confirm()
    {
        _correct = _pokemonSelector?.SelectedPokemon?.Id == _pokemonData?.Id;

        _showResult = true;
    }

    protected async Task ShowNextAsync()
    {
        _showResult = false;
        _pokemonSelector.Clear();

        _pokemonData = await GetRandomPokemon();
    }    
}
