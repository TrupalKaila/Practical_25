using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Handlers.Commands
{
    public class SoftDeleteEmployeeCommand : IRequest<bool>
    {
        public int EmployeeId { get; set; }
        public SoftDeleteEmployeeCommand(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
