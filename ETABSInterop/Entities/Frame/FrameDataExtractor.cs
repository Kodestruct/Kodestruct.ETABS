using ETABS2016;
using Kodestruct.ETABS.Interop.Entities.Frame.ForceExtraction;
using Kodestruct.ETABS.Interop.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.Interop.Entities.Frame
{
    public class FrameDataExtractor
    {
        cSapModel ETABSModel;

        public FrameDataExtractor()
        {
            ETABSModel = ETABSConnection.GetModel();
        }

        public void ExtractFrameForcesIntoDataFile(string ComboName, string GroupNamePrefix, string OutputPath, string UnitSystem)
        {
           

            ModelUnits units;
            bool IsValidUnit = Enum.TryParse(UnitSystem, out units);
            if (IsValidUnit == true)
            {


                //Get selected frames

                SelectionManager sm = new SelectionManager(ETABSModel);
                List<string> frames = sm.GetSelectedFrameNames();

                //Use frame extractor to get frame forces
                FrameForceExtractor ext = new FrameForceExtractor(ETABSModel);
                List<FrameEnvelopeReactionResult> results = ext.GetFrameReactions(frames, GroupNamePrefix, ComboName, units);

                //Save file
                DataFileManager dfm = new DataFileManager();
                dfm.WriteReactionResultsToDataFile(results, OutputPath);
            }
            else
            {
                throw new Exception("Invalid Unit System");
            }
        }

       public  FrameEnvelopeReactionResult GetFrameReactions(string GroupName, string ComboName, string UnitSystem)
        {
            FrameEnvelopeReactionResult result = null;


            ModelUnits units;
            bool IsValidUnit = Enum.TryParse(UnitSystem, out units);
            if (IsValidUnit == true)
            {


                //Get selected frames

                SelectionManager sm = new SelectionManager(ETABSModel);
   
                //Use frame extractor to get frame forces
                FrameForceExtractor ext = new FrameForceExtractor(ETABSModel);
                result = ext.GetFrameReactions(GroupName, ComboName, units);

            }
            else
            {
                throw new Exception("Invalid Unit System");
            }
            return result;
        }

       public FrameEnvelopeForceResult GetFrameForces(string GroupName, string ComboName, string UnitSystem)
       {
           FrameEnvelopeForceResult result = null;


           ModelUnits units;
           bool IsValidUnit = Enum.TryParse(UnitSystem, out units);
           if (IsValidUnit == true)
           {


               //Get selected frames

               SelectionManager sm = new SelectionManager(ETABSModel);

               //Use frame extractor to get frame forces
               FrameForceExtractor ext = new FrameForceExtractor(ETABSModel);
               result = ext.GetFrameForces(GroupName, ComboName, units);

           }
           else
           {
               throw new Exception("Invalid Unit System");
           }
           return result;
       }

       public FrameEnvelopeReactionResult GetSelectedFrameReactions(string SelectedCombo, string UnitSystem)
       {
           FrameEnvelopeReactionResult result = null;


           ModelUnits units;
           bool IsValidUnit = Enum.TryParse(UnitSystem, out units);
           if (IsValidUnit == true)
           {


               //Get selected frames

               SelectionManager sm = new SelectionManager(ETABSModel);
               List<string> selectedFrameNames = sm.GetSelectedFrameNames();
        

               //Use frame extractor to get frame forces
               FrameForceExtractor ext = new FrameForceExtractor(ETABSModel);
               result = ext.GetFrameReactions(selectedFrameNames, SelectedCombo, units);

           }
           else
           {
               throw new Exception("Invalid Unit System");
           }
           return result;
       }

       public FrameEnvelopeForceResult GetSelectedFrameForces(string SelectedCombo, string UnitSystem)
       {
           FrameEnvelopeForceResult result = null;

           ModelUnits units;
           bool IsValidUnit = Enum.TryParse(UnitSystem, out units);
           if (IsValidUnit == true)
           {


               //Get selected frames

               SelectionManager sm = new SelectionManager(ETABSModel);
               List<string> selectedFrameNames = sm.GetSelectedFrameNames();


               //Use frame extractor to get frame forces
               FrameForceExtractor ext = new FrameForceExtractor(ETABSModel);
               result = ext.GetFrameForces(selectedFrameNames, SelectedCombo, units);

           }
           else
           {
               throw new Exception("Invalid Unit System");
           }
           return result;
       }
    }
}
