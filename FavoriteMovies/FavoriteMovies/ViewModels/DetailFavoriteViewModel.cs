using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FavoriteMovies.Extensions;
using FavoriteMovies.Models;
using FavoriteMovies.Repositories.Interfaces;

namespace FavoriteMovies.ViewModels;

[QueryProperty(nameof(Favorite), nameof(Favorite))]
public partial class DetailFavoriteViewModel : ObservableObject, IQueryAttributable
{
    private IFavoriteRealmRepository _favoriteRealmRepository;

    [ObservableProperty]
    private FavoriteModel favorite;

    public DetailFavoriteViewModel()
    {
        _favoriteRealmRepository = Startup.GetService<IFavoriteRealmRepository>();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Favorite = (FavoriteModel)query["favorite"];
    }

    [RelayCommand]
    public async Task Save()
    {
        var item = Favorite.ToEntity();
    }
    
}
