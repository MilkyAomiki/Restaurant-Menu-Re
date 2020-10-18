using ApplicationCore.Entities.Data;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web.DTO.DataDisplay;

namespace Web.Configuration
{
    public class MenuMapperViewDataProfile: Profile
    {
        private Expression<Func<MenuItem, decimal?>> _totalCalories = source => (Convert.ToDecimal(source.Grams) / 100) * source.Calories;
        private Expression<Func<MenuItem, TimeSpan?>> _formattedCookingTime = source => TimeSpan.FromMinutes((double)source.CookingTime);

        public MenuMapperViewDataProfile()
        {
            ToViewDataFormatSubProfile();
        }

        public void ToViewDataFormatSubProfile()
        {
            CreateMap<MenuItem, MenuViewData>()
                 .ForMember(x => x.Calories, opt => opt.MapFrom(_totalCalories))
                 .ForMember(dest => dest.CookingTime, opt => opt.MapFrom(_formattedCookingTime));

        }
    }
}
