using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter05
{

   public class Listing10
   {
         private Dictionary<string,string> _cache = new();
         private object _cacheLock = new();
         public async Task<string> GetResult(string query)
         {
            lock(_cacheLock)
            {
                if(_cache.TryGetValue(query, out var cacheResult))
                   return cacheResult;
            }
            var http = new HttpClient();
            var result = await http.GetStringAsync("https://example.com?"+query);
            lock(_cacheLock)
            {
               _cache[query] = result;
            }
            return result;
         }
   }
}
