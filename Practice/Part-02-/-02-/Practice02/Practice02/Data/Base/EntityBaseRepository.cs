using AutoMapper;
using Practice02.Models;
using System.Threading.Tasks;

namespace Practice02.Data.Base
{
    public class EntityBaseRepository<T>
        :IEntityBaseRepository<T> where T: class,
        IEntityBase,
        new()
    {
        private readonly Practice02DBContext _dbContext;

        public EntityBaseRepository(Practice02DBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
