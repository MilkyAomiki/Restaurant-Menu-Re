using ApplicationCore.Entities.Data;
using System;
using System.Globalization;
using System.Linq.Expressions;
using Web.DTO.DataDisplay;
using Web.DTO.DataTransfer;

namespace Web.DTO.MapsConfiguration
{

    public class ItemViewProfile: GeneralViewProfile
    {
        private readonly string CurrencySymbol = new RegionInfo("en-US").ISOCurrencySymbol;
        
        protected readonly Expression<Func<MenuItemDTO, string>> formattedCaloriesOrNull;
        protected readonly Expression<Func<MenuItemDTO, string>> formattedPriceOrNull;

        public ItemViewProfile()
        {
            formattedCaloriesOrNull = source => source.Calories.HasValue && source.Grams.HasValue? FormatCalories(source.Calories.Value, source.Grams.Value): "";
            formattedPriceOrNull = source => source.Price.HasValue ? FormatPrice(source.Price.Value) : "";
            FromMenuItemMap();
            FromMenuItemDtoMap();
        }

        public void FromMenuItemMap()
        {
            CreateMap<MenuItem, ItemViewData>()
                 .ForMember(dest=>dest.CookingTime, opts=> opts.MapFrom(parseCookingTime))
                 .ForMember(dest => dest.CookingTimeF, opts => opts.MapFrom(formattedCookingTime))
                 .ForMember(dest => dest.PriceF, opts => opts.MapFrom(formattedPrice))
                 .ForMember(dest => dest.CaloriesF, opts => opts.MapFrom(formattedCalories))
                 .ForMember(dest => dest.CurrencySymbol, opts => opts.MapFrom(x=>CurrencySymbol));
        }

        public void FromMenuItemDtoMap()
        {
            CreateMap<MenuItemDTO, ItemViewData>()
                 .ForMember(dest => dest.CookingTimeF, opts => opts.MapFrom(source => FormatCookingTime(source.CookingTime)))
                 .ForMember(dest => dest.PriceF, opts => opts.MapFrom(formattedPriceOrNull))
                 .ForMember(dest => dest.CaloriesF, opts => opts.MapFrom(formattedCaloriesOrNull))
                 .ForMember(dest => dest.CurrencySymbol, opts => opts.MapFrom(x => CurrencySymbol));
        }
    }
}
