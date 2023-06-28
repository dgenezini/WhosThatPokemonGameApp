using BlazorHybridApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System.Reflection;

namespace BlazorHybridApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

        builder.AddAppSettingsConfiguration();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddMudServices();

        builder.Services.AddSingleton<PokemonDataService>();

        return builder.Build();
    }

    private static void AddAppSettingsConfiguration(this MauiAppBuilder builder)
    {
        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("BlazorHybridApp.appsettings.json");

        var config = new ConfigurationBuilder()
                    .AddJsonStream(stream!)
                    .Build();

        builder.Configuration.AddConfiguration(config);
    }
}
