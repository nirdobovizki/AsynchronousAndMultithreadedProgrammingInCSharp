namespace Chapter14
{ 
   public class Listing8
   {
      private async IAsyncEnumerable<int> GetNumbers(Stream stream)  
      {
         var buffer = new byte[4];
         while(await stream.ReadAsync(buffer, 0, 4) == 4)  
         {
            var number = BitConverter.ToInt32(buffer);
            yield return number;
         }
      }
   
      public async Task ProcessStream(Stream stream)  
      {
         await foreach(var number in GetNumbers(stream))  
         {
            Console.WriteLine(number);
         }
      }
   }
}