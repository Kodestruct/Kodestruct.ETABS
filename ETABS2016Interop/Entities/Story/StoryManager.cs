using ETABS2016;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.v2016.Interop.Entities.Story
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
