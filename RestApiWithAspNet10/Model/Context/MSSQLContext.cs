using Microsoft.EntityFrameworkCore;
using RestApiWithAspNet10.Model;

namespace RestApiWithAspNet10.Model.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options){ }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }

    } 
}
