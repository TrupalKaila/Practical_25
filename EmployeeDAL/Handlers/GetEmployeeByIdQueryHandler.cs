using EmployeeDAL.Handlers.Queries;
using EmployeeDAL.Models;
using MediatR;
using System;
using System.Collections.Generic;
using EmployeeDAL.Data;
using EmployeeDAL.Handlers.Commands;
using EmployeeDAL.Handlers.Queries;
using EmployeeDAL.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Handlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeById, Employee>
    {
        private readonly EmployeeRepository _employeeRepository;

        public GetEmployeeByIdQueryHandler(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<Employee> Handle(GetEmployeeById request, CancellationToken cancellationToken)
        {
            var employee = _employeeRepository.GetById((int)request.Id);
            return Task.FromResult(employee);
        }
    }
}
