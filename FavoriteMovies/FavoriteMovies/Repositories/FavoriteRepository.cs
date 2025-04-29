using System;
using FavoriteMovies.Models;
using FavoriteMovies.Repositories.Interfaces;
using FavoriteMovies.Responses;
using FavoriteMovies.Services;
using FavoriteMovies.Services.Interfaces;

namespace FavoriteMovies.Repositories;

public class FavoriteRepository : IFavoriteRepository
{
    private readonly IResponseService _apiResponseService;

    public FavoriteRepository()
    {
        _apiResponseService = Startup.GetService<IResponseService>();        
    }

    public async Task<List<FavoriteModel>> GetAllFavoritesAsync(int page)
    {
        var favoriteClient = _apiResponseService.GetClient<ApiResponse>();

        var response = await favoriteClient.GetAsync<ApiResponse>(resource: $"account/21958881/favorite/movies?language=es-ES&sort_by=created_at.asc&page={page}");

        if (response != null)
        {
            return response.Results ?? new List<FavoriteModel>();
        }
        else
        {
            throw new Exception("Error fetching Movies");

        }
    }

}
