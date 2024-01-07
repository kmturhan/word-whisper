using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using WordWhisper.Core.Models;
using WordWhisper.DataAccess.Configuration;

namespace WordWhisper.DataAccess.Concrete.EntityFramework.Contexts
{
    public class WordWhisperContext : DbContext
    {
        public WordWhisperContext(DbContextOptions<WordWhisperContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new UserConfiguration());
        }
    }
}
