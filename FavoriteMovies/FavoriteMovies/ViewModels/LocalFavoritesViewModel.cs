using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FavoriteMovies.Models;
using FavoriteMovies.Repositories.Interfaces;

namespace FavoriteMovies.ViewModels
{
    public partial class LocalFavoritesViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<FavoriteModel> _favorites;

        private IFavoriteRealmRepository _favoriteRealmRepository;

        public LocalFavoritesViewModel()
        {
            _favoriteRealmRepository = Startup.GetService<IFavoriteRealmRepository>();
        }

        [RelayCommand]
        public async virtual Task LoadDataFavorites()
        {
            var list = _favoriteRealmRepository.GetAllObjects();
        }
        
    }
}