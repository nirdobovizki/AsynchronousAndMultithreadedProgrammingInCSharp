using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Chapter08
{

   public class Listing3
   {
       public void Method()
       {
            Console.WriteLine("Repeating test 5 times");
            for (int j = 0; j < 5; ++j)
            {
               var sw = Stopwatch.StartNew();
            
               var threads = new Thread[1000];
               for (int i = 0; i < 1000; i++)
               {
                  threads[i] = new Thread(() => Thread.Sleep(1000));
                  threads[i].Start();
               }
               foreach (var current in threads) 
                  current.Join();
               sw.Stop();
               Console.WriteLine($"Total time with 1000 threads: {sw.ElapsedMilliseconds}ms");
            }
       }
   }
}
