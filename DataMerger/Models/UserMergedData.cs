using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMerger.Models
{
    public class UserMergedData
    {
        public void MergeData(List<XmlUser> xmlUsers, List<CsvUser> csvUsers)
        {

        }

        public string Encode(string id)
        {
            Guid guid = new Guid(id);
            string encodedGuid = Convert.ToBase64String(guid.ToByteArray());
            return encodedGuid;
        }
    }
}
