using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.Interop.Common.Mathematics
{
    public class Point2D
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        
        public Point2D()
        {

        }

        public Point2D(string Name, double X, double Y)
        {
            this.Name = Name;
            this.X = X;
            this.Y = Y;
        }

        public Point2D(double X, double Y): this("", X,Y)
        {

        }
    }
}
