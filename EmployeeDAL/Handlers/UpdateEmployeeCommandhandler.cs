using EmployeeDAL.Data;
using EmployeeDAL.Handlers.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Handlers
{
    public class UpdateEmployeeCommandhandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly EmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandhandler(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _employeeRepository.Update(request.Employee);
            if(employee == 1)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
