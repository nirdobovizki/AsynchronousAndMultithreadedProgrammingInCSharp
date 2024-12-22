using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter07
{

   public class Listing7
   {
		private int _leftOperand;
		private int _rightOperand;
		private object _leftOperandLock = new object();
		private object _rightOperandLock = new object();
		public event EventHandler? DivideByZeroEvent;

		public int Divide()
         {
            lock(_leftOperandLock)
            {
               lock(_rightOperandLock)
               {
                   if(_rightOperand==0)
                   {
                       DivideByZeroEvent?.Invoke(this,EventArgs.Empty);
                        return 0;
                   }
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
