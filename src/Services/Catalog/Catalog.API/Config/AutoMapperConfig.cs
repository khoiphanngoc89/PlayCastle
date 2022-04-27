using AutoMapper;
using Catalog.API.Entities;
using Catalog.API.Models;

namespace Catalog.API.Config
{
    public class CatalogProfile : Profile
    {
        public CatalogProfile()
        {
            CreateMap<Item, PlayCastleItemDto>();
            CreateMap<CreatePlayCastleItemDto, PlayCastleItemDto>();
            CreateMap<UpdatePlayCastleItemDto, PlayCastleItemDto>();
            CreateMap<CreatePlayCastleItemDto, Item>()
                .AfterMap((src, des) =>
                {
                    des.Id = Guid.NewGuid();
                });
            CreateMap<UpdatePlayCastleItemDto, Item>();
        }
    }
}
