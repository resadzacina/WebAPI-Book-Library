using System;
using System.Collections.Generic;

namespace Txtr.Platform.Data.Core.Extension
{

    public static class EnumerableExtension
    {
        public static void ForEach<T>( this IEnumerable<T> enumerable, Action<T> action )
        {
            foreach ( T item in enumerable )
            {
                action( item );
            }
        }
    }
}
