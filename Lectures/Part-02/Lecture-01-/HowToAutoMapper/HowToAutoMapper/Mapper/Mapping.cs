using AutoMapper;
using HowToAutoMapper.ModelViews;

namespace HowToAutoMapper.Mapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<WeatherForecast,Weather>().ForMember(w=>w.DateFromMap,wf=>wf.MapFrom(w=>w.Date)).ReverseMap();
        }
    }
}
