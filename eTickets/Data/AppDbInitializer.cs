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
                        new Actor() { FullName = "Vijay", Bio = "Bio 1", ProfilePicURL = "https://res.cloudinary.com/dnrtr90w2/image/upload/v1769687794/Vijay_h2vgbb.jpg" },
                        new Actor() { FullName = "Tom Hardy", Bio = "Bio 2", ProfilePicURL = "https://res.cloudinary.com/dnrtr90w2/image/upload/v1769850905/Tom_Hardy_r2jqok.jpg" },
                    });
                    context.SaveChanges();
                }
                // Seed Cinemas
                if (!context.cinemas.Any())
                {
                    context.cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema() { Name = "Cinema 1", Description = "Description 1", Logo = "http://example.com/cinema1.jpg" },
                        new Cinema() { Name = "Cinema 2", Description = "Description 2", Logo = "http://example.com/cinema2.jpg" },
                    });
                    context.SaveChanges();
                }
                // Seed Producers
                if (!context.producers.Any())
                {
                    context.producers.AddRange(new List<Producer>()
                    {
                        new Producer() { FullName = "Producer 1", Bio = "Bio 1", ProfilePicURL = "http://example.com/producer1.jpg" },
                        new Producer() { FullName = "Producer 2", Bio = "Bio 2", ProfilePicURL = "http://example.com/producer2.jpg" },
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
                            Name="28 Days Later",
                            Description="Description 1",
                            Price=10.0,
                            ImageURL ="https://res.cloudinary.com/dnrtr90w2/image/upload/v1769850874/28_days_later.jpg_opos6s.jpg",
                            StartDate= DateTime.Now.AddDays(-10),
                            EndtDate= DateTime.Now.AddDays(-2),
                            CinemaID = 1, ProducerID=1,
                            MovieCategory= MovieCategory.Horror
                        },

                        new Movie()
                        {
                            Name="Thoongaa Vanam",
                            Description="Description 1",
                            Price=10.0,
                            ImageURL ="https://res.cloudinary.com/dnrtr90w2/image/upload/v1769850874/Thoonga_vanam_tiuuji.jpg",
                            StartDate= DateTime.Now.AddDays(-10),
                            EndtDate= DateTime.Now.AddDays(-2),
                            CinemaID = 1, ProducerID=1,
                            MovieCategory= MovieCategory.Thriller
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
                            ActorID=1,
                            MovieID=1
                        },
                        new Actor_Movie()
                        {
                            ActorID=2,
                            MovieID=2
                        },
                    });
                    context.SaveChanges();

                }
               
            }
        }
    }
}
