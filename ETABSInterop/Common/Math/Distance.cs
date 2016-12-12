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
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.Interop.Common.Mathematics
{
    public class Distance
    {
        private double dx;

        public double DeltaX
        {
            get { return dx; }
            set { dx = value; }
        }
        private double dy;

        public double DeltaY
        {
            get { return dy; }
            set { dy = value; }
        }
        private double dz;

        public double DeltaZ
        {
            get { return dz; }
            set { dz = value; }
        }
        

        public double AbsoluteDistance
        {
            get { return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2) + Math.Pow(dz, 2)); ; }
        }


        public Distance(Point3D PointI, Point3D PointJ)
        {
            dx = PointTools.AbsDxBetweenPoints(PointI, PointJ);
            dy = PointTools.AbsDyBetweenPoints(PointI, PointJ);
            dz = PointTools.AbsDzBetweenPoints(PointI, PointJ);

        }
    }
}
