using NirDobovizki.CSharpConcurrency;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter11
{

   public class Listing8
   {
       public void Method()
       {
            SingleThreadSyncContext.Run(async ()=>
            {
               Console.WriteLine($"before await {Thread.CurrentThread.ManagedThreadId }");
               await Task.Delay(500);
               Console.WriteLine($"after await {Thread.CurrentThread.ManagedThreadId }");
            });
       }
   }
}
