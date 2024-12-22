namespace Chapter10
{
    public class RequiresInit
    {
        private Task<int> _value;

        public RequiresInit()
        {
            var tcs = new TaskCompletionSource<int>();
            _value = tcs.Task;
            Task.Run(() =>
            {
                try
                {
                    Thread.Sleep(1000);
                    tcs.TrySetResult(7);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            });
        }
        public async Task<int> Add1()
        {
            var actualValue = await _value;
            return actualValue + 1;
        }
    }
}