using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter04
{

    public class Listing3
    {
        public void RunAndWait()
        {
            var threads = new Thread[3];
            for (int i = 0; i < 3; ++i)
            {
                threads[i] = new Thread(DoWork);
                threads[i].Start();
            }
            foreach (var current in threads)
            {
                current.Join();
            }
            Console.WriteLine("Finished");
        }

        private void DoWork()
        {
            Console.WriteLine("Doing work");
        }
    }
}
