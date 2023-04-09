using Newtonsoft.Json;
using obmdbapi.Interfaces;
using obmdbapi.Models;
using System.Globalization;

namespace obmdbapi.Repository
{
    public class MovieRespository  : IRespositoryMovie
    {
        public readonly IConfiguration configuration;
        public  string urlConnection;

        public MovieRespository (IConfiguration configuration)
        {
            this.configuration = configuration;
            getConnection();
        }

        private string getConnection() 
        {
            string baseUrl = configuration["configuration:BaseUrl"];
            string apiKey = configuration["configuration:ApiKey"];

            urlConnection = $"{baseUrl}/?apikey={apiKey}";
            return urlConnection; 
        }
        public async Task<SearchResponse> getMovies(string term)
        {
          

            if (String.IsNullOrEmpty(term))
            {
                term = "hulk";
            }
            try
            {
                HttpClient httpClient= new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync($"{urlConnection}&s={term}");
                var resp = await response.Content.ReadAsStringAsync();
                SearchResponse SearchResponse = JsonConvert.DeserializeObject<SearchResponse>(resp);
                return SearchResponse;

            }catch(Exception ex)
            {

                SearchResponse searchResponse = new SearchResponse();
                return searchResponse;
            }
            
        }


        public async Task<MovieDetail> getMovieById (string id)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync($"{urlConnection}&i={id}");
                var resp = await response.Content.ReadAsStringAsync();
                MovieDetail movie = JsonConvert.DeserializeObject<MovieDetail>(resp);
                return movie;

            }
            catch (Exception ex)
            {

                MovieDetail movie = new MovieDetail();
                return movie;
            }
        }
    }
}
