   public class MyImmutableStack<T>
   {
      private record class StackItem(T Value, StackItem Next);
      private readonly StackItem? _top;
      public MyImmutableStack() {}
      private MyImmutableStack(StackItem? top)
      {
         _top = top;
      }
      public MyImmutableStack<T> Push(T item)
      {
         return new MyImmutableStack<T>(new StackItem(item,_top)); 
      }
      public MyImmutableStack<T> Pop(out T? item)
      {
         if(_top == null)
            throw new InvalidOperationException("Stack is empty");
         item = _top.Value;
         return new MyImmutableStack<T>(_top.Next);
      }
      public bool IsEmpty => _top == null;
   }
