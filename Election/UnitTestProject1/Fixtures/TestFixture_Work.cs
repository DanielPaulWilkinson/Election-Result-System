using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectionTests.Dependencies;
using ElectionTests.Helpers;
using TestedClass = Election.Work;

namespace ElectionTests.Fixtures
{
    [TestClass]
    public class TestFixture_Work
    {
        [TestMethod]
        public void Test_ReadData_Method_Correct_Constituency_Returned()
        {

            var ioHandler = new ElectionFileReaderKnownConstituency01();

            var testedClass = new TestedClass(null, ioHandler);

            var ExpectedConstituency = Helper_KnownCandidateData.LookForConstituency01();


            var ActualConstituency = testedClass.ReadData();


            Assert.AreEqual(ExpectedConstituency.Constituencyid, ActualConstituency.Constituencyid);

            Assert.AreEqual(ExpectedConstituency.ReportConstituencyCandidates.AllCandidates.Count, ActualConstituency.ReportConstituencyCandidates.AllCandidates.Count);

            for (var i = 0; i < ExpectedConstituency.ReportConstituencyCandidates.AllCandidates.Count; i++)
            {
                Assert.AreEqual(ExpectedConstituency.ReportConstituencyCandidates.AllCandidates[i].Party, ActualConstituency.ReportConstituencyCandidates.AllCandidates[i].Party);
                Assert.AreEqual(ExpectedConstituency.ReportConstituencyCandidates.AllCandidates[i].Firstname, ActualConstituency.ReportConstituencyCandidates.AllCandidates[i].Firstname);
                Assert.AreEqual(ExpectedConstituency.ReportConstituencyCandidates.AllCandidates[i].Secondname, ActualConstituency.ReportConstituencyCandidates.AllCandidates[i].Secondname);
                Assert.AreEqual(ExpectedConstituency.ReportConstituencyCandidates.AllCandidates[i].Voteamount, ActualConstituency.ReportConstituencyCandidates.AllCandidates[i].Voteamount);
            }

        }
    }
}
