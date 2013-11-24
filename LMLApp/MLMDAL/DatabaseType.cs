using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMLApp
{
    public class DatabaseType
    {
        /// <summary>
        /// Define the DatabaseType of the Client Database
        /// </summary>
        public enum Type
        {
            SQLServer,
            OracleServer,
            MySQLServer,
            PostgreSQLServer
        }
    }
}
