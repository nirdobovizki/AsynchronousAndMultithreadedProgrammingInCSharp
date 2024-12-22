using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08
{
	// dummy SmtpClient so you can run the code lisitngs without sending mail
	internal class SmtpClient
	{
		public SmtpClient(string server)
		{
		}

		public void Send(MailMessage message)
		{
			Console.WriteLine($"Sent message to {message.To.FirstOrDefault()?.Address}");
		}

		public Task SendMailAsync(MailMessage message)
		{
			Console.WriteLine($"Sent message to {message.To.FirstOrDefault()?.Address}");
			return Task.CompletedTask;
		}
	}
}
