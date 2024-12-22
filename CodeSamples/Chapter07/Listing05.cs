using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter07
{

   public class Listing5
   {
		private int _leftOperand;
		private int _rightOperand;
		private object _leftOperandLock = new object();
		private object _rightOperandLock = new object();
		
        public int Multiply()
         { 
             lock(_leftOperandLock)
             {
                   lock(_rightOperandLock)
                   {
                       return _leftOperand * _rightOperand;
                   }
              }
         }
         public int Add()
         { 
             lock(_leftOperandLock)
             {
                   lock(_leftOperandLock)
                   {
                       return _leftOperand * _rightOperand;
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
