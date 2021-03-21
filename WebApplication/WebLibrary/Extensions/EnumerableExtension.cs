using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebLibrary.Extensions
{
    public static class EnumerableExtension
    {
        public static IEnumerable<TSource> WhereNot<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source.Where(x => !predicate(x));
            // 用法舉例：IEnumerable.WhereNot(x => string.IsNullOrEmpty(x.id))
            // 用法舉例：IEnumerable.WhereNot(x => string.IsNullOrEmpty(x.id) || string.IsNullOrEmpty(x.name))
        }

        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null)
                return true;
            if (source is ICollection<TSource> collectionT)
                return collectionT.Count == 0;
            if (source is IReadOnlyCollection<TSource> readOnlycollection)
                return readOnlycollection.Count == 0;
            if (source is ICollection collection)
                return collection.Count == 0;

            using var iterator = source.GetEnumerator();
            return !iterator.MoveNext();
        }
    }
}
