using bootcamp_caso_practico_backend.Domain.Entities;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(i => i.Role)
                .WithMany()
                .HasForeignKey(i => i.RoleId)
                .IsRequired();

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
