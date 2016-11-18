using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.v2016.Interop.Entities.Point
{
    public class EtabsPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public string Name { get; set; }

        public EtabsPoint(string Name)
            :this(Name,0,0,0)
        {
            
        }

        public EtabsPoint(string Name, 
            double X, 
            double Y, 
            double Z 
            )
        {
            this.Name = Name;
            this.X=X;
            this.Y=Y;
            this.Z = Z;

        }
    
    }
}
