using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter07
{

   public class Listing10
   {
        private Listing9 _numbers = new Listing9();
        private object _outputLock = new object();

        public void SomeMethod()
        {
            lock(_outputLock)
            {
                Console.WriteLine(_numbers.Add());
            }
        } 
            
        private void Numbers_DivideByZeroEvent(object sender, EventArgs ea)
        {
            lock(_outputLock)
            {
                Console.WriteLine("Divide by zero");
            }
        }
   }
}
