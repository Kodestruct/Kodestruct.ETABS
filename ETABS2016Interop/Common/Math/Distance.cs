using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.v2016.Interop.Common.Mathematics
{
    public class Distance
    {
        private double dx;

        public double DeltaX
        {
            get { return dx; }
            set { dx = value; }
        }
        private double dy;

        public double DeltaY
        {
            get { return dy; }
            set { dy = value; }
        }
        private double dz;

        public double DeltaZ
        {
            get { return dz; }
            set { dz = value; }
        }
        

        public double AbsoluteDistance
        {
            get { return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2) + Math.Pow(dz, 2)); ; }
        }


        public Distance(Point3D PointI, Point3D PointJ)
        {
            dx = PointTools.AbsDxBetweenPoints(PointI, PointJ);
            dy = PointTools.AbsDyBetweenPoints(PointI, PointJ);
            dz = PointTools.AbsDzBetweenPoints(PointI, PointJ);

        }
    }
}
