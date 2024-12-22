using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter04
{

    public class Listing9
    {
        public void RunInBackground()
        {
            for (int i = 0; i < 10; ++i)
            {
                var icopy = i;
                Task.Run(() =>
                {
                    Console.WriteLine($"Hello from thread {icopy}");
                });
            }
        }
    }
}
