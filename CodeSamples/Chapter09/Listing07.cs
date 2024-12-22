using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter09
{

   public class Listing7
   {
       public void Method()
       {
			var cancelTokenSource = new CancellationTokenSource();
			var shouldCancel = cancelTokenSource.Token;
			var thread = new Thread(BackgroundProc);
            Console.WriteLine("Starting, press any key to stop");
            thread.Start();
            Console.ReadKey();
            cancelTokenSource.Cancel();
            Console.WriteLine("Canceled, waiting for the thread to finish (might take up to one minute)");
            thread.Join();

            void BackgroundProc()
            {
               int i=0;
               while(true)
               {
                  if(shouldCancel.IsCancellationRequested) return;
                  ACaculationThatTakesOneMinute();
                  Console.WriteLine(i++);
               }
            }
            
            void ACaculationThatTakesOneMinute()
            {
               var result = 0;
               var start = DateTime.UtcNow;
               while((DateTime.UtcNow - start).TotalMinutes < 1)  
               {
                   result++;  
               }
            }
       }
   }
}
