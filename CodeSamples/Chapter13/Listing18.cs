using System.Collections.Immutable;

namespace Chapter13
{

    public class Listing18
    {

        private ImmutableDictionary<string, int> _bookIdToQuantity =
            ImmutableDictionary<string, int>.Empty;

		public bool TryToBuyBook(string bookId)
        {
            while (true)
            {
                if (!_bookIdToQuantity.TryGetValue(bookId,
                      out var copiesInStock))
                    return false;
                if (copiesInStock == 0)
                    return false;
                if (ImmutableInterlocked.TryUpdate(
                      ref _bookIdToQuantity, bookId,
                      copiesInStock - 1, copiesInStock))
                    return true;
            }
        }
    }
}
