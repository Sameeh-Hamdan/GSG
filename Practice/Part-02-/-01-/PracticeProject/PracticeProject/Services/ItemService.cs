using AutoMapper;
using PracticeProject.DTOs.Item;
using PracticeProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace PracticeProject.Services
{
    public class ItemService:IItemService
    {
        private readonly Practice_DBContext _dbContext;
        private readonly IMapper _mapper;
        public ItemService(Practice_DBContext dBContext,IMapper mapper)
        {
            _dbContext=dBContext;
            _mapper=mapper;
        }

        public List<DetailsOfItemDTO> GetDetailsOfItems()
        {
            var detailsOfItems = _dbContext.DetailsOfItems.ToList();
            return _mapper.Map<List<DetailsOfItemDTO>>(detailsOfItems);
        }

        public User AddItem(AddItemDTO addItemDTO)
        {
            return null;
        }
    }
}
