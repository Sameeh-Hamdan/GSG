using Restaurants.Models;
using System.Collections.Generic;

namespace Restaurants.Extentions
{
    public static class CapitalizeFirstLetter
    {
        public static string Capitalize(this string str)
        {
            if (str.Length == 0)
                return str;
            else if (str.Length == 1)
                return char.ToUpper(str[0]).ToString();
                
            else
                return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
