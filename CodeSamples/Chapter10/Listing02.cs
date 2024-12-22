namespace Chapter10
{

    public class Listing2
    {
        private Task<int> BackgroundWork()
        {
            var tcs = new TaskCompletionSource<int>();
            Task.Run(() =>
            {
                tcs.TrySetResult(7);
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