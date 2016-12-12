using Kodestruct.ETABS.Interop.Entities.Frame.ForceExtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.Interop.Entities.Frame.ForceExtraction
{
    public class FrameEnvelopeForceResult
    {
        public string FrameName { get; set; }

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

        public FrameEnvelopeForceResult(string FrameName, FrameForceResult FrameResult)
        {
            this.FrameName = FrameName;
            this.MomentMajorMax =   FrameResult.MomentMajorMax ;
            this.MomentMajorMin =     FrameResult.MomentMajorMin ;
            this.MomentMinorMax =   FrameResult.MomentMinorMax ;
            this.MomentMinorMin =     FrameResult.MomentMinorMin ;
            this.ShearMajorMax =    FrameResult.ShearMajorMax ;
            this.ShearMajorMin =      FrameResult.ShearMajorMin ;
            this.ShearMinorMax =    FrameResult.ShearMinorMax ;
            this.ShearMinorMin =      FrameResult.ShearMinorMin ;
            this.TorsionMax =       FrameResult.TorsionMax ;
            this.TorsionMin =         FrameResult.TorsionMin ;
            this.AxialForceMax =    FrameResult.AxialForceMax ;
            this.AxialForceMin =      FrameResult.AxialForceMin ;
        }
    }
}
