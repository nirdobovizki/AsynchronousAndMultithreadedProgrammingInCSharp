using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;

namespace Chapter08
{

   public class Listing1
   {
        public void MailMerge(
            string from,
            string subject,
            string text, 
            (string email,string name)[] recipients)
        {
            var sender = new SmtpClient("smtp.example.com");
            foreach(var current in recipients)  
            {
                try
                {
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
            }
        }

        private void LogFailure(string message) { }
   }
}
