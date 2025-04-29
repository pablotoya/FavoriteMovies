using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoriteMovies.Models;

namespace FavoriteMovies.Repositories.Interfaces;
public interface IFavoriteRepository
{
    Task<List<FavoriteModel>> GetAllFavoritesAsync(int page);

        
}
