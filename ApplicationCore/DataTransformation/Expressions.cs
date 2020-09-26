using ApplicationCore.Entities.Data;
using ApplicationCore.Entities.DataRepresentation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.DataTransformation
{
    public static class Expressions
    {
        public static List<Expression<Func<MenuItem, bool>>> GenerateComparisonExpressions(SearchData searchItem)
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
                        if (searchItem.CookingTime == null) break;
                        var unformatted = (int)searchItem.CookingTime.Value.TotalMinutes;
                        expr = (MenuItem item) => item.CookingTime.Value == unformatted;
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
    }
}
