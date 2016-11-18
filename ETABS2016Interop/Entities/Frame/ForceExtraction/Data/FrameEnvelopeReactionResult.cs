using Kodestruct.ETABS.v2016.Interop.Entities.Frame.ForceExtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.v2016.Interop.Entities.Frame.ForceExtraction
{
    public class FrameEnvelopeReactionResult
    {
        public string FrameName { get; set; }

        public double MomentMajorStart { get; set; }
        public double MomentMajorEnd { get; set; }
        public double MomentMinorStart { get; set; }
        public double MomentMinorEnd { get; set; }
        public double ShearMajorStart { get; set; }
        public double ShearMajorEnd { get; set; }
        public double ShearMinorStart { get; set; }
        public double ShearMinorEnd { get; set; }
        public double AxialForceMaximum { get; set; }
        public double AxialForceMininum { get; set; }
        public double TorsionStart { get; set; }
        public double TorsionEnd { get; set; }
        public double AxialForceStart { get; set; }
        public double AxialForceEnd { get; set; }

        public FrameEnvelopeReactionResult(string FrameName, FrameReactionResult FrameResult)
        {
            this.FrameName = FrameName;
            this.MomentMajorStart =   FrameResult.MomentMajorStart ;
            this.MomentMajorEnd =     FrameResult.MomentMajorEnd ;
            this.MomentMinorStart =   FrameResult.MomentMinorStart ;
            this.MomentMinorEnd =     FrameResult.MomentMinorEnd ;
            this.ShearMajorStart =    FrameResult.ShearMajorStart ;
            this.ShearMajorEnd =      FrameResult.ShearMajorEnd ;
            this.ShearMinorStart =    FrameResult.ShearMinorStart ;
            this.ShearMinorEnd =      FrameResult.ShearMinorEnd ;
            this.TorsionStart =       FrameResult.TorsionStart ;
            this.TorsionEnd =         FrameResult.TorsionEnd ;
            this.AxialForceStart =    FrameResult.AxialForceStart ;
            this.AxialForceEnd =      FrameResult.AxialForceEnd ;
        }
    }
}
