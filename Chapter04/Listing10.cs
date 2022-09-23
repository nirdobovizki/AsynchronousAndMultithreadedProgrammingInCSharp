using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter04
{

   public class Listing10
   {
         public void GetIncorrectValue()
         {
         
            int theValue = 0;
         
            var threads = new Thread[2];
            for(int i=0;i<2;++i)
            {
               threads[i] = new Thread(()=>
               {
                  for(int j=0;j<5000000;++j)
                     ++theValue;
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
