using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoriteMovies.Entities;
using FavoriteMovies.Models;

namespace FavoriteMovies.Extensions;

public static class FavoriteProfile
{
    public static FavoriteEntity ToEntity(this FavoriteModel obj)
    {
        return new FavoriteEntity
        {
            Id = MongoDB.Bson.ObjectId.GenerateNewId(),
            Title = obj.Title,
            Popularity = obj.Popularity,
            FullPosterPath = obj.FullPosterPath,
            Original_Title = obj.Original_Title,
            Original_Language = obj.Original_Language,
            Release_Date = obj.Release_Date,
            Adult = obj.Adult,
            Overview = obj.Overview,
            Vote_Average = obj.Vote_Average,
            Vote_Count = obj.Vote_Count,

        };
    }
    
    }
