   public class WithCancellation<T> : IAsyncEnumerable<T>
   {
      private IAsyncEnumerable<T> _originalEnumerable;  
      private CancellationToken _cancellationToken;  
         
      public WithCancellation(
          IAsyncEnumerable<T> originalEnumerable,
          CancellationToken cancellationToken)
      {
          _originalEnumerable = originalEnumerable;  
          _cancellationToken = cancellationToken;  
      }
      
      public IAsyncEnumerator<T> GetAsyncEnumerator(
          CancellationToken dontcare)
      {
         return _originalEnumerable.  
            GetAsyncEnumerator(_cancellationToken);  
      }
   } 
