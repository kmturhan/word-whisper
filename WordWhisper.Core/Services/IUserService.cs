using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWhisper.Core.Models;

namespace WordWhisper.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User newArtist);
        Task UpdateUser(User artistToBeUpdated, User artist);
        Task DeleteUser(User artist);
    }
}
