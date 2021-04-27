using System;
using System.Collections.Generic;

namespace Iqt.Base.Extensions
{
    public static class ListExtensions
    {
        public static IEnumerable<List<T>> SplitList<T>(this List<T> locations, int nSize = 2)
        {
            for (int i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }
    }
}
