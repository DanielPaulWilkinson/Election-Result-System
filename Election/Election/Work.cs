using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    public class Work
    {
        /// <summary>
        /// config records hold the xml file names
        /// </summary>
        public ConfigRecord configRecord { get; private set; } 
        /// <summary>
        /// connection to the xmlfile reader interface
        /// </summary>
        private IElectionReader IOhandler; 
        /// <summary>
        /// referenct to the constituency
        /// </summary>
        public Constituency ConstituencyData { get; private set; }

        /// <summary>
        /// Constructor of work, alows for multiple file reads
        /// </summary>
        /// <param name="data"></param>
        /// <param name="IOhandler"></param>
        public Work(ConfigRecord data, IElectionReader IOhandler)
        {
            ConstituencyData = null;
            this.configRecord = data; 
            this.IOhandler = IOhandler;
        }
        /// <summary>
        /// this method alows the program to read the data from file using the filenames
        /// </summary>
        /// <returns>Returns a consituency</returns>
        public Constituency ReadData()
        {
            return IOhandler.ReadTheElectionDataFromFile(configRecord);
        }
    } 
}
