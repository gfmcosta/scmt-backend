// Services/MailgunEmailSender.cs

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using scmt_backend.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        try
        {
            var smtpClient = new SmtpClient
            {
                Host = _config["Smtp:Host"],
                Port = int.Parse(_config["Smtp:Port"]),
                EnableSsl = bool.Parse(_config["Smtp:EnableSSL"]),
                Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"])
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_config["Smtp:Username"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(to);

            await smtpClient.SendMailAsync(mailMessage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}
