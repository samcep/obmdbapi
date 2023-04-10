using Microsoft.AspNetCore.Mvc;
using obmdbapi.Interfaces;
using obmdbapi.Models;

namespace obmdbapi.Controllers
{

    public static class Global
    {
        public static List<string> HistoryFilter = new List<string>();
    }
    public class MovieController : Controller
    {
       

        public readonly IRespositoryMovie respositoryMovie;

        public MovieController(IRespositoryMovie respositoryMovie)
        {
            this.respositoryMovie = respositoryMovie;
        }

        public  async Task<IActionResult> Index()
        {
            Global.HistoryFilter?.Clear();
            SearchResponse searchResponse = await respositoryMovie.getMovies("");
            if (searchResponse.Search is null)
            {
                return RedirectToAction("NotFound");
            }
            IEnumerable<Movie> movies = searchResponse.Search;
            return View(movies);
       
        }

        public IActionResult NotFound()
        {
            return View();
        }

        public async Task<IActionResult> MovieDetail(string id)
        {
            MovieDetail movie = await respositoryMovie.getMovieById(id);
            if (movie.Equals(null))
            {
                return RedirectToAction("NotFound");
            }
            
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> getMoviesByTerm( Filter filter)
        {
           
            if(string.IsNullOrEmpty(filter.Term))
            {
       
               return RedirectToAction("NotFound");
            }

           
            SearchResponse searchResponse = await respositoryMovie.getMovies(filter.Term);
            if (searchResponse.Search is null)
            {
                return RedirectToAction("NotFound");
            }
            Global.HistoryFilter.Add(filter.Term);
            IEnumerable<Movie> movies = searchResponse.Search;
            return View("Index" , movies);
        }


        public async Task<IActionResult> showForCurrentFilter()
        {
            if(Global.HistoryFilter.Count == 0)
            {
                return RedirectToAction("Index");
            }
            string currentFilter = Global.HistoryFilter.Last();
            SearchResponse searchResponse = await respositoryMovie.getMovies(currentFilter);
            if (searchResponse.Search is null)
            {
                return RedirectToAction("NotFound");
            }
            IEnumerable<Movie> movies = searchResponse.Search;
            return View("Index", movies);
        }
        
    }

   
}
