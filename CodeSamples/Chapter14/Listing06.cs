using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Chapter14
{

   public class Listing6
   {
         private async IAsyncEnumerable<int> AsyncYieldDemo( 
            [EnumeratorCancellation] CancellationToken cancelationToken=default)
         {
            yield return 1;
            await Task.Delay(1000, cancelationToken);
            yield return 2;
         }
         
         public async Task UseYieldDemo()
         {
            var cancel = new CancellationTokenSource();
            cancel.Cancel();  
            await foreach(var current in 
                 AsyncYieldDemo().WithCancellation(cancel.Token))
            {
                  Console.WriteLine($"Got {current}");
            }
         }
   }
}
