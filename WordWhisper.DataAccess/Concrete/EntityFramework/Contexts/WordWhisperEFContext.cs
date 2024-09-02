using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWhisper.Domain;
namespace WordWhisper.DataAccess.Concrete.EntityFramework.Contexts
{
    public class WordWhisperEFContext : DbContext
    {
        public WordWhisperEFContext(DbContextOptions<WordWhisperEFContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=WordWhisper;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
