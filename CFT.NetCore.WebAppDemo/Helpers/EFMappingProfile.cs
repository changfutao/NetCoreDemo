using AutoMapper;
using CFT.NetCore.WebAppDemo.Entities;
using CFT.NetCore.WebAppDemo.Models;
using CFT.NetCore.WebAppDemo.ViewModels;
using CFT.NetCore.WebAppDemo.Extensions;

namespace CFT.NetCore.WebAppDemo.Helpers
{
    public class EFMappingProfile:Profile
    {
        public EFMappingProfile()
        {
            CreateMap<AuthorDto, Author>();
            CreateMap<Author, AuthorViewModel>().ForMember(dest => dest.Age, config => config.MapFrom(src => src.BirthDate.GetCurrentAge()));
        }
    }
}
