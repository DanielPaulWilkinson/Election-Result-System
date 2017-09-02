using Election;

namespace ElectionTests.Dependencies
{
    public class PCQueue_Dequeue : IPCQueue
    {
        public void enqueueItem(Work item)
        {
            //never called so i have left this alown
        }

        public Work dequeueItem()
        {
            // Dequeue a fake work item
            var work = new Work(new ConfigRecord("Constituency-01.xml"), new ElectionFileReaderKnownConstituency01());
            return work;
        }
    }
}
