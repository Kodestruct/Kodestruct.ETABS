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
using Kodestruct.ETABS.Interop.Entities.Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.Interop.Selection
{
    public partial class SelectionManager
    {
        public List<EtabsLine> GetSelectedFrames()
        {

            List<EtabsLine> sapLineList = new List<EtabsLine>();

            List<string> apSelectionNames = GetSelectedNames();


            foreach (var name in apSelectionNames)
            {
                    EtabsLine sapLine = new EtabsLine(name,Model);
                    sapLineList.Add(sapLine);
            }

            return sapLineList;
        }


        public List<string> GetSelectedFrameNames()
        {
            return GetSelectedNames();
        }

        private List<string>  GetSelectedNames()
        {
            int NumberItems = 0;
            string[] AllObjNames = null;


             Model.FrameObj.GetNameList(ref NumberItems, ref AllObjNames);
             List<string> SelectedFrameList = new List<string>();

             if (NumberItems == 0)
             {
                 throw new Exception("No selected members were found. Make sure a single instance of ETABS is running and that at least one member is selected.");
             }
             for (int i = 0; i < AllObjNames.Length; i++)
             {
                 bool isSelected = false;
                 Model.FrameObj.GetSelected(AllObjNames[i], ref isSelected );
                 if (isSelected == true)
                 {
                     SelectedFrameList.Add(AllObjNames[i]);
                 }
             }

             return SelectedFrameList;
        }

    }
}
