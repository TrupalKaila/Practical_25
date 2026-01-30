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
    public class SoftdeleteEmployeeCommandHandler : IRequestHandler<SoftDeleteEmployeeCommand, bool>
    {
        private readonly EmployeeRepository _employeeRepository;

        public SoftdeleteEmployeeCommandHandler(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<bool> Handle(SoftDeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
           
            _employeeRepository.SoftDelete(request.EmployeeId);
            return Task.FromResult(true);
        }
    }
}
