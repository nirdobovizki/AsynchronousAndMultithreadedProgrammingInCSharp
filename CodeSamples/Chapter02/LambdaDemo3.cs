namespace Chapter02
{
    public class LambdaDemo3
    {
        private System.Timers.Timer? _timer;

        public void InitTimer()
        {
            int aVariable = 5;
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += (sender, args) => Console.WriteLine(aVariable);
            _timer.Enabled = true;
        }
    }
}