﻿using Microsoft.Extensions.Logging;

namespace ExampleApp.BlazorDesktop
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
                });
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped(sp =>
                new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7032")
                });
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
