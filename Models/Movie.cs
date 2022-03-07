namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Director { get; set; }
        public string[] Cast { get; set; }
        public string ImageURL { get; set; }
        public int GenreId { get; set; }

    }
}
