using eTickets.Data.Enums;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eTickets.Data
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                // Seed Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor() { Fullname = "Actor 1", Bio = "Bio 1", profilePicURL = "http://example.com/actor1.jpg" },
                        new Actor() { Fullname = "Actor 2", Bio = "Bio 2", profilePicURL = "http://example.com/actor2.jpg" },
                    });
                    context.SaveChanges();
                }
                // Seed Cinemas
                if (!context.cinemas.Any())
                {
                    context.cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema() { name = "Cinema 1", description = "Description 1", logo = "http://example.com/cinema1.jpg" },
                        new Cinema() { name = "Cinema 2", description = "Description 2", logo = "http://example.com/cinema2.jpg" },
                    });
                    context.SaveChanges();
                }
                // Seed Producers
                if (!context.producers.Any())
                {
                    context.producers.AddRange(new List<Producer>()
                    {
                        new Producer() { Fullname = "Producer 1", Bio = "Bio 1", profilePicUrl = "http://example.com/producer1.jpg" },
                        new Producer() { Fullname = "Producer 2", Bio = "Bio 2", profilePicUrl = "http://example.com/producer2.jpg" },
                    });
                    context.SaveChanges();
                }

                //Movies

                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            name="Movie 1",
                            description="Description 1",
                            price=10.0,
                            ImageUrl ="http://example.com/movie1.jpg",
                            startDate= DateTime.Now.AddDays(-10),
                            endtDate= DateTime.Now.AddDays(-2),
                            cinemaID = 1, producerID=1,
                            movieCategory= MovieCategory.Action
                        },

                        new Movie()
                        {
                            name="Movie 2",
                            description="Description 1",
                            price=10.0,
                            ImageUrl ="http://example.com/movie1.jpg",
                            startDate= DateTime.Now.AddDays(-10),
                            endtDate= DateTime.Now.AddDays(-2),
                            cinemaID = 1, producerID=1,
                            movieCategory= MovieCategory.Thriller
                        },

                    });
                    context.SaveChanges();

                }

                //Actors_Movies
                if (!context.Actors_Movie.Any())
                {
                    context.Actors_Movie.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            actorID=1,
                            movieID=1
                        },
                        new Actor_Movie()
                        {
                            actorID=2,
                            movieID=2
                        },
                    });
                    context.SaveChanges();

                }
               
            }
        }
    }
}
