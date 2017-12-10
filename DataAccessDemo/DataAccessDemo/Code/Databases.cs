using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using P3Net.Kraken.Data.Common;
using P3Net.Kraken.Data.Sql;

namespace DataAccessDemo.Code
{
    public static class Databases
    {
        public static ConnectionManager CreateDatabase ()
        {
            return new SqlConnectionManager(ConfigurationManager.ConnectionStrings["DemoDatabase"].ConnectionString);
        }
    }
}