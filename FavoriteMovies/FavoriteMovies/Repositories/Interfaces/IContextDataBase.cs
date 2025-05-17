using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteMovies.Repositories.Interfaces
{
    public interface IContextDataBase
    {
        Realms.Realm GetRealm();
    }
}