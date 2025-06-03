using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FavoriteMovies.Extensions;
using FavoriteMovies.Models;
using FavoriteMovies.Repositories.Interfaces;

namespace FavoriteMovies.ViewModels
{
    public partial class LocalFavoritesViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<FavoriteModel> _favorites;

         [ObservableProperty]
        private bool _isBusy;

        private IFavoriteRealmRepository _favoriteRealmRepository;

        public LocalFavoritesViewModel()
        {
            _favoriteRealmRepository = Startup.GetService<IFavoriteRealmRepository>();
        }

        // [RelayCommand]
        // public async virtual Task LoadDataFavorites()
        // {

        //     var list = _favoriteRealmRepository.GetAllObjects();

        // }

        [RelayCommand]
public async Task LoadDataFavorites()
{
    try
    {
        IsBusy = true;
        
        // Obtener datos de Realm
        var realmEntities = _favoriteRealmRepository.GetAllObjects().ToList();
        
        // Convertir cada entidad a modelo
        var models = realmEntities.Select(entity => entity.ToModel()).ToList();
        
        // Asignar a la colección observable
        Favorites = new ObservableCollection<FavoriteModel>(models);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error cargando favoritos: {ex.Message}");
        // Puedes mostrar un mensaje al usuario aquí
    }
    finally
    {
        IsBusy = false;
    }
}
        
    }
}