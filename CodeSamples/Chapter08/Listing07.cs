using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Chapter08
{

   public class Listing7
   {
       public void Method()
       {
			Console.WriteLine("Repeating test 5 times");

			for (int j = 0; j < 5; ++j)
            {
               var sw = Stopwatch.StartNew();
            
               var tasks = new Task[1000];
               for (int i = 0; i < 1000; i++)
               {
                  tasks[i] = Task.Run(async () => await Task.Delay(1000));
               }
               Task.WaitAll(tasks);
               sw.Stop();
				Console.WriteLine($"Total time with 1000 tasks: {sw.ElapsedMilliseconds}ms");

			}
		}
   }
}
