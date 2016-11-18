using ETABS2016;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.v2016.Interop.Entities
{
    public class LoadCaseAndComboManager
    {
       
        cSapModel EtabsModel;

        public LoadCaseAndComboManager(cSapModel EtabsModel)
        {
            this.EtabsModel = EtabsModel;
        }

        //This is one of the following items in the eCNameType enumeration: 
        //LoadCase = 0
        //LoadCombo = 1

        public List<string> GetComboNames()
        {
                    int NumberResults = 0;
                    string[] _ComboNames = null;

                    EtabsModel.RespCombo.GetNameList(ref NumberResults, ref _ComboNames);
                    List<string> Combos = new List<string>(_ComboNames);

                    return Combos;
        }
    }
}
