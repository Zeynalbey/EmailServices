using Employees.Notification.Models;

namespace Employees.Emails.Models
{ 
    public class TargetEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public List<NotificationModel> Notifications { get; set; }
    }
}
