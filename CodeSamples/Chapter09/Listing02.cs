using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter09
{

   public class Listing2
   {
       public void Method()
       {
			bool isCancellationRequested = false;
			var thread = new Thread(BackgroundProc);
            thread.Start();
            Console.ReadKey();
            isCancellationRequested = true;  
            
            void BackgroundProc()
            {
               int i=0;
               while(true)
               {
                  if(isCancellationRequested) return;  
                  Console.WriteLine(i++);
               }
            }
       }
   }
}
