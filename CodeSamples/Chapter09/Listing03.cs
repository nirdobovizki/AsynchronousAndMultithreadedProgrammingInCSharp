using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter09
{

   public class Listing3
   {
       public void Method()
       {
			var cancelLock = new object();
			bool isCancellationRequested = false;
			var thread = new Thread(BackgroundProc);
            thread.Start();
            Console.ReadKey();
            lock(cancelLock)  
            {
               isCancellationRequested = true;
            }
            
            void BackgroundProc()
            {
               int i=0;
               while(true)
               {
                  lock(cancelLock)  
                  {
                     if(isCancellationRequested) return;
                  }
                  Console.WriteLine(i++);
               }
            }
       }
   }
}
