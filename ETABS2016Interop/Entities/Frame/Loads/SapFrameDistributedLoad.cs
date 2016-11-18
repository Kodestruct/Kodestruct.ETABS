using Kodestruct.ETABS.v2016.Interop.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.v2016.Interop.Entities.Frame.Loads
{
    public class SapFrameDistributedLoad
    {
        public string CaseName { get; set; }
        public double Value { get; set; }
        public FrameDistributedLoadDirection Direction { get; set; }
        public bool IsMoment { get; set; }

        double Dist1 { get; set; }
        double Dist2 { get; set; }
        double Val1 { get; set; }
        double Val2 { get; set; }
        string CSys { get; set; }
        bool RelDist { get; set; }
        bool Replace { get; set; }

    }
}
