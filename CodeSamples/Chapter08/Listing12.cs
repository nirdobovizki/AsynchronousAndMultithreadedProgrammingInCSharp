using System.Collections.Concurrent;
using System.Net.Mail;

namespace Chapter08
{

    public class MailMerger
    {
        private record MailInfo(
           string from,
           string subject,
           string text,
           string email);

        BlockingCollection<MailInfo> _queue = new();

        public void Start()
        {
            var thread = new Thread(BackgroundProc);
            thread.Start();
        }
        public void Stop()
        {
            _queue.CompleteAdding();
        }
        public void MailMerge(
           string from,
           string subject,
           string text,
           (string email, string name)[] recipients)
        {
            foreach (var current in recipients)
            {
                _queue.Add(new MailInfo(
                   from,
                   subject,
                   text.Replace("{name}", current.name),
                   current.email));
            }
        }
        private void BackgroundProc()
        {
            var sender = new SmtpClient("smtp.example.com");
            foreach (var current in _queue.GetConsumingEnumerable())
            {
                try
                {
                    var message = new MailMessage();
                    message.From = new MailAddress(current.from);
                    message.Subject = current.subject;
                    message.To.Add(new MailAddress(current.email));
                    message.Body = current.text;
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