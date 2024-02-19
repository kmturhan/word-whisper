using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWhisper.Entities.Concrete;

namespace WordWhisper.DataAccess.Concrete.EntityFramework.Contexts
{
    public class WordWhisperEFContext : DbContext
    {
        public WordWhisperEFContext(DbContextOptions<WordWhisperEFContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
