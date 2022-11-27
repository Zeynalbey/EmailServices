using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Employees.Atributtes
{
    public class FinkodValidation : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            //ArgumentNullException.ThrowIfNull(value, $"{nameof(RequiredAttribute)} required");

            string regexed = @"^([A-Z0-9]{7}$)";

            var code = value.ToString();

            return Regex.IsMatch(code, regexed);
        }
    }



}
