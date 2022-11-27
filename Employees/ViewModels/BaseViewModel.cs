using Employees.Atributtes;
using System.ComponentModel.DataAnnotations;

namespace Employees.ViewModels
{
    public class BaseViewModel
    {

        [Required]
        [RegularExpression(@"^(?=[A-Z]{1})([A-Za-z]{3,20})$", ErrorMessage = "Name is not correct!")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^(?=[A-Z]{1})([A-Za-z]{3,20})$", ErrorMessage = "Surname is not correct!")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^(?=[A-Z]{1})([A-Za-z]{3,20})$", ErrorMessage = "Father name is not correct!")]
        public string FatherName { get; set; }

        [Required]
        [FinkodValidation()]
        public string Fincode { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email is not correct!")]
        public string Email { get; set; }
    }
}
