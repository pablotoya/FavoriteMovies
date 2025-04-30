using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FavoriteMovies.Models;
using FavoriteMovies.Repositories.Interfaces;

namespace FavoriteMovies.ViewModels;

public partial class FavoritesViewModel : ObservableObject
{   
    [ObservableProperty]
    public ObservableCollection<FavoriteModel> _favorites;

    [ObservableProperty]
    private bool _isBusy;

    private IFavoriteRepository _favoriteRepository;

    public FavoritesViewModel()
    {
        _favoriteRepository = Startup.GetService<IFavoriteRepository>();
    }

    [RelayCommand]

    public async Task LoadDataMovies()
    {
        IsBusy = true;
        var favorites= await _favoriteRepository.GetAllFavoritesAsync(1);
        Favorites = new ObservableCollection<FavoriteModel>(favorites);
        await Task.Delay(TimeSpan.FromSeconds(3));
        IsBusy = false;

    }
   
  

}
