using EmployeeDAL.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Handlers.Queries
{
    public class GetAllEmployee : IRequest<IEnumerable<Employee>>
    {
        public GetAllEmployee()
        {
        }
    }
    
}
