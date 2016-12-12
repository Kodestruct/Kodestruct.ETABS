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
using System.Threading.Tasks;

namespace Kodestruct.ETABS.Interop.Entities.Enums
{
    public enum FrameDistributedLoadDirection
    {
        Local1axis = 1,  // 1 = Local 1 axis (only applies when CSys is Local)
        Local2axis = 2,  // 2 = Local 2 axis (only applies when CSys is Local)
        Local3axis = 3,  // 3 = Local 3 axis (only applies when CSys is Local)
        XGlobal = 4,  // 4 = X direction (does not apply when CSys is Local)
        YGlobal = 5,  // 5 = Y direction (does not apply when CSys is Local)
        ZGlobal = 6,  // 6 = Z direction (does not apply when CSys is Local)
        ProjectedX = 7,  // 7 = Projected X direction (does not apply when CSys is Local)
        ProjectedY = 8,  // 8 = Projected Y direction (does not apply when CSys is Local)
        ProjectedZ = 9,  // 9 = Projected Z direction (does not apply when CSys is Local)
        Gravity = 10, // 10 = Gravity direction (only applies when CSys is Global)
        ProjectedGravity = 11  // 11 = Projected Gravity direction (only applies when CSys is Global)
    }
}
