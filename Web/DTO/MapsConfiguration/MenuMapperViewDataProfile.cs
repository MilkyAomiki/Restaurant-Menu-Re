using ApplicationCore.Entities.Data;
using AutoMapper;
using System;
using System.Linq.Expressions;
using Web.DTO.DataDisplay;

namespace Web.DTO.MapsConfiguration
{
    public class MenuMapperViewDataProfile: Profile
    {
        private readonly Expression<Func<MenuItem, decimal?>> _totalCalories = source => (Convert.ToDecimal(source.Grams) / 100) * source.Calories;
        private readonly Expression<Func<MenuItem, string>> _formattedCookingTime = source => FormatCookingTime((double)source.CookingTime);

        public MenuMapperViewDataProfile()
        {
            ToViewDataFormatSubProfile();
        }

        public void ToViewDataFormatSubProfile()
        {
            CreateMap<MenuItem, MenuViewData>()
                 .ForMember(x => x.Calories, opts => opts.MapFrom(_totalCalories))
                 .ForMember(dest => dest.CookingTime, opts => opts.MapFrom(_formattedCookingTime));
        }

        private static string FormatCookingTime(double minutes)
        {
            string result = string.Empty;
            TimeSpan timeSpan = TimeSpan.FromMinutes(minutes);
            if (timeSpan.Days != 0)
            {
                result += timeSpan.ToString("%d") + " day";
                result += timeSpan.Days > 1? "s " : " ";
            }
            if (timeSpan.Hours != 0)
            {
                result += timeSpan.ToString("%h") + " hour";
                result += timeSpan.Hours > 1 ? "s " : " ";
            }
            if (timeSpan.Minutes != 0)
            {
                result += timeSpan.ToString("%m") + " minute";
                result += timeSpan.Minutes > 1 ? "s " : " ";
            }
            if (timeSpan.Seconds != 0)
            {
                result += timeSpan.ToString("%s") + " second";
                result += timeSpan.Seconds > 1 ? "s " : " ";
            }
            return result;
        }
    }
}
