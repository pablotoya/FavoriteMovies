using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoriteMovies.Entities;

namespace FavoriteMovies.Repositories.Interfaces
{
    public interface IFavoriteRealmRepository
    {
        void SaveFavorite(FavoriteEntity item);

        IQueryable<FavoriteEntity> GetAllObjects();
    }
}