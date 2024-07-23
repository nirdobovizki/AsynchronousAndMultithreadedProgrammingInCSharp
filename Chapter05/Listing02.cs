using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter05
{

   public class Listing2
   {
         public void Compute10Values()
         {
            var tasks = new Task[10];
            for(int i=0;i<10;++i)
            {
               tasks[i] = Task.Run(()=>Console.WriteLine("Calculating"));
            }
            Task.WaitAll(tasks);
         }
   }
}
