using System;
using WordWhisper.DataAccess.Abstract;
using WordWhisper.DataAccess.Concrete.EntityFramework.Contexts;

namespace WordWhisper.DataAccess.Concrete.Repository;

public class UnitOfWork : IDisposable
{
    private readonly WordWhisperEFContext _context;
    private readonly Dictionary<Type, object> _repositories;
    public UnitOfWork(WordWhisperEFContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    public IRepository<T> Repository<T>() where T : class 
    {
        if (_repositories.ContainsKey(typeof(T)))
        {
            return (IRepository<T>)_repositories[typeof(T)];
        }
        var repository = new GeneralRepository<T>(_context);
        _repositories.Add(typeof(T), repository);

        return repository;
    }
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
