using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Snake.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Snake.Interfaces;
using Snake.Services;
using Snake.ViewModels;

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

            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlite($"Filename={Path.Combine(FileSystem.AppDataDirectory, "SnakeDatabase.db")}");
            });

            builder.Services.AddTransient<IDatabaseService, DatabaseService>();
            builder.Services.AddTransient<IWindowService, WindowService>();

            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<GamePageViewModel>();

            builder.Logging.AddDebug();
            return builder.Build();
        }
    }
}