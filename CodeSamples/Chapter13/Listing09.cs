using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Chapter13
{

   public class Listing9
   {
        private static ConcurrentDictionary<string, int> _dictionary = new();
        
        static Listing9()
        {
            _dictionary["9"] = 0;
        }

         public void Increment(string key)
         {
			// *** This code is not thread-safe ***
			int prevValue = _dictionary[key];
            _dictionary[key] = prevValue+1;
            Console.WriteLine($"New value {prevValue+1}");
         }
   }
}
