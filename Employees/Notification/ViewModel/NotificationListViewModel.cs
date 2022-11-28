
using Employees.Emails.Models;

namespace Notification.ViewModel
{
    public class NotificationListViewModel
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string FromEmail { get; set; }
        public string Content { get; set; }

        public TargetEmail TargetEmail { get; set; }

        public NotificationListViewModel(int id, string title, string fromEmail, TargetEmail targetEmail, string content)
        {
            Id = id;
            Title = title;
            FromEmail = fromEmail;
            TargetEmail = targetEmail;
            Content = content;
        }
    }
}
