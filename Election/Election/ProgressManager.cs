using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    public class ProgressManager
    {
        /// <summary>
        /// counts all the items left in the que
        /// </summary>
        private int itemsRemaining;
        /// <summary>
        /// this iis locked for a mutex control ensuring no crash when each thread tries to accsess 
        /// </summary>
        public int ItemsRemaining 
        {
            get
            {
                return itemsRemaining;
            }

            set
            {
                
                lock (this)
                {
                    itemsRemaining = value;
                }
            }
        }
        /// <summary>
        /// pre set the remaining items to 0
        /// </summary>
        public ProgressManager()
        {
            this.ItemsRemaining = 0;
        }
        /// <summary>
        /// find out the actual items remaining
        /// </summary>
        /// <param name="items"></param>
        public ProgressManager(int items)
        {
            this.ItemsRemaining = items;
        }
    }
}
