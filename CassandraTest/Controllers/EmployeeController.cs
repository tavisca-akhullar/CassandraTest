using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CassandraTest.Models;
using CassandraTest.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CassandraTest.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController()
        {
            _employeeRepository = new EmployeeService();
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _employeeRepository.GetAllRecords();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await _employeeRepository.GetSingleRecord(id);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task Post([FromBody]Employee value)
        {
            await _employeeRepository.AddRecord(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Employee value)
        {
             await _employeeRepository.UpdateRecord(value);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
             await _employeeRepository.DeleteRecord(id);
        }
    }
}
