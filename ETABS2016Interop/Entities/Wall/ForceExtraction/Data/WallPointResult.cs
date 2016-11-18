using Kodestruct.ETABS.v2016.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.v2016.Interop.Entities.Frame.ForceExtraction
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
