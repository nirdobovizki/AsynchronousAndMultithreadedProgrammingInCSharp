using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter09
{

   public class Listing8
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
			Console.WriteLine("Canceled, waiting for the thread to finish");
			thread.Join();

			void BackgroundProc()
            {
               int i=0;
               while(true)
               {
                  if(!ACaculationThatTakesOneMinute(cancelTokenSource.Token))
                      return;
                  Console.WriteLine(i++);
               }
            }
            
            bool ACaculationThatTakesOneMinute(CancellationToken shouldCancel)
            {
               var start = DateTime.UtcNow;
               var result = 0;
               while((DateTime.UtcNow - start).TotalMinutes < 1)
               {
                  if(shouldCancel.IsCancellationRequested)  
                     return false;
                  result++;
               }
               return true;
            }
       }
   }
}
