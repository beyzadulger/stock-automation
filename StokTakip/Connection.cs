using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StokTakip
{
    class Connection
    {
        public SqlConnection GetConnection() {
            return new SqlConnection() { ConnectionString = "server=LOCAL\\SQLEXPRESS; database=dropdown_cate; Integrated Security=true" };
           
        }
    }
}
