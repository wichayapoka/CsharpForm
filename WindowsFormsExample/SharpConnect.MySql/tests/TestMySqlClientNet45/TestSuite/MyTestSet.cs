//MIT, 2015-2018, brezza92, EngineKit and contributors

using System;
using System.Collections.Generic;
using SharpConnect.MySql;
namespace MySqlTest
{
    public abstract class MySqlTestSet : MySqlTesterBase
    {
        protected static MySqlConnectionString GetMySqlConnString()
        {
            string h = "127.0.0.1"; //localhost
            string u = "root";
            string p = "admin001";
            string d = "test";
            return new MySqlConnectionString(h, u, p, d);
        }
    }
}