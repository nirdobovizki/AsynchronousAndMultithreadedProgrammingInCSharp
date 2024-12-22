using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter02
{

   public class YieldDemo1
   {
         private IEnumerable<int> NoYieldDemo()
         {
            var result = new List<int>();
            result.Add(1);
            result.Add(2);
            return result;
         }
         
         public void UseNoYieldDemo()
         {
            foreach(var current in NoYieldDemo())
            {
                  Console.WriteLine($"Got {current}");
            }
         }
   }
}
