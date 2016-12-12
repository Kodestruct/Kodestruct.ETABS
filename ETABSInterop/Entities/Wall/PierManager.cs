using ETABS2016;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.Interop.Entities.Wall
{
    public class PierManager
    {

        cSapModel EtabsModel;

        public PierManager(cSapModel EtabsModel)
        {
            this.EtabsModel = EtabsModel;
        }

        public List<string> GetAllPierNamesInModel()
        {
            int NumberResults = 0;
            string[] _Names = null;
            string[] _Labels = null;
            string[] _Stories = null;
            EtabsModel.AreaObj.GetLabelNameList(ref NumberResults, ref _Names, ref _Labels, ref _Stories);
            return _Names.ToList();
        }
    }
}
