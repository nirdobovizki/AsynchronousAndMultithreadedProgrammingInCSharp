using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter02
{

   public class YieldDemo3
   {
         public class YieldDemo_Enumerable : IEnumerable<int>
         {
            public IEnumerator<int> GetEnumerator()
            {
               return new YieldDemo_Enumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
               return new YieldDemo_Enumerator();
            }
         }
         
         public class YieldDemo_Enumerator : IEnumerator<int>
         {
            public int Current { get; private set; }
            
            private void Step0()
            {
               Current = 1;
            }
            private void Step1()
            {
               Current = 2;
            }
         
         
            int _step = 0;
            public bool MoveNext()
            {
               switch(_step)
               {
                  case 0:
                     Step0();
                     ++_step;
                     break;
                  case 1:
                     Step1();
                     ++_step;
                     break;
                  case 2:
                     return false;
               }
               return true;
            }
         
            object IEnumerator.Current => Current;
            public void Dispose() { }
            public void Reset() { }
         }
         public IEnumerable<int> YieldDemo()
         {
            return new YieldDemo_Enumerable();
         }
        public void UseYieldDemo()
        {
            foreach (var current in YieldDemo())
            {
                Console.WriteLine($"Got {current}");
            }
        }
    }
}
