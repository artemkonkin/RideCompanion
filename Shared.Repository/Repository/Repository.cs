using Microsoft.EntityFrameworkCore;
using Shared.Core.Entities;
using Shared.Migrations;

namespace Shared.Repository.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _entities;

    public Repository(ApplicationDbContext context)
    {
        this._context = context;
        _entities = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _entities.AsEnumerable();
    }

    public T Get(Guid id)
    {
        return _entities.SingleOrDefault(s => s.Id == id) ?? throw new InvalidOperationException();
    }

    public void Insert(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _entities.Add(entity);
        _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        _context.SaveChangesAsync();
    }

    public void Delete(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        _entities.Remove(entity);
        _context.SaveChangesAsync();
    }
}