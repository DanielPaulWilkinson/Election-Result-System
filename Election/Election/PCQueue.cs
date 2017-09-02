using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Election
{
    public class PCQueue : IPCQueue
    {
        /// <summary>
        /// Create list of work objects inside the que
        /// </summary>
        private Queue<Work> queue = new Queue<Work>();
        /// <summary>
        /// create a capacity
        /// </summary>
        public int Capacity { get; private set; }
        /// <summary>
        /// can only work when active
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        ///  Consructor
        /// </summary>
        public PCQueue()
        {
            //set defualt to 0
            Capacity = 0;
            Active = true;
        }
        /// <summary>
        /// Constructor with capacity boundry so that the queue cannot enter less than 1
        /// </summary>
        /// <param name="capacity"></param>
        public PCQueue(int capacity)
        {
            //ensure no -value
            this.Capacity = Math.Max(capacity, 0);
            //set to true
            Active = true;
        }

        public int queuedItemsCount()
        {
            return queue.Count;
        }
        /// <summary>
        /// This method enqueues work items
        /// </summary>
        /// <param name="item"></param>
        public void enqueueItem(Work item)
        {
            // this == the instance of pcqueue and use i as the lock
            lock (this)
            {
                //while active and has work count that work
                while (Active && (Capacity != 0) && (queue.Count == Capacity))
                {
                    Monitor.Wait(this);
                }

                // If this PCQueue is active it now has space for a work item so enqueue it 
                if (Active)
                {
                    queue.Enqueue(item);

                    // Use pulse to inform that the queue is now not empty
                    Monitor.Pulse(this);
                }
            }
        }
        /// <summary>
        /// this method removees and item from the queue list
        /// </summary>
        /// <returns>returns a work item</returns>
        public Work dequeueItem()
        {
            //created null work item
            Work item = null;

            // this == the instance of pcqueue and use i as the lock
            lock (this)
            {
                // While this PCQueue is active and empty, wait
                while (Active && (queue.Count == 0))
                {
                    Monitor.Wait(this);
                }
                //if active the queue has work so return that reference else return null
                if (Active)
                {
                    item = queue.Dequeue();
                    //show the queue is now not full
                    Monitor.Pulse(this);
                }
            }
            return item;
        }
    }
}
