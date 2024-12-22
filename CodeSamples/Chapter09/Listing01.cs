using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter09
{

   public class Listing1
   {
        public void Method()
        {
            var thread = new Thread(BackgroundProc);
            thread.Start();
            Console.ReadKey();
        }
            
        void BackgroundProc()
        {
            int i=0;
            while(true)
            {
                Console.WriteLine(i++);
            }
        }
   }
}
