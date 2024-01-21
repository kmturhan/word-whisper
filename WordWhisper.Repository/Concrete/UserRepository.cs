using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWhisper.DataAccess.Concrete.EntityFramework.Contexts;
using WordWhisper.Entities.Concrete;
using WordWhisper.Repository.Abstract;

namespace WordWhisper.Repository.Concrete
{
    public class UserRepository : GeneralRepository<User>, IUserRepository
    {
        public UserRepository(WordWhisperEFContext context) : base(context)
        {
        }

        public void Register(User user)
        {

        }
        public bool Login(string username, string password)
        {
            var isLogin = GetAll().FirstOrDefault(x => x.IsActive && x.Username == username && x.Password == password);
            
            if (isLogin != null)
                return true;
            

            return false;
        }
    }
}
