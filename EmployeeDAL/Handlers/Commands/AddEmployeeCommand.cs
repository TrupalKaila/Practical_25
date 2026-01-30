using EmployeeDAL.Models.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Handlers.Commands
{
    public class AddEmployeeCommand : IRequest<bool>
    {
        public AddEmployeeDTO Employee { get; set; }
        public AddEmployeeCommand(AddEmployeeDTO employee)
        {
            Employee = employee;
        }
    }
}
