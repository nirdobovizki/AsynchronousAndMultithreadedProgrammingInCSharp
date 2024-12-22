using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter13
{

   public class Listing1
   {
        public class Item
        {
            public int Id { get; set; }
        }

		Item CreateAndInitilizeItem(int itemId)
        {
            return new Item() { Id = itemId };
        }

        private static Dictionary<int, Item> _dictionary = new();

	   public void Method(int itemId)
       {
            // *** This code is not thread-safe ***
            if(!_dictionary.TryGetValue(itemId, out var item))
            {
                Console.WriteLine($"Created item {itemId}");
               item = CreateAndInitilizeItem(itemId);
               _dictionary.Add(itemId,item);
            }
            else
            {
                Console.WriteLine($"Item {itemId} returned from cache");
            }
       }
   }
}
