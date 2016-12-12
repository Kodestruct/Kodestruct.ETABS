using ETABS2016;
using Kodestruct.ETABS.Interop.Common.Lists;
using Kodestruct.ETABS.Interop.Entities.Enums;
using Kodestruct.ETABS.Interop.Entities.Frame.ForceExtraction;
using Kodestruct.ETABS.Interop.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.Interop.Entities
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
