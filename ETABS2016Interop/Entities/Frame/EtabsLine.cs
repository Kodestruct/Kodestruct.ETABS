using Kodestruct.ETABS.v2016.Interop.Entities.Enums;
using Kodestruct.ETABS.v2016.Interop.Entities.Frame.Loads;
using Kodestruct.ETABS.v2016.Interop.Entities.Interfaces;
using Kodestruct.ETABS.v2016.Interop.Entities.Point;
using Kodestruct.ETABS.v2016.Interop.Common.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kodestruct.ETABS.v2016.Interop.Entities.Frame
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
