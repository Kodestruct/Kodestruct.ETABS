using Kodestruct.ETABS.v2016.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.v2016.Interop.Entities.Wall.ForceExtraction
{
    public class WallForceResult //: ForceResult
    {
        public string PierName { get; set; }
        public WallPointResult Result { get; set; }

    }
}
