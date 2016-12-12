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
 
using Kodestruct.ETABS.Interop.Entities.Enums;
using Kodestruct.ETABS.Interop.Entities.Frame.Loads;
using Kodestruct.ETABS.Interop.Entities.Interfaces;
using Kodestruct.ETABS.Interop.Entities.Point;
using Kodestruct.ETABS.Interop.Common.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kodestruct.ETABS.Interop.Entities.Frame
{
    public partial class EtabsLine : IEtabsElement
    {
        public string Name { get; set; }
        public EtabsNode StartNode { get; set; }
        public EtabsNode EndNode { get; set; }
        public string SectionName { get; set; }
        public double RollAngle { get; set; }
        public string MaterialName { get; set; }
        public EtabsSectionType SectionType { get; set; }
        public List<SapFrameDistributedLoad> Loads { get; set; }

        #region LengthProperty
        private double length;

        public double Length
        {
            get
            {

                EtabsNode i = this.StartNode;
                EtabsNode j = this.EndNode;
                Distance dist = new Distance(new Point3D(i.X, i.Y, i.Z), new Point3D(i.X, j.Y, j.Z));
                return dist.AbsoluteDistance;

            }

        }
        #endregion

        #region MemberType Property
        private EtabsMemberType memberType;

        public EtabsMemberType MemberType
        {
            get
            {
                return this.GetMemberType();
            }

        }

        private EtabsMemberType GetMemberType()
        {
            throw new NotImplementedException();
        }
        #endregion


        public EtabsLine(string Name)
        {
            this.Name = Name;
        }

        public EtabsLine(string Name, EtabsNode StartNode, EtabsNode EndNode)
        {
            this.Name = Name;
            this.StartNode = StartNode;
            this.EndNode = EndNode;
        }
    }
}
