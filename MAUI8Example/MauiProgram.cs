using MAUI8Example.Data;
using MAUI8Example.Pages.Monkeys;
using Microsoft.Extensions.Logging;

namespace MAUI8Example
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<MonkeyService>();
            builder.Services.AddTransient<MonkeyMenu>();
            builder.Services.AddTransient<ViewMonkeys>();

            Routing.RegisterRoute("monkeyMenu", typeof(MonkeyMenu));
            Routing.RegisterRoute("monkeys", typeof(ViewMonkeys));

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
