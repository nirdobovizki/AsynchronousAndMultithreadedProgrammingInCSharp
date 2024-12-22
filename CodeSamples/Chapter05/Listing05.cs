using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter05
{

   public class Listing5
   {
         public void Process10Files()
         {
            var tasks = new Task[10];
            for(int i=0;i<10;++i)
            {
               var icopy = i;
               tasks[i] = Task.Run(async ()=>
               {
                   await File.ReadAllBytesAsync($"{icopy}.txt");
                   Console.WriteLine("Doing something with the file’s content");
               });
            }
            Task.WaitAll(tasks);
         }
   }
}
