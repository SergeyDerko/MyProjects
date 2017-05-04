using System.Data.Entity;
namespace Test.Models
{
    public class Context : DbContext
    {
        public Context(): base("DefaultConnection"){}
    }

    public class UsersContext : Context
    {
        public DbSet<User> Users { get; set; }
    }
}