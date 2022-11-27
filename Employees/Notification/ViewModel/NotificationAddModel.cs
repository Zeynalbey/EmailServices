using Employees.Atributtes;
using System.ComponentModel.DataAnnotations;

namespace Notification.ViewModel
{
    public class NotificationAddModel
    {

        [Required]
        [EmailAddress(ErrorMessage = "Email is not correct!")]
        public string TargetEmail { get; set; }

        [Required]
        //[RegularExpression(@"^(?=[A-Z]{1})([A-Za-z]{3,20})$", ErrorMessage = "Father name is not correct!")]
        public string Content { get; set; }

        [Required]
        //[FinkodValidation()]
        public string Title { get; set; }
    }
}
