using Microsoft.EntityFrameworkCore;
using MovieApp.Entity;

namespace MovieApp.Data
{
    public class MovieContext: DbContext 
    {
        //dışarıdan connection stringi alttaki işlem sayesinde verebiliyoruz
        //constructorun beklediği parametre startup içierisinden geliyor(services.adddbcontext)
        //yani nesne uygulama calısırken service copntainer tarafından getiriliopr
        public MovieContext(DbContextOptions<MovieContext> options):base(options){}
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Cast> Casts { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=movies.db");
        //    base.OnConfiguring(optionsBuilder);
        //}


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Movie>().Property(b => b.Title).IsRequired();
            modelbuilder.Entity<Movie>().Property(b => b.Title).HasMaxLength(500);

            modelbuilder.Entity<Genre>().Property(b => b.Name).IsRequired();
            modelbuilder.Entity<Genre>().Property(b => b.Name).HasMaxLength(50);
        }
    }
}
