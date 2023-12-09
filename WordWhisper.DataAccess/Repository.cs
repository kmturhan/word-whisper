using Microsoft.EntityFrameworkCore;
using WordWhisper.DataAccess.Abstract;
using WordWhisper.DataAccess.Concrete.EntityFramework.Contexts;

namespace WordWhisper.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        WordWhisperContext _context;
        DbSet<T> _object;
        public Repository()
        {
            _object = _context.Set<T>();
        }
        public int Delete(T item)
        {
            _object.Remove(item);
            return _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public int Insert(T item)
        {
            _object.Add(item);
            return _context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public int Update(T item)
        {
            return _context.SaveChanges();
        }
    }
}
