using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Infrastructure
{
    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderBy(ToLambda<T>(propertyName));
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderByDescending(ToLambda<T>(propertyName));
        }

        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> source, List<Expression<Func<T, bool>>> expressions)
        {

            for (int i = 0; i < expressions.Count; i++)
            {
                source = source.Where(expressions[i]);
            }

            return source;
        }

        public static IOrderedQueryable<T> OrderByKey<T>(this IQueryable<T> source, string propertyName, string key)
        {

            if (key.ToLower() == "asc") source = source.OrderBy(propertyName); 
            else if (key.ToLower() == "desc") source = source.OrderByDescending(propertyName);
            else
            {
                throw new Exception($"{key} is a not correct key for the OrderByKey(..) operation");
            }

            return (IOrderedQueryable<T>)source;
        }
    }
}
