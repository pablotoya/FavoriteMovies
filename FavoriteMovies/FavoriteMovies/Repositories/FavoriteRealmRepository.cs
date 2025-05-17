using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoriteMovies.Entities;
using FavoriteMovies.Repositories.Interfaces;

namespace FavoriteMovies.Repositories;

    public class FavoriteRealmRepository : IFavoriteRealmRepository
    {
        private readonly IContextDataBase _contextRealm;

        public FavoriteRealmRepository ()
        {
            _contextRealm = Startup.ServicesProvider.GetService<IContextDataBase>();
        }

        public void SaveFavorite(FavoriteEntity item)
        {
            var realm = _contextRealm.GetRealm();
            realm.Write(() =>
            {
                realm.Add(item);
            });
        }

        public IQueryable<FavoriteEntity> GetAllObjects()
        {
            var realm = _contextRealm.GetRealm();
            return realm.All<FavoriteEntity>();
        }
    }
