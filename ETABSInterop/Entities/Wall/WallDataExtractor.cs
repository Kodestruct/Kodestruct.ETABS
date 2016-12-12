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
