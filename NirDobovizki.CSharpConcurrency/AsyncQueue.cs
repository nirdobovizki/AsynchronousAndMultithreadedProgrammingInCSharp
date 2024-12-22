// AsyncQueue 
// From the book C# Concurreny by Nir Dobovizki
// Based on Listing 10.7 from chapter 10
// Get the book from Manning https://www.manning.com/books/csharp-concurrency
// or from Amazon https://www.amazon.com/C-Concurrency-Asynchronous-multithreaded-programming/dp/1633438651
// The author web site is https://nirdobovizki.com/tech-books/   

namespace NirDobovizki.CSharpConcurrency
{
	public class AsyncQueue<T>
	{
		private Queue<TaskCompletionSource<T>>
		   _processorsWaitingForData = new();
		private Queue<T> _dataWaitingForProcessors = new();
		private object _lock = new object();

		public Task<T> Dequeue(CancellationToken cancellationToken)
		{
			lock (_lock)
			{
				if (_dataWaitingForProcessors.Count > 0)
				{
					return Task.FromResult(_dataWaitingForProcessors.Dequeue());
				}
				var tcs = new TaskCompletionSource<T>(
				   TaskCreationOptions.RunContinuationsAsynchronously);
				_processorsWaitingForData.Enqueue(tcs);
				if (cancellationToken.CanBeCanceled)
				{
					cancellationToken.Register(() =>
					{
						tcs.TrySetCanceled(cancellationToken);
					});
				}
				return tcs.Task;
			}
		}

		public void Enqueue(T value)
		{
			lock (_lock)
			{
				while (_processorsWaitingForData.Count > 0)
				{
					var nextDequqer = _processorsWaitingForData.Dequeue();
					if (nextDequqer.TrySetResult(value))
					{
						return;
					}
				}
				_dataWaitingForProcessors.Enqueue(value);
			}
		}
	}
}