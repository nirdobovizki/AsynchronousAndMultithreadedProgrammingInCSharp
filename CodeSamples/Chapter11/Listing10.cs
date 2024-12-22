using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter11
{

   public class Listing10
   {
       public async Task Method()
       {
            Console.WriteLine($"1: {Thread.CurrentThread.ManagedThreadId}");
            await DoSomething().ConfigureAwait(false);
            Console.WriteLine($"2: {Thread.CurrentThread.ManagedThreadId}");
            
            async Task DoSomething()
            {
               Console.WriteLine("did something");
            }
       }
   }
}
