using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWhisper.Entities.Concrete;

namespace WordWhisper.Repository.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        bool Login(string username, string password);
    }
}
