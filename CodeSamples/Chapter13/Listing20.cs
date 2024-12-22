using System;
using System.Collections;
using System.Collections.Frozen;
using System.Collections.Generic;

namespace Chapter13
{

   public class Listing20
   {
       public void Method()
       {
            var numberNames = new Dictionary<int,string>
            {
               {1, "one"},
               {2, "two"}
            };
            var frozenDict = numberNames.ToFrozenDictionary();
       }
   }
}
