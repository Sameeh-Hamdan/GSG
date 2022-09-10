using AutoMapper;
using Exam2.Models;
using Exam2.ModelViews;
using System.Linq;

namespace Exam2.Mapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<DetailsOfItem, DetailsItemDTO>().ReverseMap();
        }
    }
}
