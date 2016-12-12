#region Copyright
   /*Copyright (C) 2015 Konstantin Udilovich

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
   */
#endregion
 
using Kodestruct.ETABS.Interop.Entities.Frame.ForceExtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.Interop.Entities.Frame.ForceExtraction
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
