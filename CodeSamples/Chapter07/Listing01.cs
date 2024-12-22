using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter07
{

   public class Listing1
   {
         private int _x;
         private int _y;
         private object _lock = new object();
         
         public void SetXY(int newX, int newY)
         {
              lock(_lock)  
              {
                   _x = newX;
                   _y = newY;
              }
         } 
         
         public (int x, int y) GetXY()
         {
              lock(_lock)  
              {
                   return (_x,_y);
              }
         }
   }
}
