using System.ComponentModel.DataAnnotations;
using WebProgrammingBackEnd.Data;

namespace WebProgrammingBackEnd.Validators;

public class EmailNotInUse : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var _context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));

        var user = _context.Users.FirstOrDefault(x => x.Email.Equals(value.ToString()));
        if (user != null)
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        return ValidationResult.Success;
    }
}
