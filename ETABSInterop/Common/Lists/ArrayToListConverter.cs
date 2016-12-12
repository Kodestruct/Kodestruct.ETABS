using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.Interop.Common.Lists
{
    public class ArrayToListConverter
    {

        public static List<T> Convert<T>(Array Array)
        {
            //Type ArrayType = typeof(T);
            List<T> valList = new List<T>();

            IEnumerable<T> EnumeratedList = Array.Cast<T>().Select(item => item);


            foreach (var listItem in EnumeratedList)
            {
                valList.Add(listItem);
            }

            return valList;
        }
    }
}
