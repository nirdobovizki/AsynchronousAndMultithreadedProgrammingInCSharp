using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;

namespace Chapter08
{

   public class Listing8
   {
        public void MailMerge(
            string from,
            string subject,
            string text, 
            (string email,string name)[] recipients)
        {
            var processingTasks = new Task[recipients.Length];
            Parallel.ForEach(recipients, 
                (current,_) =>
                {
                    try
                    {
                        var sender = new SmtpClient("smtp.example.com");
                        var message = new MailMessage();
                        message.From = new MailAddress(from);
                        message.Subject = subject;
                        message.To.Add(new MailAddress(current.email));
                        message.Body = text.Replace("{name}", current.name);
                       sender.Send(message);
                    }
                    catch
                    {
                        LogFailure(current.email);
                    }
                });
            }
       

	private void LogFailure(string message) { }

}
}
