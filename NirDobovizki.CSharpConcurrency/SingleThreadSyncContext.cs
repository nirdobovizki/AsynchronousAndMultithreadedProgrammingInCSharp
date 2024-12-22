// SingleThreadSyncContext 
// From the book C# Concurreny by Nir Dobovizki
// Based on Listing 11.6 from chapter 11
// Get the book from Manning https://www.manning.com/books/csharp-concurrency
// or from Amazon https://www.amazon.com/C-Concurrency-Asynchronous-multithreaded-programming/dp/1633438651
// The author web site is https://nirdobovizki.com/tech-books/   

using System.Collections.Concurrent;

namespace NirDobovizki.CSharpConcurrency
{

    public class SingleThreadSyncContext : SynchronizationContext
    {
        public static void Run(Func<Task> startup)
        {
            var prev = SynchronizationContext.Current;
            try
            {
                var ctxt = new SingleThreadSyncContext();
                SynchronizationContext.SetSynchronizationContext(ctxt);
                ctxt.Loop(startup);
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(prev);
            }
        }

        private BlockingCollection<(SendOrPostCallback call, object? state)>
           _queue = new();

        private void Loop(Func<Task> startup)
        {
            startup().ContinueWith(t => _queue.CompleteAdding());
            foreach (var next in _queue.GetConsumingEnumerable())
            {
                next.call(next.state);
            }
        }
        public override void Post(SendOrPostCallback d, object? state)
        {
            _queue.Add((d, state));
        }
        public override void Send(SendOrPostCallback d, object? state)
        {
            // not needed for async/await
            throw new NotImplementedException();
        }

        public override SynchronizationContext CreateCopy()
        {
            // not needed for async/await
            throw new NotImplementedException();
        }

        public override int Wait(IntPtr[] waitHandles,
           bool waitAll, int millisecondsTimeout)
        {
            // not needed for async/await
            throw new NotImplementedException();
        }
    }
}