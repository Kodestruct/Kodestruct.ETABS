using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.Interop.Common.Mathematics
{
    public class Point3D
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        
        public Point3D()
        {

        }

        public Point3D(string Name, double X, double Y, double Z)
        {
            this.Name = Name;
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public Point3D(double X, double Y, double Z): this("", X,Y,Z)
        {

        }
    }
}
