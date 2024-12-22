using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Chapter13
{

   public class Listing12
   {
       public async Task Method()
       {
            var ch = Channel.CreateUnbounded<int>();
            Task[] tasks = new Task[10];
            for(int i=0; i<10;++i)  
            {
               var threadNumber = i;
               tasks[i] = Task.Run(async () =>
               {
                  var rng = new Random((int)threadNumber);
                  int count = 0;
                  while (true)
                  {
                     try
                     {
                        var currentValue = await ch.Reader.ReadAsync();  
                        Console.WriteLine($"task {threadNumber} value {currentValue}");
                        Thread.Sleep(rng.Next(500));
                        count++;
                     } 
                     catch(ChannelClosedException)  
                     {
                        break;
                     }
                  }
                  Console.WriteLine($"task {threadNumber}, total {count} items");
               });
            }
            for (int i = 0; i < 100; i++)  
            {
               await ch.Writer.WriteAsync(i);
            }
            ch.Writer.Complete();  
            Task.WaitAll(tasks);  
       }
   }
}
