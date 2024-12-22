namespace Chapter10
{
    public class Listing4
    {
        private Task<int> BackgroundWork()
        {
            var tcs = new TaskCompletionSource<int>();
            Task.Run(() =>
            {
                tcs.TrySetCanceled();
   
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