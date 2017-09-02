using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    /// <summary>
    /// this interface is used to instansiate the following methods
    /// </summary>
    public interface IElectionInterface
    {
        //reads in the xml file
        void SetupConfigData();
        //processes data
        void RunProducerConsumer();
        //displays data
        void DisplayAll();
    }
}
