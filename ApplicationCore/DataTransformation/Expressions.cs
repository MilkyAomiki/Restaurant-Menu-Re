using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.DataTransformation
{
    public static class Expressions
    {
        public static List<Expression<Func<MenuItem, bool>>> GenerateComparisonExpressions(MenuItem searchItem)
        {
            List<Expression<Func<MenuItem, bool>>> expressions = new List<Expression<Func<MenuItem, bool>>>();
            var properties = searchItem.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                Expression<Func<MenuItem, bool>> expr;
                switch (properties[i].Name)
                {
                    case "Title":
                        if (searchItem.Title == default) break;
                        expr = (MenuItem item) => item.Title.Contains(searchItem.Title);
                        expressions.Add(expr);
                        break;
                    case "Description":
                        if (searchItem.Description == default) break;
                        expr = (MenuItem item) => item.Description.Contains(searchItem.Description);
                        expressions.Add(expr);
                        break;
                    case "Ingredients":
                        if (searchItem.Ingredients == default) break;
                        expr = (MenuItem item) => item.Ingredients.Contains(searchItem.Ingredients);
                        expressions.Add(expr);
                        break;
                    case "Grams":
                        if (searchItem.Grams == default) break;
                        expr = (MenuItem item) => item.Grams.Value == (searchItem.Grams).Value;
                        expressions.Add(expr);
                        break;
                    case "Calories":
                        if (searchItem.Calories == default) break;
                        expr = (MenuItem item) => (Convert.ToDecimal(item.Grams.Value) / 100) * item.Calories.Value == (searchItem.Calories).Value;
                        expressions.Add(expr);
                        break;
                    case "CookingTime":
                        if (searchItem.CookingTime == default && searchItem.CookingTimeFormatted == default) break;
                        if (searchItem.CookingTime == default) searchItem.CookingTime = (int)searchItem.CookingTimeFormatted.TotalMinutes;
                        expr = (MenuItem item) => item.CookingTime.Value == searchItem.CookingTime.Value;
                        expressions.Add(expr);
                        break;
                    case "Price":
                        if (searchItem.Price == default) break;
                        expr = (MenuItem item) => item.Price.Value == (searchItem.Price).Value;
                        expressions.Add(expr);
                        break;
                    case "CreationDate":
                        if (searchItem.CreationDate == default) break;
                        expr = (MenuItem item) => item.CreationDate.CompareTo(searchItem.CreationDate) == 0;
                        expressions.Add(expr);
                        break;
                }
            }

            return expressions;
        }

        public static Expression<Func<MenuItem, MenuItem>> GenerateTransformationExpression()
        {
            Expression<Func<MenuItem, MenuItem>> expression = x => new MenuItem
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Ingredients = x.Ingredients,
                Grams = x.Grams,
                Calories = (Convert.ToDecimal(x.Grams) / 100) * x.Calories,
                Price = x.Price,
                CookingTime = x.CookingTime,
                CreationDate = x.CreationDate,
                CookingTimeFormatted = TimeSpan.FromMinutes((double)x.CookingTime)
            };

            return expression;
        }
    }
}
