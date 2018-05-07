using System;
using System.Collections.Generic;
using System.Linq;

namespace Random11.Extensions
{
    public static class ListExtensions
    {
        public static IEnumerable<T> RandomItems<T>(this IEnumerable<T> items, int noOfItems)
        {
            var random = new Random();
            return items.OrderBy(y => random.Next()).Take(noOfItems);
        }

        public static T RandomItem<T>(this IEnumerable<T> items)
        {
            var random = new Random();
            return items.OrderBy(y => random.Next()).Take(1).First();
        }
    }
}
