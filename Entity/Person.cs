using System.Collections.Generic;

namespace MovieApp.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Imdb { get; set; }
        public string HomePage { get; set; }
        public string PlaceOfBirth { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }//foerign key, unique key
    }
}
