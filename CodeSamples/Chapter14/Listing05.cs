using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Chapter14
{

   public class Listing5
   {
         private async IAsyncEnumerable<int> AsyncYieldDemo( 
            [EnumeratorCancellation] CancellationToken cancelationToken = default)  
         {
            yield return 1;
            await Task.Delay(1000, cancelationToken);
            yield return 2;
         }
         
         public async Task UseAsyncYieldDemo()
         {
            var cancel = new CancellationTokenSource();
            var collection = AsyncYieldDemo();
            await foreach(var current in 
                 collection.WithCancellation(cancel.Token))  
            {
                  Console.WriteLine($"Got {current}");
            }
         }
   }
}
