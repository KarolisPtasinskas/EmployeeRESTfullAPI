using EmployeeRestAPI.Entities;
using FluentValidation;

namespace EmployeeRestAPI.Validation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(t => t.FirstName).NotEmpty();
        }
    }
}
