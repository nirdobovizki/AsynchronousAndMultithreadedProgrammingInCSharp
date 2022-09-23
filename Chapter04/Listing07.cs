using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter04
{

    public class Listing7
    {
        public void RunInBackground()
        {
            Task.Run(RunInPool);
        }

        private async Task RunInPool()
        {
            await Task.Delay(500);
            Console.WriteLine("Did async stuff");
        }
    }
}
