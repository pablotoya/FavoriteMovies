using System.Text.Json.Serialization;


namespace FavoriteMovies.Models
{
    public class FavoriteModel
    {
        [JsonPropertyName("adult")]
        public bool Adult { get; set; }

        [JsonPropertyName("backdrop_path")]
        public string? Backdrop_Path { get; set; }

        [JsonPropertyName("genre_ids")]
        public List<int> Genre_Ids { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("original_language")]
        public string? Original_Language { get; set; }

        [JsonPropertyName("original_title")]
        public string? Original_Title { get; set; }

        [JsonPropertyName("overview")]
        public string? Overview { get; set; }

        [JsonPropertyName("popularity")]
        public double Popularity { get; set; }

        [JsonPropertyName("poster_path")]
        public string? Poster_Path { get; set; }
        


        [JsonPropertyName("release_date")]
        public string? Release_Date { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("video")]
        public bool Video { get; set; }

        [JsonPropertyName("vote_average")]
        public double Vote_Average { get; set; }

        [JsonPropertyName("vote_count")]
        public int Vote_Count { get; set; }
    }

    
}