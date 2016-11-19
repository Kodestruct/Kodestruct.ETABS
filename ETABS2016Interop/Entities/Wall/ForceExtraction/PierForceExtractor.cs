using ETABS2016;
using Kodestruct.ETABS.v2016.Entities.Enums;
using Kodestruct.ETABS.v2016.Interop.Common.Lists;
using Kodestruct.ETABS.v2016.Interop.Entities.Enums;
using Kodestruct.ETABS.v2016.Interop.Entities.Frame.ForceExtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.v2016.Interop.Entities.Wall.ForceExtraction
{
    public class PierForceExtractor
    {

        cSapModel EtabsModel;

        public PierForceExtractor( cSapModel EtabsModel)
        {
            this.EtabsModel = EtabsModel;

        }

        public List<WallForceResult> GetAllPierForces(List<string> Combonames)
        {
            throw new NotImplementedException();
            //List<WallForceResult> BottomForces = 
        }

        public List<WallForceResult> GetPierForces(string ComboName, PierPointLocation PierPointLocation, ModelUnits ModelUnits)
        {
            List<WallForceResult> results = new List<WallForceResult>();

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

            var ret1 = EtabsModel.Results.Setup.SetComboSelectedForOutput(ComboName);
 

            int NumberResults = 0;
            string[] _StoryNames = null;
            string[] _PierNames = null;
            string[] _Locations = null;
            string[] _LoadCase = null;
            double[] _P = null;
            double[] _V2 = null;
            double[] _V3 = null;
            double[] _T = null;
            double[] _M2 = null;
            double[] _M3 = null;


            var ret2 = EtabsModel.Results.PierForce(
                ref NumberResults,
                ref _StoryNames,
                ref _PierNames,
                ref _LoadCase,
                ref _Locations,
                ref _P,
                ref _V2,
                ref _V3,
                ref _T,
                ref _M2,
                ref _M3
                );



            List<PierDataPoint> unfilteredList = new List<PierDataPoint>();

            if (NumberResults > 0)
            {
                for (int i = 0; i < NumberResults; i++)
                {
                    PierDataPoint dp = new PierDataPoint()
                    {
                        StoryName = _StoryNames[i],
                        PierName = _PierNames[i],
                        LoadCase = _LoadCase[i],
                        Location = _Locations[i],
                        P = _P[i],
                        V2 = _V2[i],
                        V3 = _V3[i],
                        T = _T[i],
                        M2 = _M2[i],
                        M3 = _M3[i]
                    };

                    unfilteredList.Add(dp);
                }

                //Unique storys
                List<string> StoryNames = _StoryNames.Distinct().ToList();
                // Unique piers
                List<string> PierNames = _PierNames.Distinct().ToList();

                if (StoryNames.Count!=0 && PierNames.Count!=0)
                {
                    foreach (var pier in PierNames)
                    {
                        var thisPierStoryOccurence = unfilteredList.Where(w => w.PierName == pier).Select(p => p.StoryName);
                        var storiesForThisPier = thisPierStoryOccurence.Distinct().ToList();

                        foreach (var story in storiesForThisPier)
                        {

                            var PierData = unfilteredList.Where(w => w.StoryName == story && w.PierName == pier && w.Location == PierPointLocation.ToString() );
                            double  P_Max  =PierData.Max(p => p.P);
                            double  V2_Max =PierData.Max(p => p.V2);
                            double  V3_Max =PierData.Max(p => p.V3);
                            double  T_Max  =PierData.Max(p => p.T);
                            double  M2_Max =PierData.Max(p => p.M2);
                            double  M3_Max =PierData.Max(p => p.M3);
                            double P_Min = PierData.Min(p => p.P);
                            double V2_Min = PierData.Min(p => p.V2);
                            double V3_Min = PierData.Min(p => p.V3);
                            double T_Min = PierData.Min(p => p.T);
                            double M2_Min = PierData.Min(p => p.M2);
                            double M3_Min = PierData.Min(p => p.M3);

                            WallPointResult res = new WallPointResult()
                            {
                                 P_Max  = P_Max  ,
                                 V2_Max = V2_Max ,
                                 V3_Max = V3_Max ,
                                 T_Max  = T_Max  ,
                                 M2_Max = M2_Max ,
                                 M3_Max = M3_Max ,
                                 P_Min  = P_Min  ,
                                 V2_Min = V2_Min ,
                                 V3_Min = V3_Min ,
                                 T_Min  = T_Min  ,
                                 M2_Min = M2_Min ,
                                 M3_Min = M3_Min,
                                 StoryName = story,
                                 PierPointLocation = PierPointLocation
                            };

                            WallForceResult forceResult = new WallForceResult()
                            {
                                PierName = pier,
                                Result = res
                            };
                            results.Add(forceResult);
                        }
                    }
                    return results;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
 
        }

        class PierDataPoint
        {
           public string  StoryName {get; set;}
           public string  PierName  {get; set;}
           public string  Location  {get; set;}
           public string  LoadCase  {get; set;}
           public double  P         {get; set;}
           public double  V2        {get; set;}
           public double  V3        {get; set;}
           public double  T         {get; set;}
           public double  M2        {get; set;}
           public double M3         { get; set; }
        }
    }
}
