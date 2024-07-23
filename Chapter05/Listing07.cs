using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter05
{

   public class Listing7
   {
        // This method is not thread safe, keep reading for the correct version
        private Dictionary<string,string> _cache = new();
        public async Task<string> GetResult(string query)
        {
            if(_cache.TryGetValue(query, out var cacheResult))
                    return cacheResult;
            var http = new HttpClient();
            var result = await http.GetStringAsync("https://example.com?"+query);
            _cache[query] = result;
            return result;
        }
   }
}
