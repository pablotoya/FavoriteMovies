using FavoriteMovies.ViewModels;

namespace FavoriteMovies.Pages;

public partial class FavoritePage : ContentPage
{
    public FavoritePage(FavoritesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
