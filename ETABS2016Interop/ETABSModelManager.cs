using ETABS2016;
using Kodestruct.ETABS.v2016.Entities.Enums;
using Kodestruct.ETABS.v2016.Interop.Entities;
using Kodestruct.ETABS.v2016.Interop.Entities.Frame;
using Kodestruct.ETABS.v2016.Interop.Entities.Frame.ForceExtraction;
using Kodestruct.ETABS.v2016.Interop.Entities.Group;
using Kodestruct.ETABS.v2016.Interop.Entities.Story;
using Kodestruct.ETABS.v2016.Interop.Entities.Wall;
using Kodestruct.ETABS.v2016.Interop.Entities.Wall.ForceExtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.v2016.Interop
{
    public class ETABSModelManager
    {
        cSapModel model { get; set; }



        public List<WallForceResult> GetPierForces(string ComboName, PierPointLocation PierPointLocation, ModelUnits ModelUnits)
        {
            PierForceExtractor ext = new PierForceExtractor(model);
            List<WallForceResult> f = ext.GetPierForces(ComboName, PierPointLocation);
            return f;
        }

        public List<WallForceResult> GetPierForces(string PierName, string ComboName, PierPointLocation PierPointLocation, ModelUnits ModelUnits)
        {

            PierForceExtractor ext = new PierForceExtractor(model);
            List<WallForceResult> f = ext.GetPierForces(ComboName, PierPointLocation);
            var thisPierForces = f.Where(p => p.PierName == PierName).ToList();
            return thisPierForces;
        }

        public FrameEnvelopeReactionResult GetFrameReactions(string GroupName, string ComboName, ModelUnits ModelUnits)
        {
            //FrameForceExtractor ext = new FrameForceExtractor(model);
            //FrameEnvelopeReactionResult res = ext.GetFrameReactions(GroupName, ComboName, ModelUnits);
            FrameDataExtractor ext = new FrameDataExtractor();
            FrameEnvelopeReactionResult res = ext.GetFrameReactions(GroupName, ComboName, ModelUnits.ToString());
            return res;
        }

        public List<string> GetModelComboNames()
        {
            List<string> ComboNames = null;
            model = ETABSConnection.GetModel();

            LoadCaseAndComboManager gm = new LoadCaseAndComboManager(model);
            try
            {
                ComboNames = gm.GetComboNames();
            }
            catch (Exception)
            {

                //todo throw exception
            }

            model = null;
            if (ComboNames != null)
            {
                return ComboNames;
            }
            else
            {
                return null;
            }
        }
        public List<string> GetModelGroupNames()
        {
            model = ETABSConnection.GetModel();
            List<string> GroupNames=null;

            GroupManager gm = new GroupManager(model);
            try
            {
                GroupNames = gm.GetAllGroupNamesInModel();
            }
            catch (Exception)
            {
                
                //todo throw exception
            }
            
            model = null;

                return GroupNames;

        }

        public List<string> GetModelPierNames()
        {
            model = ETABSConnection.GetModel();
            List<string> PierNames = null;

            PierManager gm = new PierManager(model);
            try
            {
                PierNames = gm.GetAllPierNamesInModel();
            }
            catch (Exception)
            {

                //todo throw exception
            }

            model = null;

                return PierNames;

        }

        public List<string> GetModelStoryNames()
        {
            model = ETABSConnection.GetModel();
            List<string> StoryNames = null;

            StoryManager sm = new StoryManager(model);
            try
            {
                StoryNames = sm.GetAllStoryNamesInModel();
            }
            catch (Exception)
            {

                //todo throw exception
            }

            model = null;

            return StoryNames;

        }
    }
}
