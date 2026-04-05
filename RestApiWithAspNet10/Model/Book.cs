using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestApiWithAspNet10.;


namespace RestApiWithAspNet10.Model
{
    [Table("books")]
    public class Book : Base.BaseEntity
    {
        [Required]
        [Column("title", TypeName = "varchar(MAX)")]
        public string Title { get; set; }
        
        [Required]
        [Column("author", TypeName = "varchar(MAX)")]
        public string Author { get; set; }
        
        [Required]
        [Column("price")]
        public decimal Price { get; set; }
        
        [Required]
        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }
    }
}
