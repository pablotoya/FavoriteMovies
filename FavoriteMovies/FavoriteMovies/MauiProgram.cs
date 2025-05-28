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
				fonts.AddFont("Cinzel-Regular.ttf", "CinzelRegular");
				fonts.AddFont("fontello.ttf", "Iconfont");
			});

		builder.Services.AddSingleton<IFavoriteRepository, FavoriteRepository>();
		builder.Services.AddSingleton<IFavoriteRealmRepository, FavoriteRealmRepository>();
		builder.Services.AddSingleton<IResponseService, ResponseService>();
		builder.Services.AddSingleton<IContextDataBase, ContextDataBase>();

		builder.Services.AddTransient<FavoritesViewModel>();
		builder.Services.AddTransient<LocalFavoritesViewModel>();
		builder.Services.AddTransient<DetailFavoriteViewModel>();
		

#if DEBUG
		builder.Logging.AddDebug();
#endif

		var app = builder.Build();

		Startup.ServicesProvider = app.Services;

		return builder.Build();
	}
}
