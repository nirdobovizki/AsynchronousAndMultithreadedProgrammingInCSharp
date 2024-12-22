using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Chapter08
{

   public class Listing9
   {
       public void Method()
       {
			Console.WriteLine("Repeating test 5 times");

			for (int j = 0; j < 5; ++j)
            {
               var items = Enumerable.Range(0, 1000).ToArray();
               var sw = Stopwatch.StartNew();
               Parallel.ForEach(items, 
                  (item)=>Thread.Sleep(1000));
               sw.Stop();
				Console.WriteLine($"Total time with 1000 items: {sw.ElapsedMilliseconds}ms");
			}
		}
   }
}
