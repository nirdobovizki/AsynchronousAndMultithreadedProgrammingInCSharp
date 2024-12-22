using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter07
{

   public class Listing2
   {
         private object _lock = new object();
         private int _a;
         private int _b;
         
         public int GetA()
         {
            lock(_lock)
            {
               return _a;
            }
         }
         
         public int GetB()
         {
            lock(_lock)
            {
               return _b;
            }
         }

        public Listing2(int a,int b)
        {
            _a = a;
            _b = b;
        }
	}
}
