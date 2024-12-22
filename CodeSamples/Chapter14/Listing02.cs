using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter14
{

   public class Listing2
   {
         private async IAsyncEnumerable<int> AsyncYieldDemo()  
         {
            yield return 1;
            await Task.Delay(1000);  
            yield return 2;
         }
         
         public async Task UseAsyncYieldDemo()
         {
            await foreach(var current in AsyncYieldDemo())  
            {
                  Console.WriteLine($"Got {current}");
            }
         }
   }
}
