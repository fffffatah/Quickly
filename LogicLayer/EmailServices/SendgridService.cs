using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.EmailServices
{
    public class SendgridService
    {
        private string _apiKey;

        public SendgridService()
        {
            _apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        }
        //Send email without attachments
        public void Send(string from, string fromUserName, string to, string toUserName, string subject, string plainText, string html)
        {
            var client = new SendGridClient(_apiKey);
            var fromBuilder = new EmailAddress(from, fromUserName);
            var subjectBuilder = subject;
            var toBuilder = new EmailAddress(to, toUserName);
            var plainTextContent = plainText;
            var htmlContent = html;
            var msg = MailHelper.CreateSingleEmail(fromBuilder, toBuilder, subjectBuilder, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

        //Send email with attachments
        public void Send(string from, string fromUserName, string to, string toUserName, string subject, string plainText, string html, string attachmentFileName, byte[] attachmentContent)
        {
            var client = new SendGridClient(_apiKey);
            var fromBuilder = new EmailAddress(from, fromUserName);
            var subjectBuilder = subject;
            var toBuilder = new EmailAddress(to, toUserName);
            var plainTextContent = plainText;
            var htmlContent = html;
            var attachment = new Attachment();
            attachment.Content = Convert.ToBase64String(attachmentContent);
            attachment.Filename = attachmentFileName + ".pdf";
            attachment.Type = "pdf";
            attachment.Disposition = "attachment";
            var msg = MailHelper.CreateSingleEmail(fromBuilder, toBuilder, subjectBuilder, plainTextContent, htmlContent);
            msg.AddAttachment(attachment);
            var response = client.SendEmailAsync(msg);
        }
    }
}
