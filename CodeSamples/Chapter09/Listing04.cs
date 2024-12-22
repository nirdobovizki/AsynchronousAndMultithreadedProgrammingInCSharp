using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter09
{

   public class Listing4
   {
		public class CancelFlag
		{
			private bool _isCancellationRequested;
			private object _lock = new();

			public void Cancel()
			{
				lock (_lock)
				{
					_isCancellationRequested = true;
				}
			}

			public bool IsCancellationRequested
			{
				get
				{
					lock (_lock)
					{
						return _isCancellationRequested;
					}
				}
			}
		}

		public void Method()
       {
			var shouldCancel = new CancelFlag();
			var thread = new Thread(BackgroundProc);
            thread.Start();
            Console.ReadKey();
            shouldCancel.Cancel();  
            
            void BackgroundProc()
            {
               int i=0;
               while(true)
               {
                  if(shouldCancel.IsCancellationRequested) return;  
                  Console.WriteLine(i++);
               }
            }
       }
   }
}
