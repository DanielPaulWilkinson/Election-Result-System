using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Election;
using ElectionTests.Dependencies;
using TestedClass = Election.Consumer;

namespace ElectionTests.Fixtures
{
    public class TextFixture_Consumer
    {
        [TestClass]
        public class TestFixture_Consumer
        {
            TestedClass testedClass = null;
            ProgressManager progressManager = null;
            ConstituencyList constituencyList = null;
            IPCQueue pcQueue = null;

            [TestCleanup]
            public void TestsCleanup()
            {
                testedClass = null;
                progressManager = null;
                constituencyList = null;
                pcQueue = null;
            }

            [TestMethod]
            public void Test_One_Thread_Created_Consumer()
            {
                // Arrange
                pcQueue = new PCQueue_Dequeue();
                progressManager = new ProgressManager();
                constituencyList = new ConstituencyList();
                testedClass = new TestedClass("CONSUMER", pcQueue, constituencyList, progressManager);
                var expectedThreadCount = 1;

                // Act
                Thread.Sleep(5000);

                var actualThreadCount = TestedClass.RunningThreads;

                testedClass.Finished = true;

                Thread.Sleep(1000);

                // Assert
                Assert.AreEqual(expectedThreadCount, actualThreadCount);
            }

            [TestMethod]
            public void Test_Run_Method_Cyclists_Created_Equals_Progress_Mananger_Accesses()
            {
                // Arrange
                pcQueue = new PCQueue_Dequeue();
                progressManager = new ProgressManager();
                constituencyList = new ConstituencyList();
                testedClass = new TestedClass("Consumer", pcQueue, constituencyList, progressManager);

                // Act
                Thread.Sleep(5000);

                testedClass.Finished = true;

                Thread.Sleep(1000);

                // Assert

                Assert.AreEqual(Math.Abs(progressManager.ItemsRemaining), constituencyList.ReportList.Count);
            }

            [TestMethod]
            public void Test_Run_Method_Null_Dequeued_Expect_No_ProgressManager_Accesses()
            {
                // Arrange
                pcQueue = new PCQueueNullDequeued();
                progressManager = new ProgressManager();
                constituencyList = new ConstituencyList();
                testedClass = new TestedClass("Consumer", pcQueue,constituencyList, progressManager);

                // Act

                Thread.Sleep(5000);

                testedClass.Finished = true;

                Thread.Sleep(1000);

                // Assert
                Assert.AreEqual(0, Math.Abs(progressManager.ItemsRemaining));
            }

            [TestMethod]
            public void Test_Run_Method_Null_Dequeued_Expect_No_Cyclists()
            {
                // Arrange
                pcQueue = new PCQueueNullDequeued();
                progressManager = new ProgressManager();
                constituencyList = new ConstituencyList();
                testedClass = new TestedClass("Consumer", pcQueue, constituencyList, progressManager);

                // Act

                Thread.Sleep(5000);

                testedClass.Finished = true;

                Thread.Sleep(1000);

                // Assert
                Assert.AreEqual(0, constituencyList.ReportList.Count);
            }
        }
    }
}
