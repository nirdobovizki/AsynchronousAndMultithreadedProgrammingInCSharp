using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter13
{

   public class Listing16
   {
       public void Method()
       {
            var stack1 = new MyImmutableStack<int> ();
            var stack2 = stack1.Push(1);
            Console.WriteLine("Pushed 1");
            var stack3 = stack2.Push(2);
            Console.WriteLine("Pushed 2");
            var Stack4 = stack3.Pop(out var item);
            Console.WriteLine($"Poped {item}");
       }
   }
}
