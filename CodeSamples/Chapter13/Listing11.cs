using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Chapter13
{

   public class Listing11
   {
       public void Method()
       {
            BlockingCollection<int> blockingCollection = new BlockingCollection<int>();
            Thread[] workers =  new Thread[10];
            for(int i=0; i<workers.Length; i++)  
            {
               workers[i] = new Thread(threadNumber =>
               {
                  var rng = new Random((int)threadNumber);
                  int count = 0;
                  foreach (var currentValue in
                        blockingCollection.GetConsumingEnumerable())
                  {
                     Console.WriteLine($"thread {threadNumber} value {currentValue}");
                     Thread.Sleep(rng.Next(500));
                     count++;
                  }
                  Console.WriteLine($"thread {threadNumber}, total {count} items");
               });
               workers[i].Start(i);
            }
            for(int i=0;i<100;i++)  
            {
               blockingCollection.Add(i);
            }
            blockingCollection.CompleteAdding();  
            foreach (var curentThread in workers)  
               curentThread.Join();
       }
   }
}
