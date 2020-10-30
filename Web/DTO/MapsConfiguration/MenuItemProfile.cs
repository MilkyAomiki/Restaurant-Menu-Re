using ApplicationCore.Entities.Data;
using AutoMapper;
using System;
using System.Linq.Expressions;
using Web.DTO.DataTransfer;

namespace Web.DTO.MapsConfiguration
{
    public class MenuItemProfile: Profile
    {
        public MenuItemProfile()
        {
            FromMenuItemDtoMap();
            FromNewItemViewDtoMap();
        }

        public void FromMenuItemDtoMap()
        {
            CreateMap<MenuItemDTO, MenuItem>()
                .ForMember(dest => dest.CookingTime, opts => opts.MapFrom(source => source.CookingTime.TotalMinutes));
        }

        public void FromNewItemViewDtoMap()
        {
            CreateMap<NewItemViewDTO, MenuItem>()
                .ForMember(dest => dest.CookingTime, opts => opts.MapFrom(source => source.CookingTime.TotalMinutes));
        }
    }
}
