using ETABS2016;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.Interop.Entities.Group
{
    public class GroupManager
    {

        cSapModel EtabsModel;

        public GroupManager(cSapModel EtabsModel)
        {
            this.EtabsModel = EtabsModel;
        }


        public List<string> GetAllGroupNamesInModel()
        {
            int NumberResults = 0;
            string[] _Names = null;
            EtabsModel.GroupDef.GetNameList(ref NumberResults, ref _Names);
            return _Names.ToList();
        }

        public List<GroupData> GetGroupDataForFrames(List<string> FrameNames, string GroupNamePrefix)
        {
            List<GroupData> groupData = new List<GroupData>();

            //1. Get group names
            List<string> groupNames = GetAllGroupNamesInModel();

            //2. For each group select all elements and get corresponding frame names

            List<GroupData> allGroups = new List<GroupData>();

            foreach (var grpName in groupNames)
            {

                if (grpName.StartsWith(GroupNamePrefix))
                {
                    int NumberResults = 0;
                    string[] _ObjNames = null;
                    int[] _ObjType = null;
                    List<string> thisGroupElements = new List<string>();


                    EtabsModel.GroupDef.GetAssignments(grpName, ref NumberResults, ref _ObjType, ref _ObjNames);
                    if (NumberResults > 0)
                    {
                        for (int i = 0; i < NumberResults; i++)
                        {
                            //1 = Point object
                            //2 = Frame object
                            //3 = Cable object
                            //4 = Tendon object
                            //5 = Area object
                            //6 = Solid object
                            //7 = Link object


                            if (_ObjType[i] == 2 && FrameNames.Contains(_ObjNames[i]))
                            {
                                thisGroupElements.Add(_ObjNames[i]);
                            }
                        }
                        if (thisGroupElements.Count > 0)
                        {
                            GroupData gd = new GroupData() { Name = grpName, Elements = thisGroupElements };
                            allGroups.Add(gd);
                        }
                    }
                }
            }

            return allGroups;
        }

        public GroupData GetGroupDataForFrames(string GroupName)
        {

            GroupData gd = null;

            int NumberResults = 0;
            string[] _ObjNames = null;
            int[] _ObjType = null;
            List<string> thisGroupElements = new List<string>();


            EtabsModel.GroupDef.GetAssignments(GroupName, ref NumberResults, ref _ObjType, ref _ObjNames);
            if (NumberResults > 0)
            {
                for (int i = 0; i < NumberResults; i++)
                {
                    //1 = Point object
                    //2 = Frame object
                    //3 = Cable object
                    //4 = Tendon object
                    //5 = Area object
                    //6 = Solid object
                    //7 = Link object


                    if (_ObjType[i] == 2)
                    {
                        thisGroupElements.Add(_ObjNames[i]);
                    }
                }
                if (thisGroupElements.Count > 0)
                {
                    gd = new GroupData() { Name = GroupName, Elements = thisGroupElements };

                }

            }


            return gd;
        }


    }
}
