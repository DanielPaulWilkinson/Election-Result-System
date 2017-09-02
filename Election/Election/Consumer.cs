using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Election
{
    public class Consumer
    {
        /// <summary>
        /// this variable counts the number of curret threads
        /// </summary>
        private static int runningThreads = 0;
        /// <summary>
        /// Locker used to control thread acsess
        /// </summary>
        private static object locker = new object(); 
        /// <summary>
        /// simulates time used to consume a work item from queue
        /// </summary>
        private const int duration = 100;
        /// <summary>
        /// Indentifyer of the consumer
        /// </summary>
        private string id;
        /// <summary>
        /// the thread which this instance is a consumer
        /// </summary>
        public Thread T { get; private set; }
        /// <summary>
        /// used to find out if there if it is finished or needs to continue to work
        /// </summary>
        private bool finished; 
        /// <summary>
        /// Shared PCQueue as this is where the work is coming from
        /// </summary>
        private IPCQueue pcQueue;
        /// <summary>
        /// The list of constituencies which when consumed the data will be added to
        /// </summary>
        private ConstituencyList ConstituencyList;
        /// <summary>
        /// progress manager reference
        /// </summary>
        private ProgressManager progManager;
        /// <summary>
        /// property getter and setters
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
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pcQueue"></param>
        /// <param name="constituencyList"></param>
        /// <param name="progManager"></param>
        public Consumer(string id, IPCQueue pcQueue, ConstituencyList constituencyList, ProgressManager progManager)
        {
            //the id of he thread
            this.id = id;
            //make sure it is not finished first
            finished = false;
            //reference to the queue
            this.pcQueue = pcQueue;
            //reference to the list
            this.ConstituencyList = constituencyList;
            //reference to the progress manager
            this.progManager = progManager;
            ///start the th threads
            (T = new Thread(run)).Start();
            //incriment the threads
            RunningThreads++;
        }
        /// <summary>
        /// This method runs the thread, dequeues the itesm and adds this data to the list
        /// </summary>
        public void run()
        {
            //While not finished
            while (!Finished)
            {
                // Dequeue a work item
                var item = pcQueue.dequeueItem();

                if (!ReferenceEquals(null, item))
                {
                    // Invoke the work item's ReadData() method, which returns a cyclist
                    Constituency Constituency = item.ReadData();

                    // Ensure null returns are ignored (will happen if data not in correct format or can't open file)
                    if (!ReferenceEquals(null, Constituency))
                    {
                        // Add this cyclist to the cyclist list (lock it while modifying) 
                        lock (ConstituencyList)
                        {
                            ConstituencyList.ReportList.Add(Constituency);
                        }
                        // Output to the console
                        Console.WriteLine("Consumer:{0} has consumed Work Item:{1}", id, item.configRecord.ToString());
                    }
                    else
                    {
                        // Output to the console
                        Console.WriteLine("Consumer:{0} has rejected Work Item:{1}", id, item.configRecord.ToString());
                    }

                    // show a time period where the consumer activity is running for duration milliseconds
                    Thread.Sleep(duration);
                    //take away from the count
                    progManager.ItemsRemaining--;
                }
            }

            // Decrement the number of running consumer threads
            RunningThreads--;

            // Output that this consumer has finished
            Console.WriteLine("Consumer:{0} has finished", id);
        }
    }
}
