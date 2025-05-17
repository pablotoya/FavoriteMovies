using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using Realms;

namespace FavoriteMovies.Entities;

public class FavoriteEntity : RealmObject
{
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; }

        [MapTo("adult")]
        public bool Adult { get; set; }

        [MapTo("backdrop_path")]     
        public string? Backdrop_Path { get; set; }


        [MapTo("original_language")]
        public string? Original_Language { get; set; }

        [MapTo("original_title")]
        public string? Original_Title { get; set; }

        [MapTo("overview")]
        public string? Overview { get; set; }

        [MapTo("popularity")]
        public double Popularity { get; set; }

        [MapTo("poster_path")]
        public string? Poster_Path { get; set; }
        
        public string? FullPosterPath { get; set; }

        [MapTo("release_date")]
        public string? Release_Date { get; set; }

        [MapTo("title")]
        public string? Title { get; set; }

        [MapTo("video")]
        public bool Video { get; set; }

        [MapTo("vote_average")]
        public double Vote_Average { get; set; }

        [MapTo("vote_count")]
        public int Vote_Count { get; set; }

        public int UserRating { get; set; }    
        
}
