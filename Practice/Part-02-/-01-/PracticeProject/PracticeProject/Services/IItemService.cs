using PracticeProject.DTOs.Item;
using PracticeProject.Models;
using System.Collections.Generic;

namespace PracticeProject.Services
{
    public interface IItemService
    {
        public List<DetailsOfItemDTO> GetDetailsOfItems();
        public User AddItem(AddItemDTO addItemDTO);
    }
}
