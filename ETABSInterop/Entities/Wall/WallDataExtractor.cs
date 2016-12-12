using ETABS2016;
using Kodestruct.ETABS.Entities.Enums;
using Kodestruct.ETABS.Interop.Entities.Frame.ForceExtraction;
using Kodestruct.ETABS.Interop.Entities.Wall.ForceExtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.Interop.Entities.Wall
{
    public class WallDataExtractor
    {
        cSapModel ETABSModel;

        public WallDataExtractor()
        {
            ETABSModel = ETABSConnection.GetModel();
        }

        //public List<WallPointResult> GetPierForces(string PierName, string ComboName, List<string> StoryNames, PierPointLocation PierPointLocation)
        //{
        //    PierForceExtractor pfe = new PierForceExtractor(ETABSModel);
        //    List<WallForceResult> allForces = pfe.GetPierForces(ComboName, PierPointLocation);
        //    List<WallForceResult> thisPierForces = allForces.Where(f => f.PierName == PierName).ToList();
        //    var res = thisPierForces.Select(r => r.Result).ToList();
        //    return res;
        //}
    }
}
