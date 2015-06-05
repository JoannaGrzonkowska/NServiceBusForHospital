using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Shared.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Func<T,bool> selectorParam)
        {
            foreach(var elem in list)
            {
                if(selectorParam(elem))
                {
                    yield return elem;
                }
            }
        }
    }
}
