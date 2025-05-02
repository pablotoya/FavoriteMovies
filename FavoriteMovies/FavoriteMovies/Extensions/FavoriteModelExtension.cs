using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoriteMovies.Models;

namespace FavoriteMovies.Extensions
{
    public static class FavoriteModelExtension
    {
        public static void GetFullPosterPath(this FavoriteModel movie)
        {

            if (!string.IsNullOrEmpty(movie.Poster_Path))
        {
            movie.FullPosterPath = $"https://image.tmdb.org/t/p/w500{movie.Poster_Path}";
        }
        else
        {
            movie.FullPosterPath = "imagen_defecto.jpg"; // si no viene imagen
        }
        }
    }
}