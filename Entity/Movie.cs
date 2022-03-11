using System.ComponentModel.DataAnnotations;

namespace MovieApp.Entity
{
    public class Movie
    {
        //Primary Key => Id, <TypeName>Id
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Details { get; set; }
        public string Director { get; set; }
        //public string[] Cast { get; set; }
        public string ImageURL { get; set; }
        [Required]
        public int GenreId { get; set; }
        //stringler nullable fakat integerlar degil. 
        //genreid integer oldugundan ve yanında soru işareti bulunmadıgından
        //mutevellit 0 değeri varsayılan olarak aktarılır

    }
}
