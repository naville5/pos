using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos
{
    class mySqlConnect
    {
        MySqlConnection con;
        public MySqlConnection connect()
        {
            con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=pos;Sslmode=none");
            return con;
        }
    }
}
