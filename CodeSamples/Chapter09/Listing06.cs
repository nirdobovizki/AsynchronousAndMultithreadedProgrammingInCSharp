using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter09
{

   public class Listing6
   {
       public void Method()
       {
			var cancelTokenSource = new CancellationTokenSource();
			var shouldCancel = cancelTokenSource.Token;
			var thread = new Thread(BackgroundProc);
            thread.Start();
            Console.ReadKey();
            cancelTokenSource.Cancel();  
            
            void BackgroundProc()
            {
               int i=0;
               while(true)
               {
                  if(shouldCancel. IsCancellationRequested) return;  
                  Console.WriteLine(i++);
               }
            }
       }
   }
}
