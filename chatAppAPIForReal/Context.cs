using ChatAppMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace chatAppAPIForReal
{
    public class Context : DbContext
    {
        private const string connectionString = "server=localhost;port=3306;database=chatappapidb;user=root;password=itai190901";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, MariaDbServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(t => t.Id);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> messages { get; set; }

        public DbSet<Chat> chats { get; set; }

    }
}
