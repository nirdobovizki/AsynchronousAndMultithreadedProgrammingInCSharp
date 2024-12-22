namespace Chapter10
{
    public class Listing3
    {
        private Task<int> BackgroundWork()
        {
            var tcs = new TaskCompletionSource<int>();
            Task.Run(() =>
            {
                tcs.TrySetException(new Exception("oops"));
            });
            return tcs.Task;
        }

        public async Task RunDemo()
        {
            var result = await BackgroundWork();
            Console.WriteLine(result);
        }
    }
}