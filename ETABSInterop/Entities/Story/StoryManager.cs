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

namespace Kodestruct.ETABS.Interop.Entities.Story
{
    public class StoryManager
    {

        cSapModel EtabsModel;

        public StoryManager(cSapModel EtabsModel)
        {
            this.EtabsModel = EtabsModel;
        }

        public List<string> GetAllStoryNamesInModel()
        {

     int NumStories        =0;
	 string[] _StoryNames      =null;
	 double[] _StoryElevations =null;
	 double[] _StoryHeights    =null;
	 bool[]   _IsMasterStory     =null;
	 string[] _SimilarToStory  =null;
	 bool[]   _SpliceAbove       =null;
	 double[] _SpliceHeight    =null;

     EtabsModel.Story.GetStories(
        ref NumStories,
        ref _StoryNames     ,
        ref _StoryElevations,
        ref _StoryHeights   ,
        ref _IsMasterStory  ,
        ref _SimilarToStory ,
        ref _SpliceAbove    ,
        ref _SpliceHeight   
         );
            return _StoryNames.ToList();
        }
    }
}
