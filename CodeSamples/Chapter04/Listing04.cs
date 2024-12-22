using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter04
{

    public class Listing4
    {
        public void RunInBackground()
        {
            ThreadPool.QueueUserWorkItem(RunInPool);
        }

        private void RunInPool(object? state)
        {
            Console.WriteLine("Do stuff");
        }
    }
}
