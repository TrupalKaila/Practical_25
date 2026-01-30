using EmployeeDAL.Models;
using EmployeeDAL.Models.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Handlers.Commands
{
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public UpdateEmployeeDTO Employee { get; set; }
        public UpdateEmployeeCommand(UpdateEmployeeDTO employee)
        {
            Employee = employee;
        }
    }
}
