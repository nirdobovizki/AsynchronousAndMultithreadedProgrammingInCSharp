using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter04
{

    public class Listing2
    {
        public void RunLotsOfThreads()
        {
            var threads = new Thread[100];
            for (int i = 0; i < 100; ++i)
            {
                threads[i] = new Thread(MyThread);
                threads[i].Start(i);
            }
        }
        private void MyThread(object? parameter)
        {
            Console.WriteLine($"Hello from thread {parameter}");
        }
    }
}
