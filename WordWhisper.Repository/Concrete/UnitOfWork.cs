using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWhisper.DataAccess.Concrete.EntityFramework.Contexts;
using WordWhisper.Repository.Abstract;

namespace WordWhisper.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private WordWhisperEFContext _wordWhisperContext;
        public UnitOfWork(WordWhisperEFContext context, IUserRepository userRepository)
        {
            UserRepository = userRepository;
            _wordWhisperContext = context;
        }
        public IUserRepository UserRepository { get; private set; }

        public int Complete()
        {
            return _wordWhisperContext.SaveChanges();
        }

        public void Dispose()
        {
            _wordWhisperContext.Dispose();
        }
    }
}
