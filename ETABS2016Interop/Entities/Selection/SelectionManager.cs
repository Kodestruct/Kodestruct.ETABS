using ETABS2016;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.v2016.Interop.Selection
{
    public partial class SelectionManager
    {

        public SelectionManager(cSapModel Model)
        {
            this.Model = Model;
        }

        cSapModel Model { get; set; }


    }
}
