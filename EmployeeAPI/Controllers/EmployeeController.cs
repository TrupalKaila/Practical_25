using EmployeeDAL.Data;
using EmployeeDAL.Handlers.Commands;
using EmployeeDAL.Handlers.Queries;
using EmployeeDAL.Models;
using EmployeeDAL.Models.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILoggerService _logger;
        public EmployeeController(IMediator mediator, ILoggerService logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddEmployeeDTO emp)
        {
            await _mediator.Send(new AddEmployeeCommand(emp));
            _logger.Log($"Created employee {emp.EmployeeName}");
            return Ok($"Employee {emp.EmployeeName} added");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _mediator.Send(new GetAllEmployee());
            if (employees == null || !employees.Any())
            {
                _logger.Log("No employees found");
                return NotFound("No employees found");
            }
            _logger.Log("Fetched all employees");
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _mediator.Send(request: new GetEmployeeById(id));
            if (employee == null)
            {
                _logger.Log($"Employee with ID {id} not found");
                return NotFound($"Employee with ID {id} not found");
            }
            _logger.Log($"Fetched employee with ID {id}");
            return Ok(employee);
        }

        //soft delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteById(int id)
        {
            var deleted = await _mediator.Send(request: new SoftDeleteEmployeeCommand(id));
            if(deleted)
            {
                _logger.Log($"Deleted employee with ID {id}");
                return Ok($"Employee with Id {id} is now Deleted or InActive");
            }
            else
            {
                _logger.Log($"Failed to delete employee with ID {id}");
                return NotFound();
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployeeById(UpdateEmployeeDTO emp)
        {
            var isUpdated = await _mediator.Send(request: new UpdateEmployeeCommand(emp));
            if (isUpdated)
            {
                _logger.Log($"Updated employee with ID {emp.EmployeeId}");
                return Ok($"Employee with Id {emp.EmployeeId} is now Updated");
            }
            else
            {
                _logger.Log($"Failed to update employee with ID {emp.EmployeeId}");
                return NotFound();
            }
        }

    }
}
