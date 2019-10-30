using Cassandra;
using Cassandra.Mapping;
using CassandraTest.Cassandra;
using CassandraTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CassandraTest.Service
{
    public class EmployeeService : IEmployeeRepository
    {
        private readonly IMapper mapper;
        public EmployeeService()
        {
            mapper = new Mapper(CassandraInitializer.session);
        }

        public async Task AddRecord(Employee employee)
        {
            await mapper.InsertAsync(employee);
        }

        public async Task UpdateRecord(Employee employee)
        {
            var updateStatement = new SimpleStatement("UPDATE user SET " +
                ",designation  = ? " +
                ",emial    = ? " +
                ",name   = ? " +
                " WHERE id  = ? ",
                 employee.Designation, employee.Email,
                employee.Name, employee.Id);

            await CassandraInitializer.session.ExecuteAsync(updateStatement);
        }

        public async Task DeleteRecord(int id)
        {
            var deleteStatement = new SimpleStatement("DELETE FROM user WHERE id = ? ", id);
            await CassandraInitializer.session.ExecuteAsync(deleteStatement);
        }

        public async Task<Employee> GetSingleRecord(int id)
        {
            Employee addressBook = await mapper.SingleOrDefaultAsync<Employee>("SELECT * FROM user WHERE id = ?", id);
            return addressBook;
        }

        public async Task<IEnumerable<Employee>> GetAllRecords()
        {
            IEnumerable<Employee> addressBooks = await mapper.FetchAsync<Employee>("SELECT * FROM user");
            return addressBooks;
        }
    }
}
