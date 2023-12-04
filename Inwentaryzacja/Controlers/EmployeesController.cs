using AutoMapper;
using Inwentaryzacja.DataTransferObjects;
using Inwentaryzacja.Extensions;
using Inwentaryzacja.Interfaces;
using Inwentaryzacja.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inwentaryzacja.Controlers
{
    [ApiController]
    [Route("api/Employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepositoryService<Employee> _repository;
        private readonly IMapper _mapper;

        public EmployeesController(IRepositoryService<Employee> employeeRepository, IMapper mapper)
        {
            _repository = employeeRepository;
            _mapper = mapper;
        }

        // POST api/employee
        [HttpPost]
        public ActionResult<Employee> AddEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            var result = _repository.Add(_mapper.Map<Employee>(employeeDTO));

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            return CreatedAtAction(nameof(AddEmployee), new { id = employeeDTO.Id }, employeeDTO);
        }

        // GET api/employee
        [HttpGet]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            // relations test
            var result = _repository.GetAllRecords().Include(x => x.Devices).ThenInclude(x => x.DeviceType).ToList();
            //var result = _repository.GetAllRecords().ToList();

            if (result.FirstOrDefault() == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET api/employee/1
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(Guid id)
        {
            var result = _repository.FindBy(x => x.Id == id).Include(x => x.Devices).ThenInclude(x => x.DeviceType).FirstOrDefault();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE api/employee/1
        [HttpDelete("{id}")]
        public ActionResult<Employee> DeleteEmployeeById(Guid id)
        {
            var emp = _repository.GetSingle(id);

            if (emp == null)
            {
                return BadRequest("Attempted to update or delete an entity that does not exist in the store.");
            }

            var result = _repository.Delete(emp);

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            return Ok();
        }

        // PUT api/employee
        [HttpPut]
        public ActionResult<Employee> EditEmployee(EmployeeDTO employeeDTO)
        {
            var result = _repository.Edit(_mapper.Map<Employee>(employeeDTO));

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            return Ok();
        }
    }
}
