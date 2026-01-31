using eTickets.Data.Base;
using eTickets.Data.View_Models;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.name,
                Description = data.description,
                Price = data.price,
                ImageURL = data.ImageUrl,
                StartDate = data.startDate,
                EndtDate = data.endtDate,
                MovieCategory = data.movieCategory,
                CinemaID = data.cinemaID,
                ProducerID = data.producerID
            };

            await _context.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorsIDs)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieID = newMovie.ID,
                    ActorID = actorId
                };
                await _context.Actors_Movie.AddAsync(newActorMovie);

            }
            await _context.SaveChangesAsync();


        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = _context.Movies
                 .Include(c => c.Cinema)
                 .Include(p => p.Producer)
                 .Include(am => am.Actors_Movies)
                 .ThenInclude(a => a.Actor)
                 .FirstOrDefaultAsync(n => n.ID == id);

            return await movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                producers = await _context.producers.OrderBy(n => n.FullName).ToListAsync(),
                cinemas = await _context.cinemas.OrderBy(n => n.Name).ToListAsync(),
            };



            return response;

        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {

            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.ID == data.Id);

            if (dbMovie != null)
            {

                dbMovie.Name = data.name;
                dbMovie.Description = data.description;
                dbMovie.Price = data.price;
                dbMovie.ImageURL = data.ImageUrl;
                dbMovie.StartDate = data.startDate;
                dbMovie.EndtDate = data.endtDate;
                dbMovie.MovieCategory = data.movieCategory;
                dbMovie.CinemaID = data.cinemaID;
                dbMovie.ProducerID = data.producerID;

                await _context.SaveChangesAsync();

            }
            //Remove existing actors
            var existingActorsDb = _context.Actors_Movie.Where(n => n.MovieID == data.Id).ToList();
            _context.Actors_Movie.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();


            //Add Movie Actors
            foreach (var actorId in data.ActorsIDs)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieID = data.Id,
                    ActorID = actorId
                };
                await _context.Actors_Movie.AddAsync(newActorMovie);

            }
            await _context.SaveChangesAsync();

        }
    }
}
