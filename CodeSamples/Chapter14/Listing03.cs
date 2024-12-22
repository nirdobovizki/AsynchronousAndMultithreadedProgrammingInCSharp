using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter14
{

    public class Listing3
    {
        public class AsyncYieldDemo_Enumerable : IAsyncEnumerable<int>
        {
            public IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken _)
            {
                return new YieldDemo_Enumerator();
            }
        }

        public class YieldDemo_Enumerator : IAsyncEnumerator<int>
        {
            public int Current { get; private set; }

            private async Task Step0()
            {
                Current = 1;
            }
            private async Task Step1()
            {
                await Task.Delay(1000);
                Current = 2;
            }

            private int _step = 0;
            public async ValueTask<bool> MoveNextAsync()
            {
                switch (_step)
                {
                    case 0:
                        await Step0();
                        ++_step;
                        break;
                    case 1:
                        await Step1();
                        ++_step;
                        break;
                    case 2:
                        return false;
                }
                return true;
            }
            public ValueTask DisposeAsync() => ValueTask.CompletedTask;
        }

        public IAsyncEnumerable<int> AsyncYieldDemo()
        {
            return new AsyncYieldDemo_Enumerable();
        }

		public async Task UseAsyncYieldDemo()
		{
			await foreach (var current in AsyncYieldDemo())
			{
				Console.WriteLine($"Got {current}");
			}
		}

	}
}

