using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter13
{

   public class Listing14
   {
       public void Method()
       {
            var stack = new MyStack<int>();
            stack.Push(1);
            Console.WriteLine("Pushed 1");
            stack.Push(2);
			Console.WriteLine("Pushed 2");
			stack.TryPop(out var item);
            Console.WriteLine($"Poped {item}");
       }
   }
}
