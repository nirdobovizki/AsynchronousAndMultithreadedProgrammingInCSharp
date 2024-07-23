using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter05
{

   public class Listing8
   {
       public void Method()
       {
            var thread = new Thread(async ()=>
            {
                var result = await GetResult("my query");
                DoSomething(result);
            });
            thread.Name = "Query thread";
            thread.Start();
       }

		// This method is not thread safe, keep reading for the correct version
		private Dictionary<string, string> _cache = new();
		public async Task<string> GetResult(string query)
		{
			if (_cache.TryGetValue(query, out var cacheResult))
				return cacheResult;
			var http = new HttpClient();
			var result = await http.GetStringAsync("https://example.com?" + query);
			_cache[query] = result;
			return result;
		}

		private void DoSomething(string s)
		{

		}
	}
}
