using ETABS2016;
using Kodestruct.ETABS.Interop;
using Kodestruct.ETABS.Interop.Entities.Frame;
using Kodestruct.ETABS.Interop.Entities.Frame.ForceExtraction;
using Kodestruct.ETABS.Interop.Entities.Wall;
using Kodestruct.ETABS.Interop.Entities.Wall.ForceExtraction;
using Kodestruct.ETABS.Interop.Entities.Wall.GeometryExtraction;
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
        [Test]
        public void AllPierPropertiesAreExtracted()
        {

            cSapModel m = ETABSConnection.GetModel();
            PierGeometryExtractor ext = new PierGeometryExtractor(m);
            List<PierData> d = ext.GetAllPierGeometry(ModelUnits.kip_ft);

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
