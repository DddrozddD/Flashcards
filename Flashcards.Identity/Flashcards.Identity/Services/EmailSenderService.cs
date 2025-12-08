using Flashcards.Identity.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Flashcards.Identity.Services
{
    public class EmailSenderService : IEmailSender
    {
        private readonly SendGridSenderOptions _options;
        private readonly SendGridClient _client;

        public EmailSenderService(IOptions<SendGridSenderOptions> options)
        {
            _options = options.Value;
            _client = new SendGridClient(_options.SendGridKey);
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_options.UserMail, "Flashcards Support"),
                Subject = subject,
                HtmlContent = htmlMessage
            };
            msg.AddTo(new EmailAddress(email));
            msg.SetClickTracking(false, false);

            await _client.SendEmailAsync(msg);
        }
    }
}
