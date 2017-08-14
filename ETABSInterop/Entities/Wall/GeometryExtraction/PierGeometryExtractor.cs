using ETABS2016;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.Interop.Entities.Wall.GeometryExtraction
{
    public class PierGeometryExtractor
    {
        cSapModel EtabsModel;

        public PierGeometryExtractor(cSapModel EtabsModel)
        {
            this.EtabsModel = EtabsModel;

        }

        public List<PierData> GetAllPierGeometry(ModelUnits ModelUnits)
        {
            List<PierData> AllPiers = new List<PierData>();

            //SET UP CORRECT UNITS
            EtabsModel.Results.Setup.DeselectAllCasesAndCombosForOutput();
            switch (ModelUnits)
            {
                case ModelUnits.kip_in:
                    EtabsModel.SetPresentUnits(eUnits.kip_in_F);
                    break;
                case ModelUnits.kip_ft:
                    EtabsModel.SetPresentUnits(eUnits.kip_ft_F);
                    break;
                default:
                    EtabsModel.SetPresentUnits(eUnits.kip_in_F);
                    break;
            }

            
            //EXTRACT PIER NAMES
            int NumNames = 0;

            string[] _UniquePierNames=null;
            int res =  EtabsModel.PierLabel.GetNameList(ref NumNames, ref _UniquePierNames);
                    if (NumNames>0)
                    {

                    }
                    else
                    {
                        throw new Exception("Failed to exctract pier names. Check if ETABS model is available for reading.");
                    }
            List<string> UniquePierNames = new List<string>(_UniquePierNames);

            //EXTRACT PIER GEOMETRY


            #region temporary arrays
                int        _NumberStories  =0;
	            string[]   _StoryName     =null;
	            double[]   _AxisAngle     =null;
	            int[]      _NumAreaObjs   =null;
	            int[]      _NumLineObjs   =null;
	            double[]   _WidthBot      =null;
	            double[]   _ThicknessBot  =null;
	            double[]   _WidthTop      =null;
	            double[]   _ThicknessTop  =null;
	            string[]   _MatProp       =null;
	            double[]   _CGBotX        =null;
	            double[]   _CGBotY        =null;
	            double[]   _CGBotZ        =null;
	            double[]   _CGTopX        =null;
	            double[]   _CGTopY        =null;
                double[]   _CGTopZ          = null;

            #endregion

            
            foreach (var pierName in UniquePierNames)
            {
                List<PierStoryData> thisPierData = new List<PierStoryData>();
                var ret1 = EtabsModel.PierLabel.GetSectionProperties(pierName,ref _NumberStories,ref _StoryName,ref _AxisAngle,ref _NumAreaObjs,ref _NumLineObjs,
                    ref _WidthBot,ref _ThicknessBot,ref _WidthTop,ref _ThicknessTop,ref _MatProp,ref _CGBotX,ref _CGBotY,ref _CGBotZ,ref _CGTopX,ref _CGTopY,ref _CGTopZ  
                    );
                for (int i = 0; i < _NumberStories; i++)
                {
                    string a = _MatProp[i];
                    PierStoryData thisStoryData = new PierStoryData(pierName,
                         _NumberStories,
                         _StoryName[i],
                         _AxisAngle[i],
                         _NumAreaObjs[i],
                         _NumLineObjs[i],
                         _WidthBot[i],
                         _ThicknessBot[i],
                         _WidthTop[i],
                         _ThicknessTop[i],
                         _MatProp[i],
                         _CGBotX[i],
                         _CGBotY[i],
                         _CGBotZ[i],
                         _CGTopX[i],
                         _CGTopY[i],
                         _CGTopZ[i]);
                    thisPierData.Add(thisStoryData);
                }
                PierData data = new PierData(pierName, thisPierData);
                AllPiers.Add(data);
            }

            return AllPiers;
        }
    }
}
