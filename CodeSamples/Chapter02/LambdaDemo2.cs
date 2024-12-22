namespace Chapter02
{
    public class LambdaDemo2
    {
        private System.Timers.Timer? _timer;

        private void HiddenMethodForLambda(
              object? sender, System.Timers.ElapsedEventArgs args)
        {
            Console.WriteLine("Elapsed");
        }

        public void InitTimer()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += HiddenMethodForLambda;
            _timer.Enabled = true;
        }
    }
}