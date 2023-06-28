using BlazorHybridApp.Domain;
using BlazorHybridApp.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorHybridApp.Components;

public partial class PokemonSelector
{
    [Inject]
    private PokemonDataService PokemonDataService { get; init; } = default!;

    private MudAutocomplete<PokemonInfo> _selectedPokemon = default!;
    private List<PokemonInfo>? _pokemon;

    public PokemonInfo? SelectedPokemon { get; set; }

    public void Clear()
    {
        _selectedPokemon.Clear();
    }

    protected override async Task OnInitializedAsync()
    {
        await GetPokemonListAsync();
    }

    private Task<IEnumerable<PokemonInfo>?> Search(string value)
    {
        // if text is null or empty, show complete list
        if (string.IsNullOrEmpty(value))
            return Task.FromResult(_pokemon?.Take(10));

        return Task.FromResult(_pokemon?
            .Where(pokemon => pokemon.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase))
            .Take(10));
    }

    protected async Task GetPokemonListAsync()
    {
        _pokemon = await PokemonDataService.GetPokemonListAsync();
    }
}
