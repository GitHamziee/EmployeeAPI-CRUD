using APICRUD.Data;
using APICRUD.Models;
using APICRUD.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        { 
            this.dbContext = dbContext;
        }


        [HttpGet("get-all-employees")]
        public IActionResult getAllEmployees()
        {
          var allEmployees =  dbContext.employees.ToList();
            return Ok(allEmployees);
        }

        [HttpGet("get-employee-by-id/{id:guid}")]
            public IActionResult GetEmployeeByID(Guid id)
        {
            var employee = dbContext.employees.Find(id);

            if( employee is null)
            {
                return NotFound();
            }

            return Ok(employee);

        }

        [HttpPut("Update-employee/{id:guid}")]
         public IActionResult UpdateEmployee( Guid id , UpdateEmployeeDto dto)
        {
            var employee = dbContext.employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }

            employee.Name = dto.Name;
            employee.Email = dto.Email;
            employee.Salary = dto.Salary;
            employee.Phone = dto.Phone;
            //dbContext.employees.Update(id)

            dbContext.employees.Update(employee);
            dbContext.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete("Delete-employee/{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }


            dbContext.employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {

            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            dbContext.employees.Add(employeeEntity);
            dbContext.SaveChanges();
             
           return Ok(employeeEntity);

        }
    }
}
