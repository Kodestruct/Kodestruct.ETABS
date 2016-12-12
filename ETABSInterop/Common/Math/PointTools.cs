using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.Interop.Common.Mathematics
{
    public class PointTools
    {
        public static double DistanceBetweenPoints(Point3D PointI, Point3D PointJ)
        {
            double dx = AbsDxBetweenPoints(PointI,PointJ);
            double dy = AbsDyBetweenPoints(PointI,PointJ);
            double dz = AbsDzBetweenPoints(PointI,PointJ);

            return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2) + Math.Pow(dz, 2));
        }
        public static double AbsDxBetweenPoints(Point3D PointI, Point3D PointJ)
        {
            return Math.Abs(PointJ.X - PointI.X);
        }
        public static double AbsDyBetweenPoints(Point3D PointI, Point3D PointJ)
        {
            return Math.Abs(PointJ.Y - PointI.Y);
        }
        public static double AbsDzBetweenPoints(Point3D PointI, Point3D PointJ)
        {
            return Math.Abs(PointJ.Z - PointI.Z);
        }
    }
}
