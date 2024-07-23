using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter05
{

   public class Listing1
   {
         public void Read10Files()
         {
            var tasks = new Task[10];
            for(int i=0;i<10;++i)
            {
                Console.WriteLine($" Reading {i}.txt");
               tasks[i] = File.ReadAllBytesAsync($"{i}.txt");
            }
            Task.WaitAll(tasks);
         }
   }
}
