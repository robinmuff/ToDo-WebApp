using Microsoft.EntityFrameworkCore;
using ToDo_WebApp.Class;

namespace ToDo_WebApp.DB
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions options) : base(options)
        {
        }

        protected TaskDBContext()
        {
        }
        public DbSet<Class.Task> TodoItems { get; set; }
    }
}
