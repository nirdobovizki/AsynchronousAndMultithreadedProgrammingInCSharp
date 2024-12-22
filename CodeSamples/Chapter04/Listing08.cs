using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter04
{

    public class Listing8
    {
        public async Task RunInBackground()
        {
            var tasks = new Task[10];
            for (int i = 0; i < 10; ++i)
            {
                tasks[i] = Task.Run(RunInPool);
            }
            await Task.WhenAll(tasks);
            Console.WriteLine("All finished");
        }

        private void RunInPool()
        {
            Console.WriteLine("Do stuff");
        }
    }
}
