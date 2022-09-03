using System.Collections.Generic;
using System.Linq;
using Task01.Models;

namespace Task01.Extentions
{
    public static class DistinctNames
    {
        public static IEnumerable<User> DistinctByName(this IEnumerable<User> users) => users
                .GroupBy(usr => new { usr.Fname, usr.Lname })
                .Select(g => g.First())
                .ToList();
    }
}
