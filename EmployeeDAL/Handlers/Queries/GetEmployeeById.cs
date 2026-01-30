using EmployeeDAL.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Handlers.Queries
{
    public class GetEmployeeById : IRequest<Employee>
    {
        public GetEmployeeById(int id)
        {
            Id = id;
        }

        public int? Id { get; set; }
    }
}
