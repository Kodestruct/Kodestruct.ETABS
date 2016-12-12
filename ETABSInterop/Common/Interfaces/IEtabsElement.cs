using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodestruct.ETABS.Interop.Entities.Interfaces
{
    public interface IEtabsElement
    {
        string Name { get; set; }
        string SectionName { get; set; }
    }
}
