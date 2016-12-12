#region Copyright
   /*Copyright (C) 2015 Konstantin Udilovich

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
   */
#endregion
 
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
