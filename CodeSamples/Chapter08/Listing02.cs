using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;

namespace Chapter08
{

    public class Listing2
    {
        public void MailMerge(
              string from,
              string subject,
              string text,
              (string email, string name)[] recipients)
        {
            var processingThreads = new Thread[recipients.Length];
            for (int i = 0; i < recipients.Length; ++i)
            {
                var icopy = i;
                processingThreads[i] = new Thread(() =>
                {
                    try
                    {
                        var sender = new SmtpClient("smtp.example.com");
                        var message = new MailMessage();
                        message.From = new MailAddress(from);
                        message.Subject = subject;
                        message.To.Add(new MailAddress(recipients[icopy].email));
                        message.Body = text.Replace("{name}", recipients[icopy].name);
                        sender.Send(message);
                    }
                    catch
                    {
                        LogFailure(recipients[icopy].email);
                    }
                });
                processingThreads[i].Start();
            }
            foreach (var current in processingThreads)
            {
                current.Join();
            }
        }

        private void LogFailure(string message) { }
    }
}