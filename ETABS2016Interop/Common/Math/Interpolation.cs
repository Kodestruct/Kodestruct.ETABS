using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.v2016.Interop.Common.Mathematics
{
    public class Interpolation
    {
        public static double InterpolateLinear(double x0, double y0, double x1, double y1, double x)
        {
            //double a = y0 * (x - x1) / (x0 - x1) + y1 * (x - x0) / (x1 - x0);
            double b = y0 + (x - x0) * (y1 - y0) / (x1 - x0);
            return b;
        } 
    }
}
