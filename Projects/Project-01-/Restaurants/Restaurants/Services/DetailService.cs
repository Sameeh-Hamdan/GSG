using AutoMapper;
using Restaurants.Models;
using Restaurants.ModelViews.Details;
using System.Collections.Generic;
using System.Linq;

namespace Restaurants.Services
{
    public class DetailService:IDetailService
    {
        private readonly restaurantdbTestContext _context;
        private readonly IMapper _mapper;
        public DetailService(restaurantdbTestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetDetailsView> GetDetails()
        {
            var details = _context.Details.ToList();
            var detailsView = _mapper.Map<List<GetDetailsView>>(details);
            return detailsView;
        }
    }
}
