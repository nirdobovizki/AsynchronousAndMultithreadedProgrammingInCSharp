#if WINDOWS
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Chapter11
{

   public class Listing11 : Form
	{

		public Listing11()
		{
			Width = 500;
			Height = 200;


			var button1 = new Button();
			button1.Text = "Click here";
			button1.Top = 85;
			button1.Height = 35;
			button1.Width = 200;
			button1.Click += Button1_Click;

			Controls.Add(new Label { Text = "Close window to return to menu", Width = ClientSize.Width });
			Controls.Add(new Label { Text = "The output will appear in the console window", Top = 20, Width = ClientSize.Width });
			Controls.Add(button1);
		}

		private async void Button1_Click(object? sender, EventArgs ea)
         {
            Console.WriteLine($" before: {Thread.CurrentThread.ManagedThreadId }");
            await Task.Delay(500).ConfigureAwait(false);
			Console.WriteLine($" after: {Thread.CurrentThread.ManagedThreadId }");
         }
   }
}
#endif
