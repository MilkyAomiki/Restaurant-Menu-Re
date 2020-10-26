using ApplicationCore.Entities.Data;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO.DataTransfer;

namespace Web.DTO.MapsConfiguration
{
    public class MenuMapperDtoProfile: Profile
    {
        public MenuMapperDtoProfile()
        {
            MenuItemSubProfile();
            MenuItemDtoSubProfile();
        }

        public MenuMapperDtoProfile(string profileName) : base(profileName)
        {
        }

        public MenuMapperDtoProfile(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction)
        {
        }

        public void MenuItemSubProfile()
        {
            CreateMap<MenuItem, MenuItemDTO>();
        }
        public void MenuItemDtoSubProfile()
        {
            CreateMap<MenuItemDTO, MenuItem>();
        }
    }
}
