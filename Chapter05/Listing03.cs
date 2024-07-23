using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter05
{

   public class Listing3
   {
         public void Read10Files()
         {
            var tasks = new Task[10];
            for(int i=0;i<10;++i)
            {
               var icopy = i;
               tasks[i] = Task.Run(()=>File.ReadAllBytes($"{icopy}.txt"));
            }
            Task.WaitAll(tasks);
         }
   }
}
