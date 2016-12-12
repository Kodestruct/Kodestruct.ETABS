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

namespace Kodestruct.ETABS.Interop.Common.Mathematics
{
    public class MinMax
    {
        public static double Minumum(List<double> NumberList)
        {
            double MinVal = double.PositiveInfinity;
            foreach (double num in NumberList)
            {
                MinVal = num < MinVal ? num : MinVal;
            }
            return MinVal;
        }

          public static double Maximum(List<double> NumberList)
        {
            double MaxVal = double.NegativeInfinity;
            foreach (double num in NumberList)
            {
                MaxVal = num > MaxVal ? num : MaxVal;
            }
            return MaxVal;
        }
    }
}
