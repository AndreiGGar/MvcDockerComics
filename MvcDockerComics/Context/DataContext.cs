using Microsoft.EntityFrameworkCore;
using MvcDockerComics.Models;

namespace MvcDockerComics.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Comic> Comics { get; set; }
    }
}
