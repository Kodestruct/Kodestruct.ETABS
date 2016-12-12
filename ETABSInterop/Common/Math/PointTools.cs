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
    public class PointTools
    {
        public static double DistanceBetweenPoints(Point3D PointI, Point3D PointJ)
        {
            double dx = AbsDxBetweenPoints(PointI,PointJ);
            double dy = AbsDyBetweenPoints(PointI,PointJ);
            double dz = AbsDzBetweenPoints(PointI,PointJ);

            return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2) + Math.Pow(dz, 2));
        }
        public static double AbsDxBetweenPoints(Point3D PointI, Point3D PointJ)
        {
            return Math.Abs(PointJ.X - PointI.X);
        }
        public static double AbsDyBetweenPoints(Point3D PointI, Point3D PointJ)
        {
            return Math.Abs(PointJ.Y - PointI.Y);
        }
        public static double AbsDzBetweenPoints(Point3D PointI, Point3D PointJ)
        {
            return Math.Abs(PointJ.Z - PointI.Z);
        }
    }
}
