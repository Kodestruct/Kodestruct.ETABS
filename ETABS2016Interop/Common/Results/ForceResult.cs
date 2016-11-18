using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.v2016.Interop.Entities.Frame.ForceExtraction
{
    public class ForceResult
    {
        public double MomentMajorMax { get; set; }
        public double MomentMajorMin { get; set; }
        public double MomentMinorMax { get; set; }
        public double MomentMinorMin { get; set; }
        public double ShearMajorMax { get; set; }
        public double ShearMajorMin { get; set; }
        public double ShearMinorMax { get; set; }
        public double ShearMinorMin { get; set; }
        public double TorsionMax { get; set; }
        public double TorsionMin { get; set; }
        public double AxialForceMax { get; set; }
        public double AxialForceMin { get; set; }
    }
}
