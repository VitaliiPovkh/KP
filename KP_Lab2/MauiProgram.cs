using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Extensions.Logging;

namespace KP_Lab2;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UseMauiCompatibility().ConfigureMauiHandlers((handlers) =>
        {
#if ANDROID
			    handlers.AddHandler(typeof(KP_Lab2.Controls.BorderedEntry),typeof(KP_Lab2.Platforms.Android.Renderers.BorderedEntryRenderer));
#endif
        });
        return builder.Build();
    }
}