using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter04
{

    public class Listing1
    {
        public void RunInBackground()
        {
            var newThread = new Thread(CodeToRunInBackgroundThread);
            newThread.IsBackground = true;
            newThread.Start();
        }

        private void CodeToRunInBackgroundThread()
        {
            Console.WriteLine("Do stuff");
        }
    }
}
