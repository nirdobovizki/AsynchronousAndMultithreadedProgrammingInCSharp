using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter02
{

   public class YieldDemo2
   {
         private IEnumerable<int> YieldDemo()
         {
            yield return 1;
            yield return 2;
         }
         
         public void UseYieldDemo()
         {
            foreach(var current in YieldDemo())
            {
                  Console.WriteLine($"Got {current}");
            }
         }
   }
}
