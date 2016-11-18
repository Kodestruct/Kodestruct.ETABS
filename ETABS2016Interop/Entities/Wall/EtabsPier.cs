using ETABS2016;
using Kodestruct.ETABS.v2016.Interop.Common.Lists;
using Kodestruct.ETABS.v2016.Interop.Entities.Enums;
using Kodestruct.ETABS.v2016.Interop.Entities.Frame.ForceExtraction;
using Kodestruct.ETABS.v2016.Interop.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.v2016.Interop.Entities
{
    public partial class EtabsPier : IEtabsElement
    {


        public EtabsPier(string Name)
        {
            this.Name = Name;
        }

        public string Name { get; set; }
        public string SectionName { get; set; }
        public string StoryName { get; set; }


    }
}
