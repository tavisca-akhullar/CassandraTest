using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CassandraTest.Cassandra
{
    public static class CassandraInitializer
    {
        private const string CassandraContactPoint = "127.0.0.1";
        public static ISession session;

        public static async Task InitializeCassandraSession()
        {
            Cluster cluster = Cluster.Builder().AddContactPoint(CassandraContactPoint).Build();
            session = await cluster.ConnectAsync("test_keyspace");
        }
    }
}
