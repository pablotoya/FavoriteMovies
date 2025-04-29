using CommunityToolkit.Maui;
using FavoriteMovies.Pages;
using FavoriteMovies.Repositories;
using FavoriteMovies.Repositories.Interfaces;
using FavoriteMovies.Services;
using FavoriteMovies.Services.Interfaces;
using FavoriteMovies.ViewModels;
using Microsoft.Extensions.Logging;

namespace FavoriteMovies;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiCommunityToolkit()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IFavoriteRepository, FavoriteRepository>();
		builder.Services.AddSingleton<IResponseService, ResponseService>();

		builder.Services.AddTransient<FavoritesViewModel>();
		builder.Services.AddTransient<FavoritePage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif
		var app = builder.Build();

		Startup.ServicesProvider = app.Services;

		return app;
	}
}
