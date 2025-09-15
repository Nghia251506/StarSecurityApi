using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace StarSecurityApi.Service
{
    public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body);
}

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly string _from;

    public EmailService(IConfiguration configuration)
    {
        var host = configuration["Email:Smtp:Host"];
        var port = int.Parse(configuration["Email:Smtp:Port"]);
        var username = configuration["Email:Smtp:Username"];
        var password = configuration["Email:Smtp:Password"];
        _from = configuration["Email:From"];

        _smtpClient = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(username, password),
            EnableSsl = true
        };
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var mail = new MailMessage(_from, to, subject, body)
        {
            IsBodyHtml = true
        };

        await _smtpClient.SendMailAsync(mail);
    }
}
}
