using System.Threading.Tasks;

namespace Practice02.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase,new()
    {
        Task AddAsync(T entity);
    }
}
