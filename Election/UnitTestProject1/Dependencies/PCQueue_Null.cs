using Election;

namespace ElectionTests.Dependencies
{
       public class PCQueueNullDequeued : IPCQueue
        {
            public void enqueueItem(Work item)
            {
                // is left as an empty stub since it is not called 
            }

            public Work dequeueItem()
            {
                // A null is dequeued
                return null;
            }
        }

}
