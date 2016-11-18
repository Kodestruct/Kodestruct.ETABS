using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.v2016.Interop.Common.Mathematics
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
