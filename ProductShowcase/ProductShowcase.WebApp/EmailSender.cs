using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace ProductShowcase.WebApp
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine("--- FAKE EMAIL ---");
            Console.WriteLine($"To: {email}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine("--- Find the confirmation link below ---");
            Console.WriteLine(htmlMessage);
            Console.WriteLine("--- END FAKE EMAIL ---");
            return Task.CompletedTask;
        }
    }
}
