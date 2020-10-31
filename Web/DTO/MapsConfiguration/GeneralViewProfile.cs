using ApplicationCore.Entities.Data;
using AutoMapper;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace Web.DTO.MapsConfiguration
{
    public abstract class GeneralViewProfile: Profile
    {
        protected readonly Expression<Func<MenuItem, string>> formattedCookingTime;
        protected readonly Expression<Func<MenuItem, string>> formattedPrice;
        protected readonly Expression<Func<MenuItem, string>> formattedCalories;
        protected readonly Expression<Func<MenuItem, TimeSpan>> parseCookingTime;

        public GeneralViewProfile()
        {
            formattedCookingTime = source => FormatCookingTime((double)source.CookingTime);
            formattedPrice = source => FormatPrice(source.Price.GetValueOrDefault());
            formattedCalories = source => FormatCalories(source.Calories.GetValueOrDefault(), source.Grams.GetValueOrDefault());
            parseCookingTime = source => ParseCookingTime((double)source.CookingTime.GetValueOrDefault());
        }

        protected virtual string FormatCookingTime(double minutes)
        {
            string result;
            TimeSpan timeSpan = ParseCookingTime(minutes);
            result = FormatCookingTime(timeSpan);
            return result;
        }

        protected virtual string FormatCookingTime(TimeSpan timeSpan)
        {
            string result = string.Empty;
            if (timeSpan.Days != 0)
            {
                result += timeSpan.ToString("%d") + " day";
                result += timeSpan.Days > 1 ? "s " : " ";
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

        protected virtual TimeSpan ParseCookingTime(double minutes)
        {
            TimeSpan timeSpan = TimeSpan.FromMinutes(minutes);
            return timeSpan;
        }

        protected virtual string FormatPrice(decimal price)
        {
            string result = price.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            return result;
        }

        protected virtual string FormatCalories(decimal? calories, int? grams)
        {
            string result;
            calories = Convert.ToDecimal(grams) / 100 * calories;

            result = calories.Value.ToString("######0.#######");
            return result;
        }
    }
}
