using System;

namespace FavoriteMovies.Services.Interfaces;

public interface IResponseService
{
    ApiService<T> GetClient<T>();

}
