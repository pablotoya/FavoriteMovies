namespace FavoriteMovies.Pages;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(DetailFavoritePage), typeof(DetailFavoritePage));
		Routing.RegisterRoute(nameof(FavoriteLocationPage), typeof(FavoriteLocationPage));
		
	}
}
