using Microsoft.EntityFrameworkCore;
using WordWhisper.DataAccess.Abstract;
using WordWhisper.DataAccess.Concrete.EntityFramework.Contexts;

namespace WordWhisper.DataAccess.Concrete.Repository;

public class GeneralRepository<T> : IRepository<T> where T : class
{
    private readonly WordWhisperEFContext _context;
    private readonly DbSet<T> _dbSet;
    public GeneralRepository(WordWhisperEFContext context) 
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if(entity != null) {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T p)
    {
        try {
            await _dbSet.AddAsync(p);
            await _context.SaveChangesAsync();
        }
        catch(Exception ex) {

        }
    }

    public async Task<IEnumerable<T>> ListAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task UpdateAsync(T p)
    {
        _dbSet.Update(p);
        await _context.SaveChangesAsync();
    }
    public int Complete()
    {
        return _context.SaveChanges();
    }
}
