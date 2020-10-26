using ApplicationCore.Entities.Data;
using AutoMapper;
using Web.DTO.DataTransfer;

namespace Web.DTO.MapsConfiguration
{
    public class MenuItemProfile: Profile
    {
        public MenuItemProfile()
        {
            FromMenuItemDtoMap();
        }

        public void FromMenuItemDtoMap()
        {
            CreateMap<MenuItemDTO, MenuItem>()
                .ForMember(dest => dest.CookingTime, opts => opts.MapFrom(source => source.CookingTime.TotalMinutes));
        }
    }
}
