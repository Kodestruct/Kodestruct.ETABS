using Kodestruct.ETABS.v2016.Interop.Entities.Frame;
using Kodestruct.ETABS.v2016.Interop.Entities.Frame.ForceExtraction;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodestructETABS2015Tests.Wall
{


    [TestFixture]
    public class WallTests : ToleranceTestBase
    {
        public WallTests()
        {
            tolerance = 0.02;
        }

        double tolerance;

        [Test]
        public void PierReturnsAxialForce()
        {
            //string PierName = "P1";
            //string combo = "C1";
            //FrameDataExtractor mde = new FrameDataExtractor();
            //List<WallForceResult> GetPierForcesresult = mde.(combo, "kip_in");
            //double refValue = 562.0;
            //double actualTolerance = EvaluateActualTolerance(phiP_n, refValue);

            //Assert.LessOrEqual(actualTolerance, tolerance);
        }
    }
}
