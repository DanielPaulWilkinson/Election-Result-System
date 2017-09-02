using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Election
{
    /// <summary>
    /// use the interface with the methods for user interface
    /// </summary>
    class ConsoleBasedUI : IElectionInterface
    {
        /// <summary>
        /// share the fiel reader
        /// </summary>
        private IElectionReader IOhandler;
        /// <summary>
        /// share the config data
        /// </summary>
        private ConfigData configData;
        /// <summary>
        /// reference the list
        /// </summary>
        private ConstituencyList constituencyList;

        /// <summary>
        /// create the console constructor
        /// </summary>
        /// <param name="IOhandler"></param>
        public ConsoleBasedUI(IElectionReader IOhandler)
        {
            this.IOhandler = IOhandler;
            this.configData = null;
            this.constituencyList = null;
        }
        /// <summary>
        /// the run method is used to run the program
        /// </summary>
        public void Run()
        {
            //loads in the xml
            SetupConfigData();
            //run producer and the consumer wich loads data into memory
            RunProducerConsumer();
            //displays all regular candidates
            DisplayAll();
            //displays the elected winners
            DisplayAllWinners();
            //displays all parties and their votes
            Parties_And_Total_Votes();
            //displays the single winner
            The_Winner();
            //waits for the user to quit
            Console.WriteLine("Press any key to close");
            //reads the key input and exits the program
            Console.ReadKey();
        }
        /// <summary>
        /// mehtod used to load in the data
        /// </summary>
        public void SetupConfigData()
        {
            configData = new ConfigData();

            configData.configRecords.Add(new ConfigRecord("Constituency-01.xml"));
            configData.configRecords.Add(new ConfigRecord("Constituency-02.xml"));
            configData.configRecords.Add(new ConfigRecord("Constituency-03.xml"));
            configData.configRecords.Add(new ConfigRecord("Constituency-04.xml"));
            configData.configRecords.Add(new ConfigRecord("Constituency-05.xml"));
        }
        /// <summary>
        /// this method queues the data and loads it into memory for processing
        /// </summary>
        public void RunProducerConsumer()
        {
            //create the constituency
            constituencyList = new ConstituencyList();

            //create the progressmanager with the number of files to process
            ProgressManager progManager = new ProgressManager(configData.configRecords.Count);

            //create a message to show that we are up and running
            Console.WriteLine("Creating and starting all producers and consumers");

            //create the queue and specify that we cannot have more then 4 at one time
            var pcQueue = new PCQueue(4);

            //create consumers and producers which are ready once inisiated, will work on their own threads.
            Producer[] producers = { new Producer("P1", pcQueue, configData, IOhandler),
                                     new Producer("P2", pcQueue, configData, IOhandler) };

            Consumer[] consumers = { new Consumer("C1", pcQueue, constituencyList, progManager),
                                     new Consumer("C2", pcQueue, constituencyList, progManager) };

            // dont stop reading until the count has stopped
            while (progManager.ItemsRemaining > 0) ;

            //give a message to show that they have closed down
            Console.WriteLine("Shutting down all producers and consumers");

            //deactive the queue
            pcQueue.Active = false;

            //go through all producers and tell them to finish off & consumers
            foreach (var p in producers)
            {
                p.Finished = true;
            }
            foreach (var c in consumers)
            {
                c.Finished = true;
            }

            //make sure all of the running threads can stop ensuring their is no stranded ones.
            for (int i = 0; i < (Producer.RunningThreads + Consumer.RunningThreads); i++)
            {
                lock (pcQueue)
                {
                    // pules to make sure their is no waiting threads 
                    Monitor.Pulse(pcQueue);

                    //short time to make sure the threads can deactivate
                    Thread.Sleep(100);
                }
            }

            //shut down all producer and consumer threads
            while ((Producer.RunningThreads > 0) || (Consumer.RunningThreads > 0)) ;

            Console.WriteLine();
            Console.WriteLine("All producers and consumers shut down");
        }
        /// <summary>
        /// displays the elected winners
        /// </summary>
        public void DisplayAllWinners()
        {
            foreach (var cons in constituencyList.ReportSelection("Winning Candidate from - All Constituencys"))
            {
                Console.WriteLine(cons);
            }

            Console.WriteLine("Winning Candidate from - All Constituencys");
        }
        /// <summary>
        /// displays all candidatates
        /// </summary>
        public void DisplayAll()
        {
            foreach (var cons in constituencyList.ReportSelection("Constituency"))
            {
                Console.WriteLine(cons);
            }

            Console.WriteLine("Constituency");
        }
        /// <summary>
        /// displays all parites and their total votes
        /// </summary>
        public void Parties_And_Total_Votes()
        {
            foreach (var cons in constituencyList.ReportSelection("Parties And Total Votes"))
            {
                Console.WriteLine(cons);
            }

            Console.WriteLine("Parties And Total Votes");
        }
        /// <summary>
        /// only diplays the winner
        /// </summary>
        public void The_Winner()
        {
            foreach (var cons in constituencyList.ReportSelection("The Winner"))
            {
                Console.WriteLine(cons);
            }

            Console.WriteLine("The Winner");
        }
    }
}






