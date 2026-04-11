using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiWithAspNet10.Data.DTO
{
    [Table("person")]
    public class PersonDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
