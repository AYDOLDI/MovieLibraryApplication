using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Entity
{
    public class Movie
    {
        //Primary Key => Id, <TypeName>Id
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }
        public string ImageURL { get; set; }
        //??????????public Genre Genre { get; set; } //navigation property

        //????????public int GenreId { get; set; } // nullable (değiştik artık değil)
        //stringler nullable fakat integerlar degil. 
        //genreid integer oldugundan ve yanında soru işareti bulunmadıgından
        //mutevellit 0 değeri varsayılan olarak aktarılır

        public List<Genre> Genres { get; set; }
        //film dediğimde birden fazla tur bilgisi olacak
        //5.0'dan itibaren 3. bir tablo entity framework core tarafından oluşutrulacak
        //2 tablo arasındaki listelere göre many to many ilişki olacak ve bu many to many
        //bilgiilerini ayrı bir tabloda tutması gerekecek
    }
}
