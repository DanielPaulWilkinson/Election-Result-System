using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    public class ConfigData
    {
        /// <summary>
        /// Create new list of configrecords i.e xml files
        /// </summary>
        public List<ConfigRecord> configRecords { get; set; }
        /// <summary>
        /// use this to cycle through the records in the xml
        /// </summary>
        public int NextRecord { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        public ConfigData()
        {
            this.NextRecord = 0;
            configRecords = new List<ConfigRecord>();
        }
    }
}
