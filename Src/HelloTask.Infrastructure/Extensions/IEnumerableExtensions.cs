using System;
using System.Collections.Generic;
using System.Linq;
namespace HelloTask.Infrastructure.Extensions
{
    public static class IEnumerableExtensions
    {
        private static readonly Random Rnd = new();
        private static readonly object Sync = new();

        public static T GetRandomElement<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable),"Passed IEnumerable is null.");
            }

            var count = enumerable.Count();

            var ndx = 0;
            lock (Sync)
                ndx = Rnd.Next(count); // returns non-negative number less than max

            return enumerable.ElementAt(ndx);
        }
    }
}
