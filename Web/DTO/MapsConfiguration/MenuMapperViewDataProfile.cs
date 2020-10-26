using ApplicationCore.Entities.Data;
using AutoMapper;
using System;
using System.Globalization;
using System.Linq.Expressions;
using Web.DTO.DataDisplay;

namespace Web.DTO.MapsConfiguration
{
    public class MenuMapperViewDataProfile: Profile
    {
        private readonly Expression<Func<MenuItem, string>> _formattedCookingTime = source => FormatCookingTime((double)source.CookingTime);
        private readonly Expression<Func<MenuItem, string>> _formattedPrice = source => FormatPrice(source.Price.Value);
        private readonly Expression<Func<MenuItem, string>> _formattedCalories = source => FormatCalories(source.Calories.Value, source.Grams.Value);

        public MenuMapperViewDataProfile()
        {
            ToViewDataFormatSubProfile();
        }

        public void ToViewDataFormatSubProfile()
        {
            CreateMap<MenuItem, MenuViewData>()
                 .ForMember(dest => dest.CookingTime, opts => opts.MapFrom(_formattedCookingTime))
                 .ForMember(dest => dest.Price, opts => opts.MapFrom(_formattedPrice))
                 .ForMember(dest => dest.Calories, opts => opts.MapFrom(_formattedCalories));
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

        private static string FormatPrice(decimal price)
        {
            string result = price.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));

            return result;
        }

        private static string FormatCalories(decimal calories, int grams)
        {
            calories = Convert.ToDecimal(grams) / 100 * calories;

            string result;
            result = calories.ToString("######0.#######");
            return result;
        }
    }
}
