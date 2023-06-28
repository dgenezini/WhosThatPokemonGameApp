using Microsoft.AspNetCore.Components;

namespace BlazorHybridApp.Components;

public partial class WhosThatPokemonResult
{
    [Parameter]
    public bool Show { get; init; }
    [Parameter]
    public bool Correct { get; init; }
}
