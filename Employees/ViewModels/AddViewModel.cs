using System.ComponentModel.DataAnnotations;

namespace Employees.ViewModels
{
    public class AddViewModel : BaseViewModel
    {
        [Required]
        public bool IsDeleted { get; set; }

    }
}
