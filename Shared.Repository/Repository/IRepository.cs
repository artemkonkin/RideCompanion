using Shared.Core.Entities;

namespace Shared.Repository.Repository;

public interface IRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll();
    T Get(Guid id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
}