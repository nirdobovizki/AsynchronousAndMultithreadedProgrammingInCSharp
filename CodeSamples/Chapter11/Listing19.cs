#if WINDOWS
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Chapter11
{

   public class Listing19 : Form
	{
		private Label label1;

		public Listing19()
		{
			Width = 500;
			Height = 200;

			label1 = new Label();
			label1.Text = "RESULT WILL BE HERE";
			label1.Top = 65;
			label1.Width = ClientSize.Width;


			var button1 = new Button();
			button1.Text = "Click here";
			button1.Top = 85;
			button1.Height = 35;
			button1.Width = 200;
			button1.Click += button1_Click;

			Controls.Add(new Label { Text = "Close window to return to menu", Width = ClientSize.Width });
			Controls.Add(button1);
			Controls.Add(label1);
		}

		private void button1_Click(object? sender, EventArgs ea)
		{
			int i = 0;
			while (true)
			{
				label1.Text = (++i).ToString();
			}
		}
	}
}
#endif