using ApplicationCore.Entities.Data;
using AutoMapper;
using System;
using Web.DTO.DataTransfer;

namespace Web.DTO.MapsConfiguration
{
    public class MenuDtoProfile: Profile
    {
        public MenuDtoProfile()
        {
            FromMenuItemMap();
        }

        public void FromMenuItemMap()
        {
            CreateMap<MenuItem, MenuItemDTO>()
                .ForMember(dest => dest.CookingTime, opts => opts.MapFrom(source => TimeSpan.FromMinutes(source.CookingTime.Value)));
        }
    }
}
