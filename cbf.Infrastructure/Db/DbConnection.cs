using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbf.Infrastructure.Db
{
    public sealed class DbConnection
    {
        private DbConnection() { }

        private static MySqlConnection _connection;

        public static MySqlConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new MySqlConnection("Server=localhost;Database=teste;Uid=root;Pwd=root;");
            }

            return _connection;

        }
    }
}
