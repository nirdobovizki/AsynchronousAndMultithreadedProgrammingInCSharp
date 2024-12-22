using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter04
{

    public class Listing6
    {
        public void RunInBackground()
        {
            Task.Run(RunInPool);
        }

        private void RunInPool()
        {
            Console.WriteLine("Do stuff");
        }
    }
}
