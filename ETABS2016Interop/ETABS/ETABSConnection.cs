using ETABS2016;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.v2016.Interop 
{
    public static class ETABSConnection
    {
        public static cSapModel GetModel()
        {

            ETABS2016.cOAPI ETABSObject = (ETABS2016.cOAPI)Marshal.GetActiveObject("CSI.ETABS.API.ETABSObject");
            ETABS2016.cSapModel EtabsModel = ETABSObject.SapModel;

            return EtabsModel;
        }
    }
}
