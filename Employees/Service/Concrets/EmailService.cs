using Employees.Service.Abstracts;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Crypto.Macs;
using System.Net;
using System.Net.Mail;

namespace WebApi.Services;

public class EmailService : IEmailService
{
    public void Send(string to, string subject, string body, string from)
    {
        MailAddress sender = new MailAddress(from);
        MailAddress reciver = new MailAddress(to);
        MailMessage message = new MailMessage();
        message.From = sender;
        message.To.Add(reciver);
        message.Subject = subject;
        message.Body = body;

        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.EnableSsl = true;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential()
        { Password = "password", UserName = "email" };
        smtp.SendMailAsync(message);

    }

    public void SendBulk(string from, string[] tos, string message)
    {
        //throw new NotImplementedException();
    }
}