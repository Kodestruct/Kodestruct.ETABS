using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.v2016.Interop.Entities.Point
{
    public class EtabsNode : EtabsPoint
    {

        public EtabsNode(string Name,
        double X,
        double Y,
        double Z
        )
            : base(Name, X, Y, Z)
        {
        }
    }
}
