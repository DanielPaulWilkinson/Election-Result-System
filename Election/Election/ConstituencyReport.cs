using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    /// <summary>
    /// this class is used to place the data into lists for processing
    /// </summary>
    public class ConstituencyReport
    {
        /// <summary>
        /// the report type is used to display the correct report.
        /// </summary>
        public string ReportType { get; set; }
        /// <summary>
        /// Creating a list to query with linq based upon every candidate(Across all constituencies)
        /// </summary>
        public List<Candidate> AllCandidates { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reportType"></param>
        public ConstituencyReport(String reportType)
        {
            this.ReportType = reportType;
            this.AllCandidates = null;

        }
        /// <summary>
        /// this method returns a string based upon the report type selected
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            String str = String.Format("\tReport: ");

            foreach (var m in AllCandidates)
            {
                str += String.Format("\n\t\t{0}", m.ToString());
            }
            return String.Format("Cyclist Report {0}:\n{1}", ReportType, str);
        }
    }
}