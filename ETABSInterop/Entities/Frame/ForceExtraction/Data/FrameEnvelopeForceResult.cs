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
