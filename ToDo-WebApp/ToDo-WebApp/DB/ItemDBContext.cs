using Microsoft.EntityFrameworkCore;
using ToDo_WebApp.Class;

namespace ToDo_WebApp.DB
{
    public class ItemDBContext : DbContext
    {
        public ItemDBContext(DbContextOptions options) : base(options)
        {
        }

        protected ItemDBContext()
        {
        }
        public DbSet<Class.Task> TodoItems { get; set; }
    }
}