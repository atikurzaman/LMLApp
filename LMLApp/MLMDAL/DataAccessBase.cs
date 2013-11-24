using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace LMLApp
{
    public class DataAccessBase
    {
        private string _storedprocedureName;
        private DatabaseType.Type _DBType;

        protected DatabaseType.Type DBType
        {
            // for now default SQL Server. later comes from configuration file
            get { return DatabaseType.Type.SQLServer; }
            //set { _DBType = value; }
        }

        /// <summary>
        /// Get or set StoredProcedure Name that u wanna connect.
        /// </summary>
        protected string StoredProcedureName
        {
            get { return _storedprocedureName; }
            set { _storedprocedureName = value; }
        }

        /// <summary>
        /// Get The Connection string of database. (Read Only).
        /// </summary>
        protected string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["XMCONN"].ToString(); }
        }
    }
}