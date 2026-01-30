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
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployee, IEnumerable<Employee>>
    {
        private readonly EmployeeRepository _employeeRepository;

        public GetAllEmployeeQueryHandler(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<IEnumerable<Employee>> Handle(GetAllEmployee request, CancellationToken cancellationToken)
        {
            var employees = _employeeRepository.GetAll();
            return Task.FromResult(employees.AsEnumerable());
        }
    }
}
