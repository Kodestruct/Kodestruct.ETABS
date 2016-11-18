using Kodestruct.ETABS.v2016.Interop.Entities.Frame.ForceExtraction;
using Kodestruct.ETABS.v2016.Interop.Entities.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Kodestruct.ETABS.v2016.Interop
{
    public class DataFileManager
    {

        public void WriteReactionResultsToDataFile(List<FrameEnvelopeReactionResult> results, string FilePath)
        {
            var json = new JavaScriptSerializer().Serialize(results);
            using (StreamWriter file = new StreamWriter(FilePath))
            {
                file.Write(json);
            }
        }
    }
}
