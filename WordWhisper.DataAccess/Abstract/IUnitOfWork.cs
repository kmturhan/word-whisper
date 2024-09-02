using System;

namespace WordWhisper.DataAccess.Abstract;

public interface IUnitOfWork
{
    IRepository<T> Repository<T>() where T : class;
    int Complete();
}
