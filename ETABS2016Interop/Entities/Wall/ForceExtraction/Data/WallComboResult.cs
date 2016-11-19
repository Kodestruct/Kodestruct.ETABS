using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.v2016.Interop.Entities.Wall.ForceExtraction.Data
{
    public class WallComboResult
    {
        public string ComboName { get; set; }
        public List<WallForceResult> PierForces { get; set; }

        public WallComboResult(string ComboName, List<WallForceResult> PierForces)
        {
            this.ComboName = ComboName;
            this.PierForces = PierForces;
        }
    }
}
