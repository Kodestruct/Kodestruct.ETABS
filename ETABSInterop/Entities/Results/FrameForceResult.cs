using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.Interop.Entities.Results
{
    public class FrameForceResult
    {
        public double MomentMajorMax { get; set; }
        public double MomentMajorMin { get; set; }

        public double MomentMinorMax { get; set; }
        public double MomentMinorMin { get; set; }

        public double ShearMajorMax { get; set; }
        public double ShearMajorMin { get; set; }

        public double ShearMinorMax { get; set; }
        public double ShearMinorMin { get; set; }


        public double AxialForceMaximum { get; set; }
        public double AxialForceMininum { get; set; }

        public double TorsionMax { get; set; }
        public double TorsionMin { get; set; }

        public string MomentMajorMaxCaseName { get; set; }
        public string MomentMajorMinCaseName { get; set; }

        public string MomentMinorMaxCaseName { get; set; }
        public string MomentMinorMinCaseName { get; set; }

        public string ShearMajorMaxCaseName { get; set; }
        public string ShearMajorMinCaseName { get; set; }

        public string ShearMinorMaxCaseName { get; set; }
        public string ShearMinorMinCaseName { get; set; }


        public string AxialForceMaximumCaseName { get; set; }
        public string AxialForceMininumCaseName { get; set; }

        public string TorsionMaxCaseName { get; set; }
        public string TorsionMinCaseName { get; set; }
    }
}
