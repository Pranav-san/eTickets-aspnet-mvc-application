using eTickets.Models;
using Microsoft.EntityFrameworkCore;


namespace eTickets.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.actorID,
                am.movieID

            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.movieID);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.actorID);

            base.OnModelCreating(modelBuilder);
        }

        //Table Names
        public DbSet<Actor> Actors {  get; set; }
        public DbSet<Movie> Movies {  get; set; }
        public DbSet<Actor_Movie> Actors_Movie {  get; set; }
        public DbSet<Cinema> cinemas {  get; set; }
        public DbSet<Producer> producers {  get; set; }

    }
}
