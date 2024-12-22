using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter11
{

   public class Listing9
   {
       public async Task Method()
       {
            Console.WriteLine($"1: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(500);
            Console.WriteLine($"2: {Thread.CurrentThread.ManagedThreadId}");
       }
   }
}
