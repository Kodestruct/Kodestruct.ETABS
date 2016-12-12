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
 
using Kodestruct.ETABS.Interop.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.Interop.Entities.Frame.Loads
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
