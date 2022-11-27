namespace Employees.Service.Abstracts
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html, string from);
        void SendBulk(string from, string[] tos, string message);
    }
}
