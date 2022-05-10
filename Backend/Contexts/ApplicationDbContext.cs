using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Contexts
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Todo> Todo { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
