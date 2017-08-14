using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.Interop.Entities.Wall
{
    public class PierData
    {
        public string Name { get; set; }
        public List<PierStoryData> StoryData { get; set; }

        public PierData(string Name)
        {
            this.Name = Name;
        }

        public PierData(string Name, List<PierStoryData> StoryData)
        {
            this.StoryData = StoryData;
            this.Name = Name;
        }
    }
}
