using System;
using FavoriteMovies.Services.Interfaces;

namespace FavoriteMovies.Services;

public class ResponseService : IResponseService
{
    public ApiService<T> GetClient<T>()
    {
        return new ApiService<T>("https://api.themoviedb.org/3/");
        
        
    }
}
