   public class MyStack<T>
   {
      private T?[] _data = new T[10];
      private int _top = -1;
      private object _lock = new();
       
      public void Push(T item)
      {
         lock(_lock)
         {
            if(_top == _data.Length-1) throw new Exception("Stack full");
            _top++;
            _data[_top] = item;
         }
      }
      public bool TryPop(out T? item)
      {
         if(_top==-1)
         {
             item = default(T);
             return false;
         }
         item = _data[_top];
         _data[_top] = default(T);
         _top--;
         return true;
      }
   }
