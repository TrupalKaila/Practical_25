using EmployeeDAL.Models.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.FluentValidators
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeDTO>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(x => x.EmployeeName)
                .NotEmpty().WithMessage("Employee Name is required.")
                .Length(2, 50).WithMessage("Employee Name must be between 2 and 50 characters.");
            RuleFor(x => x.EmployeeEmail)
                .NotEmpty().WithMessage("Employee Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.EmployeeSalary)
                .GreaterThan(0).WithMessage("Employee Salary must be greater than 0.");
            RuleFor(x => x.DepartmentId)
                .LessThanOrEqualTo(5)
                .GreaterThanOrEqualTo(0).WithMessage("Department ID must be between 1 to 5");
            RuleFor(x => x.EmployeeJoiningDate)
                .NotEmpty().WithMessage("Employee Joining Date is required.")
                .LessThan(DateTime.Now).WithMessage("Employee Joining Date cannot be in the future.");
        }
    }
}

