using Microsoft.EntityFrameworkCore;

namespace RegistrationAPI.Entities
{
    public class UserDbContext : DbContext
    {
        private string _connectionString = 
            "Host=localhost;Database=RegistrationDb;Username=postgres;Password=1qazXSW@";
        
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(15);
            
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(16);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();
            
            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
        
    }
}