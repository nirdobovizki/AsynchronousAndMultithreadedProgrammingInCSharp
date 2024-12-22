#if WINDOWS
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Chapter05
{

   public class Listing12 : Form
   {
        private Label MyLabel;
        private int LongCalculation()
        {
            return 0;
        }
        public Listing12()
        {
			Width = 500;
			Height = 200;
			MyLabel = new Label();
			MyLabel.Text = "RESULT WILL BE HERE";
			MyLabel.Top = 40;
			MyLabel.Width = ClientSize.Width;

			var MyButton = new Button();
			MyButton.Text = "Click here";
			MyButton.Top = 65;
			MyButton.Height = 35;
			MyButton.Width = 200;
			MyButton.Click += MyButtonClick;

			Controls.Add(new Label { Text = "Close window to return to menu", Width = ClientSize.Width });
			Controls.Add(new Label { Text = "Clicking the button throw an exception", Top = 20, Width = ClientSize.Width });
			Controls.Add(MyLabel);
			Controls.Add(MyButton);
		}

		private void MyButtonClick(object? sender, EventArgs ea)
         {
            Task.Run(() =>
            {
                int result = 0;
                result = LongCalculation();
                MyLabel.Text = result.ToString();
            });
         }
   }
}
#endif