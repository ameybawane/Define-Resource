using DefineResource.Models;
using Microsoft.AspNetCore.Mvc;

namespace DefineResource.Controller
{
    [ApiController]
    [Route("api/{controller}")]
    public class EmployeesController : ControllerBase
    {

        static List<EmployeeViewModel> _employees = new List<EmployeeViewModel>();

        static EmployeesController()
        {
            _employees.Add(new EmployeeViewModel { Id = 1, Name = "mahesh" });
            _employees.Add(new EmployeeViewModel { Id = 2, Name = "suresh" });
        }

        // http://localhost:5267/api/employees
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_employees);
        }

        // http://localhost:5267/api/employees/get/1
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var foundEmployee = _employees
                    .Where(x => x.Id.Equals(id))
                    .FirstOrDefault();

            if (foundEmployee == null)
                return NotFound();

            return Ok(foundEmployee);
        }

        // http://localhost:5267/api/employees/delete/3
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var foundEmployee = _employees
                    .Where(x => x.Id.Equals(id))
                    .FirstOrDefault();

            if (foundEmployee != null)
            {
                _employees.Remove(foundEmployee);
            }
            return NoContent();
        }

        // http://localhost:5267/api/employees
        [HttpPost]
        public ActionResult Post([FromBody] EmployeeViewModel emp)
        {
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                _employees.Add(emp);
                return Ok(_employees);
            }
        }
        //{"id": "1",
        //"name":"mahesh"}

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] EmployeeViewModel emp, int id)
        {
            if (emp == null || emp.Id != id)
            {
                return BadRequest();
            }
            var foundEmployee = _employees
                    .Where(x => x.Id.Equals(id))
                    .FirstOrDefault();
            if (foundEmployee == null)
            {
                return NotFound();
            }
            else
            {
                foundEmployee.Name = emp.Name;
                _employees.Add(foundEmployee);
                _employees.Remove(foundEmployee);
                return Ok(_employees);
            }
        }
    }
}