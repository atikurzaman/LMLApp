using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMLApp
{
    class DatabaseFactory : DataAccessBase
    {
        public DatabaseFactory()
        {
        }

        private IDatabaseHelper _DbHelper;
        public IDatabaseHelper DbHelper
        {
            get
            {
                if (_DbHelper == null)
                {
                    _DbHelper = new DataBaseHelperSQL();
                }
                return _DbHelper;
            }
        }


        public DatabaseFactory(DatabaseType.Type type)
        {
            switch (type)
            {
                case DatabaseType.Type.SQLServer: _DbHelper = new DataBaseHelperSQL();
                    break;
                case DatabaseType.Type.OracleServer: _DbHelper = new DataBaseHelperOleDb();
                    break;
                case DatabaseType.Type.PostgreSQLServer: _DbHelper = new DataBaseHelperOleDb();
                    break;
                case DatabaseType.Type.MySQLServer: _DbHelper = new DataBaseHelperOleDb();
                    break;
                default: break;
            }
        }

        public IDatabaseHelper CreateDBHelper()
        {
            switch (this.DBType)
            {
                case DatabaseType.Type.SQLServer: _DbHelper = new DataBaseHelperSQL();
                    break;
                case DatabaseType.Type.OracleServer: _DbHelper = new DataBaseHelperOleDb();
                    break;
                case DatabaseType.Type.PostgreSQLServer: _DbHelper = new DataBaseHelperOleDb();
                    break;
                case DatabaseType.Type.MySQLServer: _DbHelper = new DataBaseHelperOleDb();
                    break;
                default: break;
            }
            return _DbHelper;
        }

        public IDatabaseHelper CreateDBHelper(DatabaseType.Type type, string procedureName)
        {
            switch (type)
            {
                case DatabaseType.Type.SQLServer: _DbHelper = new DataBaseHelperSQL(procedureName);
                    break;
                case DatabaseType.Type.OracleServer: _DbHelper = new DataBaseHelperOleDb(procedureName);
                    break;
                case DatabaseType.Type.PostgreSQLServer: _DbHelper = new DataBaseHelperOleDb(procedureName);
                    break;
                case DatabaseType.Type.MySQLServer: _DbHelper = new DataBaseHelperOleDb(procedureName);
                    break;
                default: break;
            }
            return _DbHelper;
        }
    }
}
