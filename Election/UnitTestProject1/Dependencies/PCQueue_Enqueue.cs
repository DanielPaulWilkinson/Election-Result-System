using Election;

namespace ElectionTests.Dependencies
{
    public class PCQueue_Enqueue : IPCQueue
    {
        //used to count the item calls 
        public int EnqueueItemCallCount { get; private set; }

        // Constructor of this class
        public PCQueue_Enqueue()
        {
            // Initially no calls to EnqueueItem method
            EnqueueItemCallCount = 0;
        }

        public void enqueueItem(Work item)
        {
            //when an item called increment this
            EnqueueItemCallCount++;
        }

        public Work dequeueItem()
        {
            // not called, however must return somthing 
            return null;
        }
    }
}
