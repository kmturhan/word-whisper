using Microsoft.EntityFrameworkCore;

namespace WordWhisper.Web.Models
{
    public class WordWhisperApplicationContext : DbContext
    {
        public WordWhisperApplicationContext(DbContextOptions<WordWhisperApplicationContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(AppSetting.ConnectionString);
        }
        public DbSet<User> Users { get; set; }
    }
}
