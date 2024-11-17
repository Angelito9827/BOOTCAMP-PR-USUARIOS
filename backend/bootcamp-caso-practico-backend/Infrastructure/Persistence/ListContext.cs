using Microsoft.EntityFrameworkCore;

namespace bootcamp_caso_practico_backend.Infrastructure.Persistence
{
    public class ListContext : DbContext
    {
        public ListContext(DbContextOptions<ListContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
