// ChannelAsyncCollection 
// From the book C# Concurreny by Nir Dobovizki
// Based on Listing 14.9 from chapter 14
// Get the book from Manning https://www.manning.com/books/csharp-concurrency
// or from Amazon https://www.amazon.com/C-Concurrency-Asynchronous-multithreaded-programming/dp/1633438651
// The author web site is https://nirdobovizki.com/tech-books/   

using System.Threading.Channels;

namespace NirDobovizki.CSharpConcurrency
{

    public class ChannelAsyncCollection<T>
    {
        private Channel<T> _channel = Channel.CreateUnbounded<T>();
        public void Add(T item)
        {
            _channel.Writer.TryWrite(item);
        }

        public void CompleteAdding()
        {
            _channel.Writer.Complete();
        }
        public async IAsyncEnumerable<T> GetAsyncConsumingEnumerable()
        {
            while (true)
            {
                T next;
                try
                {
                    next = await _channel.Reader.ReadAsync();
                }
                catch (ChannelClosedException)
                {
                    yield break;
                }
                yield return next;
            }
        }

    }
}