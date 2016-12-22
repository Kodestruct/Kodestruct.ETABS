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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.Interop.Entities.Point
{
    public class EtabsNode : EtabsPoint
    {
        protected cSapModel EtabsModel { get; set; }


        public EtabsNode(string Name,
        double X,
        double Y,
        double Z
        )
            : base(Name, X, Y, Z)
        {
        }

        public EtabsNode(cSapModel EtabsModel, string Name)
            : base(Name)
        {
            this.EtabsModel = EtabsModel;

            double _X=0;
            double _Y=0;
            double _Z = 0; 

            EtabsModel.PointObj.GetCoordCartesian(Name, ref _X, ref _Y, ref _Z);
             X =_X ;
             Y =_Y ;
             Z =_Z ;
        }
    }
}
