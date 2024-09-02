using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWhisper.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        Task AddAsync(T p);
        Task UpdateAsync(T p);
        Task DeleteAsync(int p);
        Task<IEnumerable<T>> ListAsync();
        Task<T> GetByIdAsync(int id);
    }
}
