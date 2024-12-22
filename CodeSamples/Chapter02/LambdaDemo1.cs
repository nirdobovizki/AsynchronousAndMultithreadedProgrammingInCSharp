namespace Chapter02
{
    public class LambdaDemo1
    {
        private System.Timers.Timer? _timer;

        public void InitTimer()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += (sender, args) => Console.WriteLine("Elapsed");
            _timer.Enabled = true;
        }
    }
}