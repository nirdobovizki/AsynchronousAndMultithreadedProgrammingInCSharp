using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter09
{

   public class Listing10
   {
		public void Method()
		{
			var cancelTokenSource = new CancellationTokenSource();
			var shouldCancel = cancelTokenSource.Token;
			var task = GetTextFromServer(shouldCancel);
			Console.ReadKey();
			cancelTokenSource.Cancel();
			task.Wait();
		}
		
        public async Task<string>
            GetTextFromServer(CancellationToken canceledByUser)
         {
            var combined = CancellationTokenSource.CreateLinkedTokenSource(
               canceledByUser);  
            combined.CancelAfter(TimeSpan.FromSeconds(10));  
            using(var http = new HttpClient())
            {
                return await http.GetStringAsync("https://green-sand-036ea9c1e.4.azurestaticapps.net", 
                     combined.Token);  
            } 
         }
   }
}