using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWhisper.Core.Models;
using WordWhisper.Core.Repositories;
using WordWhisper.DataAccess.Concrete.EntityFramework.Contexts;

namespace WordWhisper.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private WordWhisperContext WordWhisperContext { get { return Context as WordWhisperContext; } }
        public UserRepository(WordWhisperContext context) : base(context)
        {

        }
        
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await WordWhisperContext.Users
                .Include(m => m.Username).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await WordWhisperContext.Users
                .Include(m => m.Username)
                .SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}
