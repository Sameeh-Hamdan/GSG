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
        private readonly IMapper _mapper;

        public EntityBaseRepository(Practice02DBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task AddAsync(T entity)
        {
            //var user = _mapper.Map<entity>(userRegistrationDTO);
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
