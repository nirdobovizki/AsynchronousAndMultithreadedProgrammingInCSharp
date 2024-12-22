using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter13
{

   public class Listing4
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
		private static object _dictLock = new();

		public void Method(int itemId)
       {
            Item? item;
            bool exists;
            lock(_dictLock)  
            {
               exists = _dictionary.TryGetValue(itemId, out item);
            }  
            if(!exists)
            {
				Console.WriteLine($"Created item {itemId}");
				item = CreateAndInitilizeItem(itemId);
               lock(_dictLock)  
               {
                  _dictionary[itemId] = item;  
               }
            }
			else
			{
				Console.WriteLine($"Item {itemId} returned from cache");
			}

		}
	}
}
