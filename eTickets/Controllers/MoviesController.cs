using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles=UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {

            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Filter(string SearchString)
        {

            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(SearchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(SearchString.ToLower()) 
                || n.Description.ToLower().Contains(SearchString.ToLower())).ToList();

                return View("Index", filteredResult);

            }

            return View("Index", allMovies);
        }


        [AllowAnonymous]
        //GET: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null)
                return View("NotFound");
            else
            {
                return View(movieDetails);
            }
        }

        //Get: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.cinemas, "ID", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.producers, "ID", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.actors, "ID", "FullName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
                ViewBag.Cinemas = new SelectList(movieDropdownsData.cinemas, "ID", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.producers, "ID", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.actors, "ID", "FullName");
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //Get: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var moviedetails = await _service.GetMovieByIdAsync(id);
            if (moviedetails == null) 
                return View("NotFound");

            var movie = new NewMovieVM()
            {
                Id = moviedetails.ID,
                name = moviedetails.Name,
                ImageUrl = moviedetails.ImageURL,
                description = moviedetails.Description,
                price = moviedetails.Price,
                startDate = moviedetails.StartDate,
                endtDate = moviedetails.EndtDate,
                movieCategory = moviedetails.MovieCategory,
                cinemaID = moviedetails.CinemaID,
                producerID = moviedetails.ProducerID,
                ActorsIDs = moviedetails.Actors_Movies.Select(n => n.ActorID).ToList(),
            };

            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.cinemas, "ID", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.producers, "ID", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.actors, "ID", "FullName");

            return View(movie);
        }
        [HttpPost]
        public async Task<IActionResult> Edit( int id, NewMovieVM movie)
        {
            if (id != movie.Id)
                return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
                ViewBag.Cinemas = new SelectList(movieDropdownsData.cinemas, "Id", "name");
                ViewBag.Producers = new SelectList(movieDropdownsData.producers, "Id", "Fullname");
                ViewBag.Actors = new SelectList(movieDropdownsData.actors, "Id", "Fullname");
                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
