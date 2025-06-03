using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoriteMovies.Entities;
using FavoriteMovies.Models;


namespace FavoriteMovies.Extensions;

public static class FavoriteModelExtensions
{
    public static FavoriteModel ToModel(this FavoriteEntity entity)
    {
        return new FavoriteModel
        {
            Title = entity.Title,
            Popularity = entity.Popularity,
            FullPosterPath = entity.FullPosterPath,
            Original_Title = entity.Original_Title,
            Original_Language = entity.Original_Language,
            Release_Date = entity.Release_Date,
            Adult = entity.Adult,
            Overview = entity.Overview,
            Vote_Average = entity.Vote_Average,
            Vote_Count = entity.Vote_Count
        };
    }
}
