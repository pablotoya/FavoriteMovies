using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FavoriteMovies.Controls;
using FavoriteMovies.Extensions;
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
        var favorites= await _favoriteRepository.GetAllFavoritesAsync(2);

        foreach (var fav in favorites)
        {
            fav.GetFullPosterPath(); // Llama la extensión que modifica la propiedad
        }
       
        Favorites = new ObservableCollection<FavoriteModel>(favorites);
        await Task.Delay(TimeSpan.FromSeconds(3));
        IsBusy = false;

    }
   
   

}

