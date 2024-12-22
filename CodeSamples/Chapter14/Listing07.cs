namespace Chapter14
{
    public class Listing7
    {
        private IEnumerable<int> GetNumbers(Stream stream)
        {
            var buffer = new byte[4];
            while (stream.Read(buffer, 0, 4) == 4)
            {
                var number = BitConverter.ToInt32(buffer);
                yield return number;
            }
        }

        public void ProcessStream(Stream stream)
        {
            foreach (var number in GetNumbers(stream))
            {
                Console.WriteLine(number);
            }
        }
    }
}