using NirDobovizki.CSharpConcurrency;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter14
{

   public class Listing10
   {
       public async Task Method()
       {
            ChannelAsyncCollection <int> asyncCollection = 
               new ChannelAsyncCollection <int>();
            Task[] workers =  new Task[10];
            for(int i=0; i<workers.Length; i++)
            {
               var threadNumber = i;
               workers[i] = Task.Run(async () =>
               {
                  var rng = new Random((int)threadNumber);
                  int count = 0;
                  await foreach (var currentValue in
                        asyncCollection.GetAsyncConsumingEnumerable())
                  {
                     Console.WriteLine($"thread {threadNumber} value {currentValue}");
                     Thread.Sleep(rng.Next(500));
                     count++;
                  }
                  Console.WriteLine($"thread {threadNumber}, total {count} items");
               });
            }
            for(int i=0;i<100;i++)
            {
               asyncCollection.Add(i);
            }
            asyncCollection.CompleteAdding();
            await Task.WhenAll(workers); 
       }
   }
}
