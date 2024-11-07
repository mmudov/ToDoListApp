using Microsoft.EntityFrameworkCore;

namespace ToDoListApp.Models
{
    public class ToDoListAppDbContext : DbContext
    {
        public DbSet<ToDoList> ToDoLists { get; set; }

        public ToDoListAppDbContext(DbContextOptions<ToDoListAppDbContext> options) : base(options) { }
    }
}
