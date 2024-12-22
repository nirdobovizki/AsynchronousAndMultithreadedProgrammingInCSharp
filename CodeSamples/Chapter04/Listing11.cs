using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter04
{

   public class Listing11
   {
         public void GetCorrectValue() 
         {
            int theValue = 0;
            object theLock = new Object();
         
            var threads = new Thread[2];
            for(int i=0;i<2;++i)
            {
               threads[i] = new Thread(()=>
               {
                  for(int j=0;j<5000000;++j)
                  {
                     lock(theLock)
                     {
                        ++theValue;
                     }
                  }
               });
               threads[i].Start();
            }
         
            foreach(var current in threads) 
            { 
               current.Join();
            }
            Console.WriteLine(theValue);
         }
   }
}
