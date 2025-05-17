using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoriteMovies.Repositories.Interfaces;

namespace FavoriteMovies.Repositories;

    public class ContextDataBase : IContextDataBase
    {
        public Realms.Realm GetRealm()
        {
            return Realms.Realm.GetInstance();
        }
    }
