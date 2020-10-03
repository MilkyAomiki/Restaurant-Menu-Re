using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Web.DTO
{
    
    public class GenericMapper<T, R> where R: class, new() 
                                     where T: class
    {
        public R Map(T from)
        {
            R to;
            to = new R();
            var fromProps = from.GetType().GetProperties();
            var toProps = to.GetType().GetProperties();
            for (int i = 0; i < toProps.Length; i++)
            {
                for (int j = 0; j < fromProps.Length; j++)
                {
                    if (toProps[i].Name == fromProps[j].Name && toProps[i].PropertyType == fromProps[j].PropertyType)
                    {
                    }
                }
            }
            


            return to;
        }
    }
}
