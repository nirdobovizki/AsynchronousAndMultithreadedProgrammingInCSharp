#if WINDOWS
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Chapter11
{

   public class Listing1 : Form
	{
        private TextBox textBox1;
        private Label label1;

		public Listing1()
		{
			Width = 500;
			Height = 200;

			textBox1 = new TextBox();
			textBox1.Text = "INPUT";
			textBox1.Top = 40;
			textBox1.Width = ClientSize.Width;

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
			Controls.Add(new Label { Text = "The input is the textbox below", Top = 20, Width = ClientSize.Width });
			Controls.Add(textBox1);
			Controls.Add(label1);
			Controls.Add(button1);
		}

		private async Task<string> DoSomething(string input)
		{
			await Task.Delay(500);
			return "(" + input + ")";
		}

		private async void button1_Click(object? sender, EventArgs ea)
         {
            label1.Text = await DoSomething(textBox1.Text);
         }
   }
}
#endif
