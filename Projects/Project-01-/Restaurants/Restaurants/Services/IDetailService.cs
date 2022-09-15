using Restaurants.ModelViews.Details;
using System.Collections.Generic;

namespace Restaurants.Services
{
    public interface IDetailService
    {
        public List<GetDetailsView> GetDetails();
    }
}
