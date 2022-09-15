using Restaurants.Models;
using System.Collections.Generic;

namespace Restaurants.Extentions
{
    public static class CapitalizeFirstLetter
    {
        public static void Capitalize(this string str)
        {
            if (str.Length == 0) {
                return;
            }
            else if (str.Length == 1) {
                char.ToUpper(str[0]).ToString();
            }
            else {
                _ = char.ToUpper(str[0]) + str.Substring(1);
            }
        }
    }
}
