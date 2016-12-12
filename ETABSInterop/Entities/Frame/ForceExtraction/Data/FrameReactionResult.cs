using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.Interop.Entities.Frame.ForceExtraction
{
    public class FrameReactionResult
    {
        public double MomentMajorStart { get; set; }
        public double MomentMajorEnd { get; set; }
        public double MomentMinorStart { get; set; }
        public double MomentMinorEnd { get; set; }
        public double ShearMajorStart { get; set; }
        public double ShearMajorEnd { get; set; }
        public double ShearMinorStart { get; set; }
        public double ShearMinorEnd { get; set; }
        public double TorsionStart { get; set; }
        public double TorsionEnd { get; set; }
        public double AxialForceStart { get; set; }
        public double AxialForceEnd { get; set; }
    }
}
