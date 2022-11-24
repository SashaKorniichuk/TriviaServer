using Microsoft.EntityFrameworkCore;
using Trivia.DAL.Entity;

namespace Trivia.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<GameplayRoom> GameplayRooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Player>()
            //.HasOne(p => p.GameplayRoom)
            //.WithMany(t => t.Players)
            //.OnDelete(DeleteBehavior.Cascade);
        }
    }
}
