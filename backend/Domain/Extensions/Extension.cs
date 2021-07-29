using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extensions
{
    public static class Extension
    {
        public static bool IsNull<T>(this T obj)
        {
            return obj == null;
        }
    }
}
