using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Election;
using ElectionTests.Helpers;
using TestedClass = Election.ConstituencyList;

namespace ElectionTests.Dependencies
{
    public class TextFixture_ConstituencyList
    {
        [TestMethod]
        public void Test_Invalid_Report()
        {
            // Arrange
            var testedClass = new TestedClass();

            // Act
            var actualCandidayeList = testedClass.ReportSelection("INVALID");

            // Assert
            Assert.IsNull(actualCandidayeList);
        }

        [TestMethod]
        public void Test_Method_No_Constituency_Report()
        {
            // Arrange
            var testedClass = new TestedClass();

            // Act
            var actualDataMeasuresList = testedClass.ReportSelection("Constituency");

            // Assert
            Assert.AreEqual(0, actualDataMeasuresList.Count);
        }

        [TestMethod]
        public void Test_Method_Three_Cyclists_Report()
        {
            Helper_Test_Method_Three_Constituencies("Constituency", Helper_KnownCandidateData.GetConstituencyReportFirst3());
        }

        private void Helper_Test_Method_Three_Constituencies(string reportType, List<Candidate> expectedCandidate)
        {
            // Arrange
            var testedClass = new TestedClass();

            testedClass.ReportList.Add(Helper_KnownCandidateData.LookForConstituency01());
            testedClass.ReportList.Add(Helper_KnownCandidateData.LookForConstituency03());
            testedClass.ReportList.Add(Helper_KnownCandidateData.LookForConstituency05());

            // Act
            var actualCandidateList = testedClass.ReportSelection(reportType);

            // Assert
            Assert.AreEqual(expectedCandidate.Count, actualCandidateList.Count);

            for (int i = 0; i < expectedCandidate.Count; i++)
            {
                Assert.AreEqual(expectedCandidate[i].Party, actualCandidateList[i].Party);
                Assert.AreEqual(expectedCandidate[i].Firstname, actualCandidateList[i].Firstname);
                Assert.AreEqual(expectedCandidate[i].Secondname, actualCandidateList[i].Secondname);
                Assert.AreEqual(expectedCandidate[i].Voteamount, actualCandidateList[i].Voteamount);
            }
        }
    }
}
