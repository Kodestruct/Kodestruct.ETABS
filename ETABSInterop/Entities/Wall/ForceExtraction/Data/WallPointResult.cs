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
 
using Kodestruct.ETABS.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.Interop.Entities.Wall.ForceExtraction
{
    public class WallPointResult //: PointResult
    {

        public string StoryName { get; set; }
        public PierPointLocation PierPointLocation { get; set; }

        public double  P_Max  {get; set;}
        public double  V2_Max {get; set;} 
        public double  V3_Max {get; set;} 
        public double  T_Max  {get; set;}
        public double  M2_Max {get; set;} 
        public double  M3_Max {get; set;}
        public double P_Min { get; set; }
        public double V2_Min { get; set; }
        public double V3_Min { get; set; }
        public double T_Min { get; set; }
        public double M2_Min { get; set; }
        public double M3_Min { get; set; } 
    }
}
