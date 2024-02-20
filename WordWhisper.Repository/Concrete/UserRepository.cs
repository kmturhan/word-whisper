using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWhisper.DataAccess.Concrete.EntityFramework.Contexts;
using WordWhisper.Entities.Concrete;
using WordWhisper.Infrastructer;
using WordWhisper.Repository.Abstract;

namespace WordWhisper.Repository.Concrete
{
    public class UserRepository : GeneralRepository<User>, IUserRepository
    {
        private readonly IPasswordHasher _passwordHasher;
        public UserRepository(IPasswordHasher passwordHasher, WordWhisperEFContext context) : base(context)
        {
            _passwordHasher = passwordHasher;
        }

        public void Register(User user)
        {
            user.Password = _passwordHasher.Hash(user.Password);
            Add(user);
        }
        public User Login(string username, string password)
        {
            var user = _context.Set<User>().FirstOrDefault(x => x.IsActive && x.Username == username);
            
            if(user == null)
            {
                throw new Exception("User is not found or user is not active!");
            }

            var result = _passwordHasher.Verify(user.Password, password);
            
            if(!result)
            {
                throw new Exception("Username or Password is not correct!");
            }
            return user;   
        }

        
    }
}
