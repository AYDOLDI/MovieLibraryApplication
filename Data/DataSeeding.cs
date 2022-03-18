using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Data
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();

           context.Database.Migrate(); //dotnet ef db update otomatik hali
            //get pending migrations bekleyen, oluşturulmuş ancak oluşturulmamış 
            //migrationları gösterir. eğer sayısı 0'sa DB'ye bilgi ekleyebilirim
            //2. if, daha önceden ilgili tabloya kayıt eklenmiş mi

            var genres = new List<Genre>()
            {
                new Genre {Name = "Dram", Movies =
                    new List<Movie>(){
                        new Movie{
                            Title = "New (list) Movie",
                            Details = "movie generated in the genres(list)",
                            ImageURL = "33.jpg",
                        },
                         new Movie{
                            Title = "2. New (list) Movie",
                            Details = "movie generated in the genres(list)",
                            ImageURL = "22.jpg",
                        }
                    }
                },
                new Genre {Name= "Action" },
                new Genre {Name= "Romantic" },
                new Genre {Name = "Comedy" }
            };
            var movies = new List<Movie>()
            {
                new Movie {
                    Title = "QUEENS GAMBIT",
                    Details = "Orphaned at the tender age of nine, prodigious introvert Beth Harmon discovers and masters the game of chess in 1960s USA. But child stardom comes at a price.",
                   
                    //Cast = new string[] { "Anya Taylor-Joy", "Marcin Dorocinski", "Thomas Brodie" },
                    ImageURL = "11.jpg",
                    Genres = new List<Genre>(){ genres[0], new Genre(){Name = "New Category"}, genres[1] }
                },
                new Movie {
                    Title = "THE GODFATHER",
                    Details = "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son.",
                 
                    //Cast = new string[] { "Marlon Brando", "Al Pacino" },
                    ImageURL = "22.jpg",
                    Genres = new List<Genre>(){ genres[0], genres[2] }
                },
                new Movie {
                    Title = "12 ANGRY MEN",
                    Details = "The jury in a New York City murder trial is frustrated by a single member whose skeptical caution forces them to more carefully consider the evidence before jumping to a hasty verdict.",
                   
                    //Cast = new string[] { "Henry Fonda", "Lee J. Cobb", "Martin Balsam", "John Fiedler"},
                    ImageURL = "33.jpg",
                    Genres = new List<Genre>(){ genres[0], genres[3] }
                },
                  new Movie {
                    Title = "Django Unchained",
                    Details = "With the help of a German bounty-hunter, a freed slave sets out to rescue his wife from a brutal plantation-owner in Mississippi.",
                   
                    //Cast = new string[] { "Jamie Foxx", "Christoph Waltz", "Leonardo DiCaprio" },
                    ImageURL = "33.jpg",
                    Genres = new List<Genre>(){ genres[0], genres[1] }
                },
                new Movie {
                    Title = "Once Upon Time In Hollywood",
                    Details = "A faded television actor and his stunt double strive to achieve fame and success in the final years of Hollywood's Golden Age in 1969 Los Angeles.",
                   
                    //Cast = new string[] { "Leonardo DiCaprio", "Brad Pitt" },
                    ImageURL = "22.jpg",
                    Genres = new List<Genre>(){ genres[0], genres[2] }
                },
                new Movie {
                    Title = "Pulp Fiction",
                    Details = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                  
                    //Cast = new string[] { "John Travolta", "Uma Thurman", "Samuel L. Jackson", "Bruce Willis"},
                    ImageURL = "11.jpg",
                    Genres = new List<Genre>(){ genres[0], genres[3] }
                }
            };
            var users = new List<User>()
            {
                new User()
                {
                    Username = "user1", Email = "doganaylmlz@gmail.com", Password="1234", ImageURL="person1.jpg"
                },
                new User()
                {
                    Username = "user2", Email = "doganaylmlz@icloud.com", Password="1234", ImageURL="person2.jpg"
                },
                new User()
                {
                    Username = "user3", Email = "doganay.yilmaz@ogr.deu.edu.tr", Password="1234", ImageURL="person3.jpg"
                },
                 new User()
                {
                    Username = "user4", Email = "2018510067@ogr.deu.edu.tr", Password="1234", ImageURL="person4.jpg"
                }

            };
            var people = new List<Person>()
            {
                new Person()
                {
                    Name = "Personel 1",
                    Bio = "Tanıtım 1",
                    User = users[0]

                },
                new Person()
                {
                    Name = "Personel 2",
                    Bio = "Tanıtım 2",
                    User = users[1]
                }
            };
            var crews = new List<Crew>()
            {
                new Crew() {Movie = movies[0], Person = people[0], Job = "Director"},
                new Crew() {Movie = movies[0], Person = people[1], Job = "Second Director"}
            };
            var casts = new List<Cast>()
            {
                new Cast() { Movie = movies[0], Person = people[0], Name ="Actor 1", Character = "Johnny"},
                new Cast() { Movie = movies[0], Person = people[1], Name ="Actor 2", Character = "Jack"}

            };


            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);
                }

                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange(movies);
                }
                if (context.Users.Count() == 0)
                {
                    context.Users.AddRange(users);
                }
                if (context.People.Count() == 0)
                {
                    context.People.AddRange(people);
                }
                if (context.Crews.Count() == 0)
                {
                    context.Crews.AddRange(crews);
                }
                if (context.Casts.Count() == 0)
                {
                    context.Casts.AddRange(casts);
                }
                context.SaveChanges();
            }
        }
    }
}
