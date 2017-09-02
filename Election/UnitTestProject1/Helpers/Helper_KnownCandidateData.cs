using System.Collections.Generic;
using Election;


namespace ElectionTests.Helpers
{
    public class Helper_KnownCandidateData
    {
        public static Constituency LookForConstituency01()
        {
            //create my helper data from this file 
            var constituency = new Constituency("Constituency-01");
            //create all reports and candidate lists
            constituency.ReportConstituencyCandidates = new ConstituencyReport("Sunderland North");
            constituency.ReportConstituencyCandidates.AllCandidates = new List<Candidate>();
            constituency.ReportConstituencyCandidates.AllCandidates.Add(new Candidate("Labour", "Fred", "Bloggs", 85));
            constituency.ReportConstituencyCandidates.AllCandidates.Add(new Candidate("Conservatives", "yoda", "traveling", 135));
            return constituency;
        }
        public static Constituency LookForConstituency03()
        {
            //create my helper data from this file 
            var constituency = new Constituency("Constituency-03");
            //create all reports and candidate lists
            constituency.ReportConstituencyCandidates = new ConstituencyReport("London");
            constituency.ReportConstituencyCandidates.AllCandidates = new List<Candidate>();
            constituency.ReportConstituencyCandidates.AllCandidates.Add(new Candidate("Labour", "Anth", "Heaton", 200));
            constituency.ReportConstituencyCandidates.AllCandidates.Add(new Candidate("Conservatives", "Johnny", "Ayre", 130));
            return constituency;
        }
        public static Constituency LookForConstituency05()
        {
            var constituency = new Constituency("Constituency-05");
            constituency.ReportConstituencyCandidates = new ConstituencyReport("Leeds");
            constituency.ReportConstituencyCandidates.AllCandidates = new List<Candidate>();
            constituency.ReportConstituencyCandidates.AllCandidates.Add(new Candidate("Labour", "Ed", "Miliband", 500));
            constituency.ReportConstituencyCandidates.AllCandidates.Add(new Candidate("Conservatives", "David", "Cameron", 12));
            return constituency;
        }
        public static List<Candidate> GetConstituencyReportFirst3()
        {
            var list = new List<Candidate>();
            list.Add(new Candidate("Labour", "Fred", "Bloggs", 85));
            list.Add(new Candidate("Conservatives", "yoda", "traveling", 135));
            list.Add(new Candidate("Labour", "Anth", "Heaton", 200));
            list.Add(new Candidate("Conservatives", "Johnny", "Ayre", 130));
            list.Add(new Candidate("Labour", "Ed", "Miliband", 500));
            list.Add(new Candidate("Conservatives", "David", "Cameron", 12));
            return list;
        }
    }
}
