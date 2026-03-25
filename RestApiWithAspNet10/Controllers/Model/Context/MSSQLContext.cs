using Microsoft.EntityFrameworkCore;

namespace RestApiWithAspNet10.Controllers.Model.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options)
        {
        }

    }
}
