using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Chapter13
{

   public class Listing10
   {
         private static ConcurrentDictionary<string, int> _dictionary = new();

        static Listing10()
        {
            _dictionary["10"] = 0;
        }
         
         public void Increment(string key)
         {
            while(true)
            {
               int prevValue = _dictionary[key];
                if (_dictionary.TryUpdate(key, prevValue + 1, prevValue))
                {
					Console.WriteLine($"New value {prevValue + 1}");
					break;
                }
            }
         }
   }
}
