using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;

namespace Chapter08
{

   public class Listing10
   {
        public void MailMerge(
            string from,
            string subject,
            string text, 
            (string email,string name)[] recipients)
        {
            var processingTasks = new Task[recipients.Length];
            Parallel.ForEachAsync(recipients,  
                new ParallelOptions { 
                    MaxDegreeOfParallelism= recipients.Length  
                },
                async (current,_) =>  
                {
                    try
                    {
                    var sender = new SmtpClient("smtp.example.com");
                    var message = new MailMessage();
                    message.From = new MailAddress(from);
                    message.Subject = subject;
                    message.To.Add(new MailAddress(current.email));
                    message.Body = text.Replace("{name}", current.name);
                    await sender.SendMailAsync(message);  
                    }
                    catch
                    {
                    LogFailure(current.email);
                    }
                }).Wait();  
            }

		private void LogFailure(string message) { }

	}
}
