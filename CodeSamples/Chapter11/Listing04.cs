using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter11
{

   public class Listing4
   {
       public void Method()
       {
            var thread = new Thread(async ()=>
               {
                  Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
                  await Task.Delay(500);
                  Console.WriteLine($"Thread {Thread. CurrentThread.ManagedThreadId}");
               });
            thread.Start();
            Thread.Sleep(1000);
       }
   }
}
