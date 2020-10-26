using ApplicationCore.Entities.Data;
using Web.DTO.DataDisplay;

namespace Web.DTO.MapsConfiguration
{
    public class MenuViewProfile: GeneralViewProfile
    { 
        public MenuViewProfile()
        {
            FromMenuItemMap();
        }

        public void FromMenuItemMap()
        {
            CreateMap<MenuItem, MenuViewData>()
                 .ForMember(dest => dest.CookingTime, opts => opts.MapFrom(formattedCookingTime))
                 .ForMember(dest => dest.Price, opts => opts.MapFrom(formattedPrice))
                 .ForMember(dest => dest.Calories, opts => opts.MapFrom(formattedCalories));
        }
    }
}
