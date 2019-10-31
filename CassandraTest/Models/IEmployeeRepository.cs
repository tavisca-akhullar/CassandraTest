using CassandraTest.Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CassandraTest.Models
{
    interface IEmployeeRepository:ICassandraRepository
    {
        Task AddRecord(Employee addressBook);
        Task UpdateRecord(Employee addressBook);
        Task DeleteRecord(long id);
        Task<Employee> GetSingleRecord(long id);
        Task<IEnumerable<Employee>> GetAllRecords();
    }
}
