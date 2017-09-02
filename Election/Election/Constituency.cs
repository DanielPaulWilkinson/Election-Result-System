using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    public class Constituency
    {
        /// <summary>
        /// Holds the id of the constituency
        /// </summary>
        public String Constituencyid { get; set; }
        /// <summary>
        /// holds reference to the reports
        /// </summary>
        public ConstituencyReport ReportConstituencyCandidates { get; set; }
        /// <summary>
        /// constructor of the constituency class
        /// </summary>
        /// <param name="constituencyid"></param>
        public Constituency(String constituencyid)
        {
            this.Constituencyid = constituencyid;
            this.ReportConstituencyCandidates = null;
        }
        /// <summary>
        /// this method returns 
        /// </summary>
        /// <returns>The constituency ID</returns>
        public override string ToString()
        {
            return Constituencyid;
        }
    }
}
