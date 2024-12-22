using System.Collections.Immutable;

namespace Chapter13
{
    public class Listing17
    {
        private ImmutableDictionary<string, int> _bookIdToQuantity = 
            ImmutableDictionary<string, int>.Empty;

        public bool TryToBuyBook(string bookId)
        {
            // *** This code is not thread-safe ***
            if (!_bookIdToQuantity.TryGetValue(bookId, out var copiesInStock))
                return false;
            if (copiesInStock == 0)
                return false;
            _bookIdToQuantity =
                _bookIdToQuantity.SetItem(bookId, copiesInStock - 1);
            return true;
        }
    }
}