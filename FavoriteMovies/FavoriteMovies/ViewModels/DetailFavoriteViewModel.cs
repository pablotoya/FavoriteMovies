using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FavoriteMovies.Extensions;
using FavoriteMovies.Models;
using FavoriteMovies.Repositories.Interfaces;
using FavoriteMovies.validators;

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

        var validator = new FavoriteEntityValidator();
        var result = validator.Validate(item);

        if (!result.IsValid)
        {
            // Mostrar todos los errores en una sola alerta
            var errores = string.Join("\n", result.Errors.Select(e => $"• {e.ErrorMessage}"));
            await Shell.Current.DisplayAlert("Errores de validación", errores, "OK");
            return;
        }

        _favoriteRealmRepository.SaveFavorite(item);


        // Mostrar mensaje de éxito
        await Shell.Current.DisplayAlert("✅ Éxito", "La película se guardó correctamente.", "OK");
    }


    
}
