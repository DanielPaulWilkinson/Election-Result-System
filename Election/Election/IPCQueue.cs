namespace Election
{
    /// <summary>
    /// Dpendency ejection of PCQUEUE
    /// </summary>
    public interface IPCQueue
    {
        void enqueueItem(Work item);
        Work dequeueItem();
    }
}
