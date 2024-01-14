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
        public WordWhisperEFContext WWContext { get { return _context as WordWhisperEFContext;  } }
        public UserRepository(WordWhisperEFContext context):base(context)
        {
            
        }
        public bool Login()
        {
            var list = WWContext.Users.ToList();
            return true;
        }
    }
}
