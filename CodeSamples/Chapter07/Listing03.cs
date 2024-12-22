using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter07
{

   public class Listing3
   {
         private object _lockA = new object();
         private object _lockB = new object();
         private int _a;
         private int _b;
         
         public int GetA()
         {
            lock(_lockA)
            {
               return _a;
            }
         }
         
         public int GetB()
         {
            lock(_lockB)
            {
               return _b;
            }
         }

		public Listing3(int a, int b)
		{
			_a = a;
			_b = b;
		}

	}
}
