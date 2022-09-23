using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter04
{

    public class Listing5
    {
        public void RunInBackground()
        {
            for (int i = 0; i < 10; ++i)
            {
                ThreadPool.QueueUserWorkItem(RunInPool, i);
            }
        }

        private void RunInPool(object? parameter)
        {
            Console.WriteLine($"Hello from thread {parameter}");
        }
    }
}
