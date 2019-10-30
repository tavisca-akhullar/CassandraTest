using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CassandraTest.Models
{
    [Table("user")]
    public class Employee
    {
        
            [Column("id")]
            public long Id
            {
                get;
                set;
            }
            [Column("designation")]
            public string Designation
            {
                get;
                set;
            }
            [Column("email")]
            public string Email
            {
                get;
                set;
            }
            [Column("name")]
            public string Name
            {
                get;
                set;
            }
        }
    }
