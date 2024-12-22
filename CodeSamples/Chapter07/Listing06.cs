using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter07
{

   public class Listing6
   {
		private int _leftOperand;
		private int _rightOperand;
		private object _leftOperandLock = new object();
		private object _rightOperandLock = new object();
        public event EventHandler? DivideByZeroEvent;

		public int Divide()
         {
            lock(_rightOperandLock)
            {
               if(_rightOperand==0)
               {
                   DivideByZeroEvent?.Invoke(this,EventArgs.Empty);
                    return 0;
               }
               lock(_leftOperandLock)
               {
                   return _leftOperand/_rightOperand; 
               }
            }
         }

		public void SetOperands(int left, int right)
		{
			lock (_leftOperandLock)
			{
				_leftOperand = left;
			}
			lock (_rightOperandLock)
			{
				_rightOperand = right;
			}
		}
	}
}
