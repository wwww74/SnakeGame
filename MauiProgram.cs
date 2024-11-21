﻿using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace Snake
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("TeletactileRus.ttf", "Teletact");
            }).UseMauiCommunityToolkit();

            builder.Logging.AddDebug();
            return builder.Build();
        }
    }
}