using EmployeeDAL.Data;
using EmployeeDAL.Handlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Handlers
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, bool>
    {
        private readonly EmployeeRepository _employeeRepository;

        public AddEmployeeCommandHandler(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<bool> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            int employee = _employeeRepository.Create(request.Employee);
            return Task.FromResult(employee == 1);
        }
    }

}
