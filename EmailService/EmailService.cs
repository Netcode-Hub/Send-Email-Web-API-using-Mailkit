using EFCoreRelationships.DTOs;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EFCoreRelationships.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration config;

        public EmailService(IConfiguration config)
        {
            this.config = config;
        }

        public string SendEmail(RequestDTO request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));

            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Message };

            using var smtp = new SmtpClient();
            smtp.Connect(config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);

            smtp.Authenticate(config.GetSection("EmailUsername").Value, config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
            return "Mail Sent!";
        }
    }
}
