
using obmdbapi.Models;

namespace obmdbapi.Interfaces
{
    public interface IRespositoryMovie
    {
        Task<MovieDetail> getMovieById(string id);
        Task<SearchResponse> getMovies(string term);
    }
}
