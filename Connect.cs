using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Kasir
{
    class Connect
    {
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source = LAPTOP-38A2TFQ7; initial catalog=Kasir; integrated security=true";
            return Conn;
        }
    }
}