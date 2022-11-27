using System.ComponentModel.DataAnnotations;

namespace Employees.ViewModels
{
    public class ListViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Fincode { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public bool IsDeleted { get; set; }

        public ListViewModel(string firstName, string lastName, string fatherName, string fincode, string email, string code, bool isDeleted)
        {

            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            Fincode = fincode;
            Email = email;
            Code = code;
            IsDeleted = isDeleted;
        }
    }
}
