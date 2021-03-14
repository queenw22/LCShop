using API.Dtos;
using AutoMapper;
using Core.EntitiesDb;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Item, ItemToReturnDto>()
                .ForMember(d => d.ItemBrand, o => o.MapFrom(s => s.ItemBrand.Name))
                .ForMember(d => d.ItemType, o => o.MapFrom(s => s.ItemType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ItemUrlResolver>());
        }
    }
}