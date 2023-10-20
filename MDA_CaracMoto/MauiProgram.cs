﻿using MDA_CaracMoto.Facto;
using MDA_CaracMoto.Pages;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;

namespace MDA_CaracMoto
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

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IDataService, DataService>();

            //Audio
            builder.Services.AddSingleton(AudioManager.Current);
            builder.Services.AddTransient<AffichageMoto>();

            return builder.Build();
        }
    }
}