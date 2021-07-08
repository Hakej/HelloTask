using System;
using System.Collections.Generic;
using System.Linq;
namespace HelloTask.Infrastructure.Extensions
{
    public static class IEnumerableExtensions
    {
        private static readonly Random rnd = new Random();
        private static readonly object sync = new object();

        public static T GetRandomElement<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("Passed IEnumerable is null.");
            }

            var count = enumerable.Count();

            var ndx = 0;
            lock (sync)
                ndx = rnd.Next(count); // returns non-negative number less than max

            return enumerable.ElementAt(ndx);
        }
    }
}
