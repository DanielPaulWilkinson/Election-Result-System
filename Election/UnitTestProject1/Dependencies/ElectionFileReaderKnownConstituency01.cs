using Election;
using ElectionTests.Helpers;

namespace ElectionTests.Dependencies
{
    /// <summary>
    /// this method is used to return the data
    /// </summary>
    public class ElectionFileReaderKnownConstituency01 : IElectionReader
    {
        public Constituency ReadTheElectionDataFromFile(ConfigRecord configRecord)
        {
            return Helper_KnownCandidateData.LookForConstituency01();
        }
    }
}
