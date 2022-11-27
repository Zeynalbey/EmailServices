
using Employees.Emails.Models;

namespace Notification.ViewModel
{
    public class NotificationListViewModel
    {
        public string Title { get; set; }
        public string FromEmail { get; set; }

        public TargetEmail TargetEmail { get; set; }

        public NotificationListViewModel(string title, string fromEmail, TargetEmail targetEmail)
        {
            Title = title;
            FromEmail = fromEmail;
            TargetEmail = targetEmail;

            // Bir tablede yaziram bele aydin olmuyacaq gerek struktru deyisem belede
        }
    }
}
