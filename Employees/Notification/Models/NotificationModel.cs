using Employees.Emails.Models;

namespace Employees.Notification.Models
{
    public class NotificationModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int TargetEmailId { get; set; }
        public string FromEmail { get; set; }
        public TargetEmail TargetEmail {get;set;}
    }
}
