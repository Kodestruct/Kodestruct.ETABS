﻿#region Copyright
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
using Kodestruct.ETABS.Interop.Common.Lists;
using Kodestruct.ETABS.Interop.Common.Mathematics;
using Kodestruct.ETABS.Interop.Entities.Enums;
using Kodestruct.ETABS.Interop.Entities.Frame.ForceExtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.Interop.Entities.Frame
{
    public partial class EtabsFrame : EtabsLine
    {


        public EtabsFrame(string Name, cSapModel EtabsModel)
            : base(Name, EtabsModel)
        {

        }

        public FrameForceResult GetForces(string ComboName)
        {

                return new FrameForceResult()
                {

                    AxialForceMax = GetMaximumForce(ComboName, ForceType.Fx).ResultValue,
                    AxialForceMin = GetMinimumForce(ComboName, ForceType.Fx).ResultValue,
                    MomentMajorMax = GetMaximumForce(ComboName, ForceType.Mz).ResultValue,
                    MomentMajorMin = GetMinimumForce(ComboName, ForceType.Mz).ResultValue,
                    MomentMinorMax = GetMaximumForce(ComboName, ForceType.My).ResultValue,
                    MomentMinorMin = GetMinimumForce(ComboName, ForceType.My).ResultValue,
                    ShearMajorMax = GetMaximumForce(ComboName, ForceType.Fy).ResultValue,
                    ShearMajorMin = GetMinimumForce(ComboName, ForceType.Fy).ResultValue,
                    ShearMinorMax = GetMaximumForce(ComboName, ForceType.Fz).ResultValue,
                    ShearMinorMin = GetMinimumForce(ComboName, ForceType.Fz).ResultValue,
                    TorsionMax = GetMaximumForce(ComboName, ForceType.Mx).ResultValue,
                    TorsionMin = GetMinimumForce(ComboName, ForceType.Mx).ResultValue

                };

        }
        /// <summary>
        /// Gets frame forces at a loacation, specified as ratio of station to overall length
        /// </summary>
        /// <param name="ComboName"></param>
        /// <param name="StationRatio">Ratio of station to overall length</param>
        /// <returns></returns>
        public FrameForceResult GetForces(string ComboName, double StationRatio)
        {

            return new FrameForceResult()
            {

                AxialForceMax = GetMaximumForceAtStationRatio(ComboName, ForceType.Fx, StationRatio).ResultValue,
                AxialForceMin = GetMinimumForceAtStationRatio(ComboName, ForceType.Fx, StationRatio).ResultValue,
                MomentMajorMax = GetMaximumForceAtStationRatio(ComboName, ForceType.Mz, StationRatio).ResultValue,
                MomentMajorMin = GetMinimumForceAtStationRatio(ComboName, ForceType.Mz, StationRatio).ResultValue,
                MomentMinorMax = GetMaximumForceAtStationRatio(ComboName, ForceType.My, StationRatio).ResultValue,
                MomentMinorMin = GetMinimumForceAtStationRatio(ComboName, ForceType.My, StationRatio).ResultValue,
                ShearMajorMax = GetMaximumForceAtStationRatio(ComboName, ForceType.Fy, StationRatio).ResultValue,
                ShearMajorMin = GetMinimumForceAtStationRatio(ComboName, ForceType.Fy, StationRatio).ResultValue,
                ShearMinorMax = GetMaximumForceAtStationRatio(ComboName, ForceType.Fz, StationRatio).ResultValue,
                ShearMinorMin = GetMinimumForceAtStationRatio(ComboName, ForceType.Fz, StationRatio).ResultValue,
                TorsionMax = GetMaximumForceAtStationRatio(ComboName, ForceType.Mx, StationRatio).ResultValue,
                TorsionMin = GetMinimumForceAtStationRatio(ComboName, ForceType.Mx, StationRatio).ResultValue

            };

        }

        public FrameReactionResult GetReactions( string ComboName, bool ReturnAbsoluteValues)
        {
            if (ReturnAbsoluteValues == false)
            {
                return new FrameReactionResult()
                {

                    AxialForceStart = GetMaximumAbsoluteForce(ComboName, ForceType.Fx, StationType.First).ResultValue,
                    AxialForceEnd = GetMaximumAbsoluteForce(ComboName, ForceType.Fx, StationType.Last).ResultValue,
                    MomentMajorStart = GetMaximumAbsoluteForce(ComboName, ForceType.Mz, StationType.First).ResultValue,
                    MomentMajorEnd = GetMaximumAbsoluteForce(ComboName, ForceType.Mz, StationType.Last).ResultValue,
                    MomentMinorStart = GetMaximumAbsoluteForce(ComboName, ForceType.My, StationType.First).ResultValue,
                    MomentMinorEnd = GetMaximumAbsoluteForce(ComboName, ForceType.My, StationType.Last).ResultValue,
                    ShearMajorStart = GetMaximumAbsoluteForce(ComboName, ForceType.Fy, StationType.First).ResultValue,
                    ShearMajorEnd = GetMaximumAbsoluteForce(ComboName, ForceType.Fy, StationType.Last).ResultValue,
                    ShearMinorStart = GetMaximumAbsoluteForce(ComboName, ForceType.Fz, StationType.First).ResultValue,
                    ShearMinorEnd = GetMaximumAbsoluteForce(ComboName, ForceType.Fz, StationType.Last).ResultValue,
                    TorsionStart = GetMaximumAbsoluteForce(ComboName, ForceType.Mx, StationType.First).ResultValue,
                    TorsionEnd = GetMaximumAbsoluteForce(ComboName, ForceType.Mx, StationType.Last).ResultValue

                }; 
            }
            else
            {
                return new FrameReactionResult()
                {
                    AxialForceStart =       Math.Abs(GetMaximumAbsoluteForce(ComboName, ForceType.Fx, StationType.First).ResultValue),
                    AxialForceEnd =         Math.Abs(GetMaximumAbsoluteForce(ComboName, ForceType.Fx, StationType.Last).ResultValue),
                    MomentMajorStart =      Math.Abs(GetMaximumAbsoluteForce(ComboName, ForceType.Mz, StationType.First).ResultValue),
                    MomentMajorEnd =        Math.Abs(GetMaximumAbsoluteForce(ComboName, ForceType.Mz, StationType.Last).ResultValue),
                    MomentMinorStart =      Math.Abs(GetMaximumAbsoluteForce(ComboName, ForceType.My, StationType.First).ResultValue),
                    MomentMinorEnd =        Math.Abs(GetMaximumAbsoluteForce(ComboName, ForceType.My, StationType.Last).ResultValue),
                    ShearMajorStart =       Math.Abs(GetMaximumAbsoluteForce(ComboName, ForceType.Fy, StationType.First).ResultValue),
                    ShearMajorEnd =         Math.Abs(GetMaximumAbsoluteForce(ComboName, ForceType.Fy, StationType.Last).ResultValue),
                    ShearMinorStart =       Math.Abs(GetMaximumAbsoluteForce(ComboName, ForceType.Fz, StationType.First).ResultValue),
                    ShearMinorEnd =         Math.Abs(GetMaximumAbsoluteForce(ComboName, ForceType.Fz, StationType.Last).ResultValue),
                    TorsionStart =          Math.Abs(GetMaximumAbsoluteForce(ComboName, ForceType.Mx, StationType.First).ResultValue),
                    TorsionEnd =            Math.Abs(GetMaximumAbsoluteForce(ComboName, ForceType.Mx, StationType.Last).ResultValue)

                }; 
            }



        }

        public FramePointResult GetMaximumForce( string ComboName, ForceType ForceType)
        {
            FramePointResult result = new FramePointResult();
            double MaxForce = double.NegativeInfinity;

            List<FramePointResult> FrameResults = GetFrameForceList( ComboName, ForceType);


            for (int i = 0; i < FrameResults.Count; i++)
            {
                if (FrameResults[i].ResultValue >= MaxForce)
                {
                    MaxForce = FrameResults[i].ResultValue;
                    result.ResultValue = MaxForce;
                    result.Station = FrameResults[i].Station;
                }
            }

            return result;

        }


        public FramePointResult GetMaximumForceAtStationRatio(string ComboName, ForceType ForceType, double StationRatio)
        {

            double StationValue = this.Length * StationRatio;


            FramePointResult result = new FramePointResult();

            List<FramePointResult> FrameResults = GetFrameForceList(ComboName, ForceType);
            List<double> distinctStations = FrameResults.Select(r => r.Station).Distinct().ToList();


            double closestStation1 = distinctStations.OrderBy(item => Math.Abs(StationValue - item)).ToList()[0];
            double closestStation2 = distinctStations.OrderBy(item => Math.Abs(StationValue - item)).ToList()[1];

            var Value1List = FrameResults.Where(r => r.Station == closestStation1).ToList();
            var Value2List = FrameResults.Where(r => r.Station == closestStation2).ToList();

            var Value1 = Value1List.Max(v => v.ResultValue);
            var Value2 = Value2List.Max(v => v.ResultValue);

            double ResultVal = Interpolation.InterpolateLinear(closestStation1, Value1, closestStation2, Value2, StationValue);

            result.ResultValue = ResultVal;
            result.Station = StationValue;

            return result;
        }

        public FramePointResult GetMinimumForceAtStationRatio(string ComboName, ForceType ForceType, double StationRatio)
        {

            double StationValue = this.Length * StationRatio;


            FramePointResult result = new FramePointResult();

            List<FramePointResult> FrameResults = GetFrameForceList(ComboName, ForceType);
            List<double> distinctStations = FrameResults.Select(r => r.Station).Distinct().ToList();


            double closestStation1 = distinctStations.OrderBy(item => Math.Abs(StationValue - item)).ToList()[0];
            double closestStation2 = distinctStations.OrderBy(item => Math.Abs(StationValue - item)).ToList()[1];

            var Value1List = FrameResults.Where(r => r.Station == closestStation1).ToList();
            var Value2List = FrameResults.Where(r => r.Station == closestStation2).ToList();

            var Value1 = Value1List.Min(v => v.ResultValue);
            var Value2 = Value2List.Min(v => v.ResultValue);

            double ResultVal = Interpolation.InterpolateLinear(closestStation1, Value1, closestStation2, Value2, StationValue);

            result.ResultValue = ResultVal;
            result.Station = StationValue;

            return result;
        }

        public FramePointResult GetMaximumForce( string ComboName, ForceType ForceType, double Station)
        {
            FramePointResult result = new FramePointResult();
            double MaxForce = double.NegativeInfinity;

            List<FramePointResult> FrameResults = GetFrameForceList( ComboName, ForceType);


            for (int i = 0; i < FrameResults.Count; i++)
            {
                if (FrameResults[i].Station == Station)
                {
                    if (FrameResults[i].ResultValue >= MaxForce)
                    {
                        MaxForce = FrameResults[i].ResultValue;
                        result.ResultValue = MaxForce;
                        result.Station = FrameResults[i].Station;
                    }
                }
            }

            return result;
        }

        public FramePointResult GetMaximumForce( string ComboName, ForceType ForceType, StationType StationType)
        {

            FramePointResult result = new FramePointResult();
            List<FramePointResult> FrameResults = GetFrameForceList( ComboName, ForceType);

            switch (StationType)
            {
                case StationType.First:
                    var MinStation = FrameResults.Select(p => p.Station).Min();
                    result = GetMaximumForce( ComboName, ForceType, MinStation);
                    break;
                case StationType.Last:
                    var MaxStation = FrameResults.Select(p => p.Station).Max();
                    result = GetMaximumForce(ComboName, ForceType, MaxStation);
                    break;
            }

            return result;
        }

        public FramePointResult GetMinimumForce( string ComboName, ForceType ForceType)
        {
            FramePointResult result = new FramePointResult();
            double MinForce = double.PositiveInfinity;

            List<FramePointResult> FrameResults = GetFrameForceList(ComboName, ForceType);


            for (int i = 0; i < FrameResults.Count; i++)
            {
                if (FrameResults[i].ResultValue <= MinForce)
                {
                    MinForce = FrameResults[i].ResultValue;
                    result.ResultValue = MinForce;
                    result.Station = FrameResults[i].Station;
                }
            }


            return result;

        }

        public FramePointResult GetMinimumForce( string ComboName, ForceType ForceType, double Station)
        {
            FramePointResult result = new FramePointResult();
            double MinForce = double.PositiveInfinity;

            List<FramePointResult> FrameResults = GetFrameForceList(ComboName, ForceType);


            for (int i = 0; i < FrameResults.Count; i++)
            {
                if (FrameResults[i].Station == Station)
                {
                    if (FrameResults[i].ResultValue <= MinForce)
                    {
                        MinForce = FrameResults[i].ResultValue;
                        result.ResultValue = MinForce;
                        result.Station = FrameResults[i].Station;
                    }
                }
            }

            return result;

        }

        public FramePointResult GetMinimumForce(string ComboName, ForceType ForceType, StationType StationType)
        {
            FramePointResult result = new FramePointResult();
            List<FramePointResult> FrameResults = GetFrameForceList(ComboName, ForceType);

            switch (StationType)
            {
                case StationType.First:
                    var MinStation = FrameResults.Select(p => p.Station).Min();
                    result = GetMinimumForce(ComboName, ForceType, MinStation);
                    break;
                case StationType.Last:
                    var MaxStation = FrameResults.Select(p => p.Station).Max();
                    result = GetMinimumForce(ComboName, ForceType, MaxStation);
                    break;
            }

            return result;
        }

        public FramePointResult GetMaximumAbsoluteForce( string ComboName, ForceType ForceType)
        {
            FramePointResult resultMax = GetMaximumForce( ComboName, ForceType);
            FramePointResult resultMin = GetMinimumForce( ComboName, ForceType);

            return Math.Abs(resultMax.ResultValue) > Math.Abs(resultMin.ResultValue) ? resultMax : resultMin;
        }

        public FramePointResult GetMaximumAbsoluteForce( string ComboName, ForceType ForceType, double Station)
        {
            FramePointResult resultMax = GetMaximumForce( ComboName, ForceType, Station);
            FramePointResult resultMin = GetMinimumForce( ComboName, ForceType, Station);

            return Math.Abs(resultMax.ResultValue) > Math.Abs(resultMin.ResultValue) ? resultMax : resultMin;
        }

        public FramePointResult GetMaximumAbsoluteForce( string ComboName, ForceType ForceType, StationType StationType)
        {
            FramePointResult resultMax = GetMaximumForce(ComboName, ForceType, StationType);
            FramePointResult resultMin = GetMinimumForce(ComboName, ForceType, StationType);

            return Math.Abs(resultMax.ResultValue) > Math.Abs(resultMin.ResultValue) ? resultMax : resultMin;
        }


        private List<FramePointResult> GetFrameForceList(string ComboName, ForceType ForceType)
        {
            EtabsModel.Results.Setup.DeselectAllCasesAndCombosForOutput();
           var ret1=  EtabsModel.Results.Setup.SetComboSelectedForOutput(ComboName);
           
            int NumberResults = 0;
            string[] _Obj = null;
            double[] _ObjSta = null;
            string[] _Elm = null;
            double[] _ElmSta = null;
            string[] _LoadCase = null;
            string[] _StepType = null;
            double[] _StepNum = null;
            double[] _P = null;
            double[] _V2 = null;
            double[] _V3 = null;
            double[] _T = null;
            double[] _M2 = null;
            double[] _M3 = null;

            eItemTypeElm elementType = eItemTypeElm.ObjectElm;
           var ret2 = EtabsModel.Results.FrameForce(this.Name, elementType,
           ref NumberResults,
           ref _Obj,
           ref _ObjSta,
           ref _Elm,
           ref _ElmSta,
           ref _LoadCase,
           ref _StepType,
           ref _StepNum,
           ref _P,
           ref _V2,
           ref _V3,
           ref _T,
           ref _M2,
           ref _M3);

           List<FramePointResult> outputList = new List<FramePointResult>();

           if (NumberResults >0)
           {
               List<double> Values = new List<double>();
               List<double> Stations = ArrayToListConverter.Convert<double>(_ObjSta);

               switch (ForceType)
               {
                   case ForceType.Fx:
                       Values = ArrayToListConverter.Convert<double>(_P);

                       break;
                   case ForceType.Fy:
                       Values = ArrayToListConverter.Convert<double>(_V2);
                       break;
                   case ForceType.Fz:
                       Values = ArrayToListConverter.Convert<double>(_V3);
                       break;
                   case ForceType.Mx:
                       Values = ArrayToListConverter.Convert<double>(_T);
                       break;
                   case ForceType.My:
                       Values = ArrayToListConverter.Convert<double>(_M2);
                       break;
                   case ForceType.Mz:
                       Values = ArrayToListConverter.Convert<double>(_M3);
                       break;

               }

               
               for (int i = 0; i < Values.Count; i++)
               {
                   outputList.Add(new FramePointResult() { ResultValue = Values[i], Station = Stations[i] });
               } 
           }

           return outputList;
        }

    }
}
