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
using Kodestruct.ETABS.Interop.Entities.Group;
using Kodestruct.ETABS.Interop.Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.Interop.Entities.Frame.ForceExtraction
{
    public class FrameForceExtractor
    {
        cSapModel EtabsModel;

        public FrameForceExtractor(cSapModel EtabsModel)
        {
            this.EtabsModel = EtabsModel;
        }

        public List<FrameEnvelopeReactionResult> GetFrameReactions(List<string> FrameNames, string GroupNamePrefix, string ComboName, ModelUnits ModelUnits)
        {
            //Set Units
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
            List<FrameEnvelopeReactionResult> frameForceResult = new List<FrameEnvelopeReactionResult>();

            List<GroupData> GroupData = ExtractGroupNames(FrameNames, GroupNamePrefix);
            if (GroupData!=null)
            {
                foreach (var g in GroupData)
                {
                    FrameReactionResult thisGroupResult = GetEnvelopeReactionResultForMultipleFrames(g.Elements, ComboName);
                    FrameEnvelopeReactionResult thisGroupEnvelopeResult = new FrameEnvelopeReactionResult(g.Name, thisGroupResult);
                    frameForceResult.Add(thisGroupEnvelopeResult);
                }
            }
            return frameForceResult;
        }

        public FrameEnvelopeReactionResult GetFrameReactions(List<string> FrameNames, string ComboName, ModelUnits ModelUnits)
        {
            //Set Units
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


            FrameReactionResult thisSelectionResult = GetEnvelopeReactionResultForMultipleFrames(FrameNames, ComboName);
            FrameEnvelopeReactionResult thisSelectionEnvelopeResult = new FrameEnvelopeReactionResult(null, thisSelectionResult);

            return thisSelectionEnvelopeResult;
        }

        public FrameEnvelopeForceResult GetFrameForcesAtStationRatio(List<string> FrameNames, string ComboName, ModelUnits ModelUnits, double StationRatio)
        {
            //Set Units
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


            FrameForceResult thisSelectionResult = GetEnvelopeForceResultForMultipleFrames(FrameNames, ComboName, StationRatio);
            FrameEnvelopeForceResult thisSelectionEnvelopeResult = new FrameEnvelopeForceResult(null, thisSelectionResult);

            return thisSelectionEnvelopeResult;
        }

        public FrameEnvelopeForceResult GetFrameForces(List<string> FrameNames, string ComboName, ModelUnits ModelUnits)
        {
            //Set Units
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


            FrameForceResult thisSelectionResult = GetEnvelopeForceResultForMultipleFrames(FrameNames, ComboName);
            FrameEnvelopeForceResult thisSelectionEnvelopeResult = new FrameEnvelopeForceResult(null, thisSelectionResult);

            return thisSelectionEnvelopeResult;
        }

        public FrameEnvelopeForceResult GetFrameForces(string GroupName, string ComboName, ModelUnits ModelUnits)
        {
            //Set Units
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
            List<FrameEnvelopeReactionResult> frameForceResult = new List<FrameEnvelopeReactionResult>();

            GroupManager gm = new GroupManager(EtabsModel);
            GroupData d = gm.GetGroupDataForFrames(GroupName);

            FrameForceResult thisSelectionResult = GetEnvelopeForceResultForMultipleFrames(d.Elements, ComboName);
            FrameEnvelopeForceResult thisSelectionEnvelopeResult = new FrameEnvelopeForceResult(null, thisSelectionResult);

            return thisSelectionEnvelopeResult;

        }

        private FrameForceResult GetEnvelopeForceResultForMultipleFrames(List<string> FrameNames, string ComboName, double StationRatio)
        {
            List<FrameForceResult> results = new List<FrameForceResult>();

            foreach (var frm in FrameNames)
            {
                EtabsFrame thisFrame = new EtabsFrame(frm, this.EtabsModel);
                var thisResult = thisFrame.GetForces(ComboName, StationRatio);
                results.Add(thisResult);
            }


            //FindMaximums
            double MomentMajorMax = results.Max(f => f.MomentMajorMax);
            double MomentMajorMin = results.Min(f => f.MomentMajorMin);
            double MomentMinorMax = results.Max(f => f.MomentMinorMax);
            double MomentMinorMin = results.Min(f => f.MomentMinorMin);
            double ShearMajorMax = results.Max(f => f.ShearMajorMax);
            double ShearMajorMin = results.Min(f => f.ShearMajorMin);
            double ShearMinorMax = results.Max(f => f.ShearMinorMax);
            double ShearMinorMin = results.Min(f => f.ShearMinorMin);
            double TorsionMax = results.Max(f => f.TorsionMax);
            double TorsionMin = results.Min(f => f.TorsionMin);
            double AxialForceMax = results.Max(f => f.AxialForceMax);
            double AxialForceMin = results.Min(f => f.AxialForceMin);

            FrameForceResult envelopeResult = new FrameForceResult()
            {
                MomentMajorMax = MomentMajorMax,
                MomentMajorMin = MomentMajorMin,
                MomentMinorMax = MomentMinorMax,
                MomentMinorMin = MomentMinorMin,
                ShearMajorMax = ShearMajorMax,
                ShearMajorMin = ShearMajorMin,
                ShearMinorMax = ShearMinorMax,
                ShearMinorMin = ShearMinorMin,
                TorsionMax = TorsionMax,
                TorsionMin = TorsionMin,
                AxialForceMax = AxialForceMax,
                AxialForceMin = AxialForceMin
            };

            return envelopeResult;
        }


        private FrameForceResult GetEnvelopeForceResultForMultipleFrames(List<string> FrameNames, string ComboName)
        {

            List<FrameForceResult> results = new List<FrameForceResult>();

            foreach (var frm in FrameNames)
            {
                EtabsFrame thisFrame = new EtabsFrame(frm, this.EtabsModel);
                var thisResult = thisFrame.GetForces(ComboName);
                results.Add(thisResult);
            }

            //FindMaximums
            double MomentMajorMax = results.Max(f => f.MomentMajorMax);
            double MomentMajorMin = results.Min(f => f.MomentMajorMin);
            double MomentMinorMax = results.Max(f => f.MomentMinorMax);
            double MomentMinorMin = results.Min(f => f.MomentMinorMin);
            double ShearMajorMax = results.Max(f => f.ShearMajorMax);
            double ShearMajorMin = results.Min(f => f.ShearMajorMin);
            double ShearMinorMax = results.Max(f => f.ShearMinorMax);
            double ShearMinorMin = results.Min(f => f.ShearMinorMin);
            double TorsionMax = results.Max(f => f.TorsionMax);
            double TorsionMin = results.Min(f => f.TorsionMin);
            double AxialForceMax = results.Max(f => f.AxialForceMax);
            double AxialForceMin = results.Min(f => f.AxialForceMin);

            FrameForceResult envelopeResult = new FrameForceResult()
            {
                MomentMajorMax = MomentMajorMax,
                MomentMajorMin = MomentMajorMin,
                MomentMinorMax = MomentMinorMax,
                MomentMinorMin = MomentMinorMin,
                ShearMajorMax = ShearMajorMax,
                ShearMajorMin = ShearMajorMin,
                ShearMinorMax = ShearMinorMax,
                ShearMinorMin = ShearMinorMin,
                TorsionMax = TorsionMax,
                TorsionMin = TorsionMin,
                AxialForceMax = AxialForceMax,
                AxialForceMin = AxialForceMin
            };

            return envelopeResult;
        }

        public FrameEnvelopeReactionResult GetFrameReactions(string GroupName, string ComboName, ModelUnits ModelUnits)
        {
            //Set Units
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
            List<FrameEnvelopeReactionResult> frameForceResult = new List<FrameEnvelopeReactionResult>();

            GroupManager gm = new GroupManager(EtabsModel);
            GroupData d = gm.GetGroupDataForFrames(GroupName);

                    FrameReactionResult thisGroupResult = GetEnvelopeReactionResultForMultipleFrames(d.Elements, ComboName);
                    FrameEnvelopeReactionResult thisGroupEnvelopeResult = new FrameEnvelopeReactionResult(d.Name, thisGroupResult);


            return thisGroupEnvelopeResult;
        }

        private FrameReactionResult GetEnvelopeReactionResultForMultipleFrames(List<string> frameList, string ComboName)
        {
            List<FrameReactionResult> results = new List<FrameReactionResult>();

            foreach (var frm in frameList)
            {
                EtabsFrame thisFrame = new EtabsFrame(frm, this.EtabsModel);
                var thisResult = thisFrame.GetReactions(ComboName, true);
                results.Add(thisResult);
            }

            //FindMaximums
            double MomentMajorStart=  results.Max(f => f.MomentMajorStart);
            double MomentMajorEnd=    results.Max(f => f.MomentMajorEnd);
            double MomentMinorStart=  results.Max(f => f.MomentMinorStart);
            double MomentMinorEnd=    results.Max(f => f.MomentMinorEnd);
            double ShearMajorStart=   results.Max(f => f.ShearMajorStart);
            double ShearMajorEnd =    results.Max(f => f.ShearMajorEnd);
            double ShearMinorStart=   results.Max(f => f.ShearMinorStart   );
            double ShearMinorEnd=     results.Max(f => f.ShearMinorEnd     );
            double TorsionStart=      results.Max(f => f.TorsionStart      );
            double TorsionEnd=        results.Max(f => f.TorsionEnd        );
            double AxialForceStart=   results.Max(f => f.AxialForceStart   );
            double AxialForceEnd =    results.Max(f => f.AxialForceEnd     );

            FrameReactionResult envelopeResult = new FrameReactionResult()
            {
                MomentMajorStart = MomentMajorStart,
                MomentMajorEnd = MomentMajorEnd,
                MomentMinorStart = MomentMinorStart,
                MomentMinorEnd = MomentMinorEnd,
                ShearMajorStart = ShearMajorStart,
                ShearMajorEnd = ShearMajorEnd,
                ShearMinorStart = ShearMinorStart,
                ShearMinorEnd = ShearMinorEnd,
                TorsionStart = TorsionStart,
                TorsionEnd = TorsionEnd,
                AxialForceStart = AxialForceStart,
                AxialForceEnd = AxialForceEnd
            };

            return envelopeResult;
        }

        private List<GroupData> ExtractGroupNames(List<string> FrameNames, string GroupNamePrefix)
        {
            GroupManager gm = new GroupManager(EtabsModel);
            List<GroupData> GroupData = gm.GetGroupDataForFrames(FrameNames, GroupNamePrefix);

            return GroupData;
        }


    }
}
