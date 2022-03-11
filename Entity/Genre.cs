using System.ComponentModel.DataAnnotations;

namespace MovieApp.Entity
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
