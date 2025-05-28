using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FavoriteMovies.Controls;
using FavoriteMovies.Extensions;
using FavoriteMovies.Models;
using FavoriteMovies.Pages;
using FavoriteMovies.Repositories.Interfaces;
using MongoDB.Bson;

namespace FavoriteMovies.ViewModels;

public partial class FavoritesViewModel : ObservableObject
{


    [ObservableProperty]
    public ObservableCollection<FavoriteModel> _favorites;

    [ObservableProperty]
    private bool _isBusy;

    private IFavoriteRepository _favoriteRepository;

    private IFavoriteRealmRepository _favoriteRealmRepository;

    public FavoritesViewModel()
    {
        _favoriteRepository = Startup.GetService<IFavoriteRepository>();
        _favoriteRealmRepository = Startup.GetService<IFavoriteRealmRepository>();
    }

    [RelayCommand]
    public async Task LoadDataMovies()
    {
        IsBusy = true;
        var favorites = await _favoriteRepository.GetAllFavoritesAsync(1);

        foreach (var fav in favorites)
        {
            fav.GetFullPosterPath(); // Llama la extensión que modifica la propiedad
        }

        Favorites = new ObservableCollection<FavoriteModel>(favorites);
        await Task.Delay(TimeSpan.FromSeconds(3));
        IsBusy = false;

    }

    [RelayCommand]
    public async Task GoToDetail(FavoriteModel favorite)
    {
        var parameters = new Dictionary<string, object> { { "favorite", favorite } };
        await Shell.Current.GoToAsync(nameof(DetailFavoritePage), true, parameters);
    }

   

}

