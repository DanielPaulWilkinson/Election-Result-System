using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Election
{
    public class Producer
    {
        /// <summary>
        /// variable storing the amount of producer threads running
        /// </summary>
        private static int runningThreads = 0; 
        /// <summary>
        /// this locker is used as a mutex control so that each thread can get acsess to this in turn 
        /// </summary>
        private static object locker = new object();
        /// <summary>
        /// gives a simulaton of time taken to produce the work 
        /// </summary>
        private const int duration = 100; 
        /// <summary>
        /// Idenifies the producer
        /// </summary>
        private string id;
        /// <summary>
        /// this is the thread on which the producer runns
        /// </summary>
        public Thread T { get; private set; }
        /// <summary>
        /// Flags when a producer is finished or should be
        /// </summary>
        private bool finished; 
        /// <summary>
        /// sharing the pcqueue that this producer is currently working for
        /// </summary>
        private IPCQueue pcQueue; 
        /// <summary>
        /// Details of configuration data
        /// </summary>
        private ConfigData configFile; 
        /// <summary>
        /// sharing the interface for rreeading data
        /// </summary>
        private IElectionReader IOhandler;
        /// <summary>
        /// Gets and sets for running threads with locker for MUTEX control
        /// </summary>
        public static int RunningThreads
        {
            get
            {
                return runningThreads;
            }

            private set
            {
                lock (locker)
                {
                    runningThreads = value;
                }
            }
        }
        /// <summary>
        /// Gets and sets for running threads with locker for MUTEX control
        /// </summary>
        public bool Finished
        {
            get
            {
                return finished;
            }

            set
            {
                lock (this)
                {
                    finished = value;
                }
            }
        }
        /// <summary>
        /// Constructor of the producer
        /// </summary>
        /// <param name="id">ID of the thread</param>
        /// <param name="pcQueue">Sharing PCQueue</param>
        /// <param name="configFile">Getting xml file data</param>
        /// <param name="IOhandler">Sharing </param>
        public Producer(string id, IPCQueue pcQueue, ConfigData configFile, IElectionReader IOhandler)
        {
            this.id = id;//id of the producer
            finished = false; // Initially not finished
            this.pcQueue = pcQueue;
            //counter = 0; // Initial value for the work item counter]
            this.configFile = configFile;
            this.IOhandler = IOhandler;
            (T = new Thread(run)).Start(); // Create a new thread for this producer and get it started
            RunningThreads++; // Increment the number of running producer threads;
        }

        /// <summary>
        /// This method runs the threads and reads in from the configrecord where there is still records to be read.
        /// </summary>
        public void run()
        {
            ConfigRecord configRecord = null;

            // While not finished, generate a new work item and enqueue it on the PCQueue, output that this producer has
            // produced a new item (and what it is called)
            while (!Finished)
            {
                // Lock configuration file and obtain next filename to process
                // If there are no filenames left then set filename to null so that nothing is produced
                lock (configFile)
                {
                    if (configFile.NextRecord < configFile.configRecords.Count)
                    {
                        configRecord = configFile.configRecords[configFile.NextRecord++];
                    }
                    else
                    {
                        configRecord = null;
                    }
                }

                // only queue item if there is a config record to read
                if (configRecord != null)
                {
                    // Enqueue a new work item, increment the counter as this work is produced
                    pcQueue.enqueueItem(new Work(configRecord, IOhandler));

                    // Output a message to state that this producer has produced a work item
                    Console.WriteLine("Producer:{0} has created and enqueued Work Item:{1}", id, configRecord.ToString());
                }

                // Simulate producer activity running for duration milliseconds
                Thread.Sleep(duration);
            }

            // Decrement the number of running producer threads
            RunningThreads--;

            // Output that this producer has finished
            Console.WriteLine("Producer:{0} has finished", id);
        }
    }
}
