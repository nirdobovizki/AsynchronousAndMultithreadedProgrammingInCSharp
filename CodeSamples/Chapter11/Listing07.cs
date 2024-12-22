using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter11
{

   public class Listing7
   {
       public async Task Method()
       {
            Console.WriteLine($"before await {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(500);
            Console.WriteLine($"before await {Thread.CurrentThread.ManagedThreadId}");
       }
   }
}
