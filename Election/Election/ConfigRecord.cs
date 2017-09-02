using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    public class ConfigRecord
    {
        /// <summary>
        /// create a file name variable
        /// </summary>
        public String Filename { get; private set; }

        /// <summary>
        /// create a contructor
        /// </summary>
        /// <param name="Filename"></param>
        public ConfigRecord(String Filename)
        {
            this.Filename = Filename;
        }
        /// <summary>
        /// produce to string to be able to return a string value
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return String.Format("{0}", Filename);
        }
    }
}
