using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ObjectBusiness
{
    public class BookContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<CategoryBook> CategoryBooks { get; set; }
        public virtual DbSet<AccessLog> AccessLog { get; set; }
        public virtual DbSet<Decentralization> Decentralizations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add data table Role
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Staff" },
                new Role { RoleId = 3, RoleName = "User" }
                );

            // Add data table Account
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 781404488,
                    Address = "Anonymous",
                    Region = "Security",
                    FullName = "Anonymous",
                    Email = "anonymous@gmail.com",
                    City = "Security",
                    Gender = true,
                    PhoneNumber = "0911040107"
                }
                );

            // Add data table Account
            modelBuilder.Entity<Account>().HasData(
                new Account { AccountId = 92687906, Password = "Admin@123.cntt", UserId = 781404488, UserName = "ADMIN", Star = 5 }
                );

            // Add data table Decentralization
            modelBuilder.Entity<Decentralization>().HasData(
                new Decentralization { DecentralizationId = 996554186, AccountId = 92687906, RoleId = 1 }
                );
        }
    }
}
