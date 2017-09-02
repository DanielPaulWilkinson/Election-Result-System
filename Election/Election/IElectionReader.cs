using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    public interface IElectionReader
    {
        /// <summary>
        /// this interface is used to read all data from configrecord to a constituency
        /// </summary>
        /// <param name="configRecord"></param>
        /// <returns></returns>
       Constituency ReadTheElectionDataFromFile(ConfigRecord configRecord);
    }
}
