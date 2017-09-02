using Microsoft.VisualStudio.TestTools.UnitTesting;
using Election;
using ElectionTests.Helpers;
using TestedClass = Election.XMLFileReader;

namespace ElectionTests.Fixtures
{
    [TestClass]
   public  class TestFixture_XMLFileReader
    {
        TestedClass testedClass = null;

        [TestCleanup]
        public void TestsCleanup()
        {
            testedClass = null;
        }

        [TestMethod]
        public void Test_Read_Data_From_File_Method_File_Not_Exist()
        {
            //make random filename
            var fileName = "DOES_NOT_EXIST";

            // Instantiate an filereader object
            testedClass = new TestedClass();

            // Act
            var actualCyclist = testedClass.ReadTheElectionDataFromFile(new ConfigRecord(fileName));

            // Assert
            Assert.IsNull(actualCyclist);
        }
        [TestMethod]
        public void Test_Read_Constituency_Data_From_File_Method_File_Constituency_Exists_Is_Valid1()
        {
            Helper_Test_Read_Constituency_Data_From_File_Method_File_Exists_Is_Valid("Constituency-01.xml", Helper_KnownCandidateData.LookForConstituency01());
        }

        [TestMethod]
        public void Test_ReadConstituencyDataFromFile_Method_File_Constituency_Exists_Is_Valid3()
        {
            Helper_Test_Read_Constituency_Data_From_File_Method_File_Exists_Is_Valid("Constituency-03.xml", Helper_KnownCandidateData.LookForConstituency03());
        }

        [TestMethod]
        public void Test_ReadConstituencyDataFromFile_Method_File_Constituency_Exists_Is_Valid5()
        {
            Helper_Test_Read_Constituency_Data_From_File_Method_File_Exists_Is_Valid("Constituency-05.xml", Helper_KnownCandidateData.LookForConstituency05());
        }
        [TestMethod]
        [ExpectedException(typeof(System.Xml.XmlException))]
        public void Test_Read_Constituency_Data_From_File_Method_File_Exists_Is_Invalid()
        {
            // Arrange
            //this data file is corupt 
            var fileName = "Constituency-03-Invalid.xml";

            // Instantiate an XMLFileReader object
            testedClass = new TestedClass();

            // Act
        
            var ElectedCadidates = testedClass.ReadTheElectionDataFromFile(new ConfigRecord(fileName));

            // Assert
            // Should not reach here due to exception being raised, if reached then force the test to fail
            Assert.Fail("ERROR: should have thrown System.Xml.XmlException before reaching here!");
        }

        private void Helper_Test_Read_Constituency_Data_From_File_Method_File_Exists_Is_Valid(string fileName, Constituency ExpectedConstituency)
        {
            // Arrange
            
            testedClass = new TestedClass();

            // Act
            // Call the ReaDataFromFile() method to load and process the known cyclist from the XML format
            var actualConstituency = testedClass.ReadTheElectionDataFromFile(new ConfigRecord(fileName));

            // Assert
            // First check  properties
           Assert.AreEqual(ExpectedConstituency.Constituencyid, actualConstituency.Constituencyid);

            Assert.AreEqual(ExpectedConstituency.ReportConstituencyCandidates.AllCandidates.Count, actualConstituency.ReportConstituencyCandidates.AllCandidates.Count);


            for (var i = 0; i < ExpectedConstituency.ReportConstituencyCandidates.AllCandidates.Count; i++)
            {
                Assert.AreEqual(ExpectedConstituency.ReportConstituencyCandidates.AllCandidates[i].Party, actualConstituency.ReportConstituencyCandidates.AllCandidates[i].Party);
                Assert.AreEqual(ExpectedConstituency.ReportConstituencyCandidates.AllCandidates[i].Firstname, actualConstituency.ReportConstituencyCandidates.AllCandidates[i].Firstname);
                Assert.AreEqual(ExpectedConstituency.ReportConstituencyCandidates.AllCandidates[i].Secondname, actualConstituency.ReportConstituencyCandidates.AllCandidates[i].Secondname);
                Assert.AreEqual(ExpectedConstituency.ReportConstituencyCandidates.AllCandidates[i].Voteamount, actualConstituency.ReportConstituencyCandidates.AllCandidates[i].Voteamount);
            }
        }
    }
}
