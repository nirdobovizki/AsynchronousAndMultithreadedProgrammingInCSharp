using System;
using System.Collections;
using System.Collections.Frozen;
using System.Collections.Generic;

namespace Chapter13
{

   public class Listing19
   {
       public void Method()
       {
            var data = new List<int> {1,2,3,4};
            var set = data.ToFrozenSet();
       }
   }
}
