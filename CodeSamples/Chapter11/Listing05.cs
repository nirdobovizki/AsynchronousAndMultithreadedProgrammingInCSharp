using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter11
{

   public class Listing5
   {
       public void Method()
       {
            var thread = new Thread(()=>
            {
               _= DoSomethingAsync();
               while(true) Console.Write(".");
            });
            thread.IsBackground = true;
            thread.Start();
            Thread.Sleep(1000);
            
            async Task DoSomethingAsync()
            {
               Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
               await Task.Delay(500);
               Console.WriteLine($"Thread {Thread. CurrentThread.ManagedThreadId}");
            }
       }
   }
}
