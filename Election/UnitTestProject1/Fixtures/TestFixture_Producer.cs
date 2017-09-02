using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Election;
using ElectionTests.Dependencies;
using TestedClass = Election.Producer;

namespace ElectionTests.Fixtures
{
    [TestClass]
    public class TestFixture_Producer
    {
        TestedClass testedClass = null;
        ConfigData configData = null;
        PCQueue_Enqueue pcQueue = null;

        [TestCleanup]
        public void TestsCleanup()
        {
            testedClass = null;
            configData = null;
            pcQueue = null;
        }

        [TestMethod]
        public void Test_One_Thread_Created_Producer()
        {
            // Arrange the test 
            pcQueue = new PCQueue_Enqueue();
            //referance config data
            configData = new ConfigData();
            //construct the test class
            testedClass = new TestedClass("PRODUCER", pcQueue, configData, null);
            var expectedThreadCount = 1;

            // Act
            Thread.Sleep(5000);

            var actualThreadCount = TestedClass.RunningThreads;

            // finish
            testedClass.Finished = true;

            Thread.Sleep(1000);

            // Assert by presuming they are the same
            Assert.AreEqual(expectedThreadCount, actualThreadCount);
        }

        [TestMethod]
        public void Test_Run_Method_PCQueue_EnqueueItem_Never_Called()
        {
            // Use the method we have below and test if it is never called
            Helper_Assert(Helper_Arrange(0), Helper_Act());
        }

        [TestMethod]
        public void Test_Run_Method_PCQueue_EnqueueItem_Called_Once()
        {
            // Use the helper method and call it once
            Helper_Assert(Helper_Arrange(1), Helper_Act());
        }

        [TestMethod]
        public void Test_Run_Method_PCQueue_EnqueueItem_Called_Five_Times()
        {
            // Use the helper method and call it 5 times
            Helper_Assert(Helper_Arrange(5), Helper_Act());
        }
        /// <summary>
        /// this arranges the tests for calling
        /// </summary>
        /// <param name="configRecordsCount"></param>
        /// <returns></returns>
        private int Helper_Arrange(int configRecordsCount)
        {
            // instanciate the pcQueue
            pcQueue = new PCQueue_Enqueue();

            // Instantiate a new ConfigData 
            configData = new ConfigData();

            // Add ConfigRecord instances to ConfigData 
            for (int i = 0; i < configRecordsCount; i++)
            {
                configData.configRecords.Add(new ConfigRecord("NeverUsed"));
            }

            // Instantiate a new Producer object
            testedClass = new TestedClass("PRODUCER", pcQueue, configData, null);

            return configRecordsCount;
        }

        private int Helper_Act()
        {
            // Wait a few seconds to allow Producer thread to start
            Thread.Sleep(5000);

            // Signal Producer thread to finish
            testedClass.Finished = true;

            // wait for the Producer to finish
            Thread.Sleep(1000);

            return pcQueue.EnqueueItemCallCount;
        }
        private void Helper_Assert(int expected, int actual)
        {
            Assert.AreEqual(expected, actual);
        }
    }
}
