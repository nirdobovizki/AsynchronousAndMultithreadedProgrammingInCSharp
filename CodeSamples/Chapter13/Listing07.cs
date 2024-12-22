using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Chapter13
{

   public class Listing7
   {
		public class Item
		{
			public int Id { get; set; }
		}

		Item CreateAndInitilizeItem(int itemId)
		{
			return new Item() { Id = itemId };
		}

		private static ConcurrentDictionary<int, Item> _dictionary = new();

		public void Method(int itemId)
       {
            if(!_dictionary.TryGetValue(itemId, out var item))
            {
               item = CreateAndInitilizeItem(itemId);
               _dictionary.TryAdd(itemId,item);
            }
       }
   }
}
