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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=movies.db");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
