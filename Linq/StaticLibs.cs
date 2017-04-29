using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public static class  StaticLibs
    {
        public static int CountMe<T>(this IEnumerable<T> param)
        {
            int count = 0; 
            foreach ( var item in param)
            {
                count += 1;
            }
            return count; 
        }
    }
}
