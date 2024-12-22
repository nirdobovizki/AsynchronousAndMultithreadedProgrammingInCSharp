using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter07
{

   public class Listing12
   {
		private int _leftOperand;
		private int _rightOperand;
		private object _leftOperandLock = new object();
		private object _rightOperandLock = new object();

		public int Add()
         { 
             int leftCopy,rightCopy;
             lock(_leftOperandLock)
             {
                 leftCopy = _leftOperand;
             }
             lock(_rightOperandLock)
             { 
                rightCopy = _rightOperand;
             }
             return rightCopy + leftCopy;   
         }
         
         public void SetOperands(int left, int right)
         { 
             lock(_leftOperandLock)
             {
                 _leftOperand = left;
             }
             lock(_rightOperandLock)
             { 
                _rightOperand = right;
             }
         }
   }
}
