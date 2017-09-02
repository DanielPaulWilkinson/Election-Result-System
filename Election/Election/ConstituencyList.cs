using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace Election
{
    public class ConstituencyList
    {
        /// <summary>
        /// instanciate a public list of candidates 
        /// </summary>
        public List<Constituency> ReportList { get; set; }
        /// <summary>
        /// listing constituencies
        /// </summary>

        /// <summary>
        /// constructor
        /// </summary>
        public ConstituencyList()
        {
            //create list
            ReportList = new List<Constituency>();
        }
        /// <summary>
        /// This method queries the data in the reportlist using the LINQ language
        /// we get the correct report by string report type that is passed in
        /// the switch case
        /// </summary>
        /// <param name="reportType"></param>
        /// <returns>Candidate list</returns>
        public List<Candidate> ReportSelection(String reportType)
        {
            switch (reportType)
            {
                //this report all elected candidates
                case "Elected Candidates":
                    return (from guery in ReportList
                            from selectedCan in guery.ReportConstituencyCandidates.AllCandidates
                            group selectedCan by selectedCan.Party
                               into groups
                            select groups.MaxBy(p => p.Voteamount)).ToList();
                // this report shows all parties and their total votes
                case "Parties And Total Votes":
                    return (from c in ReportList
                            from selectedCan in c.ReportConstituencyCandidates.AllCandidates
                            group selectedCan by selectedCan.Party into g
                            orderby g.Sum(n => n.Voteamount) descending
                            select new Candidate(
                                g.Key,
                                g.First().Firstname,
                                g.First().Secondname,
                                g.Sum(N => N.Voteamount)
                                )).ToList();
                //the winner based on finding all candidates descending by votes and 
                //taking one back to the list 
                case "The Winner":
                    return (from Candidate in ReportList
                            from SelectedCandidate in Candidate.ReportConstituencyCandidates.AllCandidates
                            orderby SelectedCandidate.Voteamount descending
                            select new Candidate(
                                                 SelectedCandidate.Party,
                                                 SelectedCandidate.Firstname,
                                                 SelectedCandidate.Secondname,
                                                 SelectedCandidate.Voteamount)
                                                    ).Take(1).ToList();
                //else fails return a null value
                default:
                    return null;
            }
        }
        /// <summary>
        /// this method  allows me to view constituency names.
        /// </summary>
        /// <returns></returns>
        public List<Constituency> DisplayConstituencies()
        {
            return (from conname in ReportList
                    select new Constituency(
                                        conname.Constituencyid
                                             )).ToList();
        }
        /// <summary>
        /// Get the correct candidates based upon the selected constituency ID which is populated by the method abouve
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>A list of candidates based on ID of constituency</returns>
        public List<Candidate> DisplayCansFromCons(String ID)
        {
            return (from Candidate in ReportList
                    from SelectedCandidate in Candidate.ReportConstituencyCandidates.AllCandidates
                    where Candidate.Constituencyid == ID
                    select new Candidate(
                                         SelectedCandidate.Party,
                                         SelectedCandidate.Firstname,
                                         SelectedCandidate.Secondname,
                                         SelectedCandidate.Voteamount)
                                         ).ToList();
        }
        /// <summary>
        /// Displays winning candidate based on ID of the method avove when selected in the lstresults in formUI
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>A list of candidates based on ID of constituency</returns>
        public List<Candidate> DisplayWinningCansFromCons(String ID)
        {
            return (from q in ReportList
                    from selectedCan in q.ReportConstituencyCandidates.AllCandidates
                    where q.Constituencyid == ID
                    group selectedCan by selectedCan.Party into g
                    orderby g.Max(x => x.Voteamount) descending
                    select g.MaxBy(x => x.Voteamount)).Take(1).ToList();
        }
    }
}
