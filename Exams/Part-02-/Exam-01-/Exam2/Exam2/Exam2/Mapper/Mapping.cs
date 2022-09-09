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
            CreateMap<SubCategory, DetailsItem>().ReverseMap();
            CreateMap<Category, DetailsItem>().ReverseMap();
            CreateMap<Item, DetailsItem>()
                .ForMember(src =>
                    src.ItemId,
                    opt => opt.MapFrom(dest => dest.Id)
                )
                .ForMember(src =>
                    src.ItemName,
                    opt => opt.MapFrom(dest => dest.Name)
                )
                .ForPath(src =>
                    src.SubCategoryName,
                    opt => opt.MapFrom(dest => dest.Sub.Name)
                )
                .ForPath(src =>
                    src.CategoryName,
                    opt => opt.MapFrom(dest => dest.Sub.Cat.Name)
                )
                .ReverseMap();
        }
    }
}
