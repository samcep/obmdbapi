

namespace obmdbapi.Models
{
    
        using System;
        using System.Collections.Generic;
        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;

        public partial class SearchResponse
        {
            [JsonProperty("Search")]
            public IEnumerable<Movie> Search { get; set; }

            [JsonProperty("totalResults")]

            public string TotalResults { get; set; }

            [JsonProperty("Response")]
            public string Response { get; set; }
        }

        public partial class Movie
        {
            [JsonProperty("Title")]
            public string Title { get; set; }

            [JsonProperty("Year")]
            public string Year { get; set; }

            [JsonProperty("imdbID")]
            public string ImdbId { get; set; }

            [JsonProperty("Type")]
            public TypeEnum Type { get; set; }

            [JsonProperty("Poster")]
            public Uri Poster { get; set; }
        }

        public enum TypeEnum { Movie, Series };

    


}


