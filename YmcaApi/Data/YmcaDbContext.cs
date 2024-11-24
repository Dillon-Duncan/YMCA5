using Microsoft.EntityFrameworkCore;

namespace YmcaApi.Data
{
    public class YmcaDbContext : DbContext
    {
        public YmcaDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Bulletin> Bulletins { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}