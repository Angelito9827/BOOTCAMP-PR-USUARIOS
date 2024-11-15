using bootcamp_users_maintenance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bootcamp_users_maintenance.Infraestructure.Persistence
{
    public class UserListContext : DbContext
    {
        public UserListContext(DbContextOptions<UserListContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(i => i.Role+)
                .WithMany()
                .HasForeignKey(i => i.RoleId)
                .IsRequired();

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
