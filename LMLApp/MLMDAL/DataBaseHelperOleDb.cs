using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace LMLApp
{
    class DataBaseHelperOleDb : DataAccessBase, IDatabaseHelper
    {
        private IList<CustomParameter> _parameters;

        public DataBaseHelperOleDb()
        {
        }

        /// <summary>
        /// Costructor that helps to initialize with the procedure name.
        /// </summary>
        /// <param name="storedprocedurename"></param>
        public DataBaseHelperOleDb(string storedprocedurename)
        {
            StoredProcedureName = storedprocedurename;
        }

        /// <summary>DbTransaction
        /// Run the procedure(Inherited from Base) with the specific transaction
        /// </summary>
        /// <param name="transaction">OleDb Transaction</param>
        public void Run(IDbTransaction transaction)
        {
            OleDbHelper.ExecuteNonQuery((OleDbTransaction)transaction, CommandType.StoredProcedure, StoredProcedureName, ConvertToSQLParam(Parameters));
        }

        /// <summary>
        /// Run the procedure(Inherited from Base). return type void.
        /// </summary>
        public void Run(IList<CustomParameter> param)
        {
            OleDbHelper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, StoredProcedureName, ConvertToSQLParam(param));
        }


        /// <summary>
        /// Run the procedure(Inherited from Base) with the specific transaction and required Parameters.
        /// </summary>
        /// <param name="transaction">OleDb Transaction</param>
        /// <param name="parameters">Parameters that required by the procedure.</param>
        public void Run(IDbTransaction transaction, IList<CustomParameter> parameters)
        {
            OleDbHelper.ExecuteNonQuery((OleDbTransaction)transaction, CommandType.StoredProcedure, StoredProcedureName, ConvertToSQLParam(parameters));
        }


        /// <summary>
        /// Run the procedure(Inherited from Base) with required Parameters And Specific Connection String.
        /// </summary>
        /// <param name="connectionstring">Connection string for the Database</param>
        /// <param name="parameters">Parameters that required by the procedure.</param>
        /// <returns> return type is System.Data.DataSet</returns>
        public DataSet Run(string connectionstring, IList<CustomParameter> parameters)
        {
            DataSet ds;
            ds = OleDbHelper.ExecuteDataset(connectionstring, StoredProcedureName, parameters);
            return ds;
        }


        public DataSet Run(string connectionstring, string textOleDb)
        {
            DataSet ds;
            ds = OleDbHelper.ExecuteDataset(connectionstring, CommandType.Text, textOleDb);
            return ds;
        }

        /// <summary>
        /// Call the procedure(Inherited from Base) for getting some scalar/single value. provide required Parameters And Specific Connection String.
        /// </summary>
        /// <param name="connectionstring">Connection string for the Database</param>
        /// <param name="parameters">Parameters that required by the procedure.</param>
        /// <returns>Return the scalar value as System.object type.</returns>
        public object RunScalar(string connectionstring, IList<CustomParameter> parameters)
        {
            object obj;
            obj = OleDbHelper.ExecuteScalar(connectionstring, StoredProcedureName, ConvertToSQLParam(parameters));
            return obj;
        }


        /// <summary>
        /// Run the procedure(Inherited from Base) with specified Transaction and OleDbParameters list for getting Scalar onject.
        /// </summary>
        /// <param name="transaction">OleDb Transaction</param>
        /// <param name="parameters">Parameters that required by the procedure.</param>
        /// <returns>Return the scalar value as System.object type.</returns>
        public object RunScalar(IDbTransaction transaction, IList<CustomParameter> parameters)
        {
            object obj;
            obj = OleDbHelper.ExecuteScalar((OleDbTransaction)transaction, StoredProcedureName, ConvertToSQLParam(parameters));
            return obj;
        }


        /// <summary>
        /// Run the procedure(Inherited from Base) with specified connection string for getting Dataset.
        /// </summary>
        /// <param name="connectionstring">Connection string for the Database.</param>
        /// <returns>return System.Data.DataSet</returns>
        public DataSet Run(string connectionstring)
        {
            DataSet ds;
            ds = OleDbHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, StoredProcedureName);
            return ds;
        }


        //public static DataTable ExecuteDataTable(OleDbConnection connection, bool isProc, string commandText)

        public DataTable getTable(string connectionString, bool isProc, string commandText)
        {
            DataTable dt;
            dt = OleDbHelper.ExecuteDataTable(connectionString, isProc, commandText);
            return dt;
        }


        /// <summary>
        /// Run the procedure(Inherited from Base). return type void.
        /// </summary>
        public void Run()
        {
            OleDbHelper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, StoredProcedureName, ConvertToSQLParam(Parameters));
        }


        /// <summary>
        /// Run the procedure(Inherited from Base) with the parameters list.
        /// </summary>
        /// <param name="parameters">Parameters that required by the procedure.</param>
        /// <returns>Return System.Data.OleDbClient.OleDbDataReader</returns>
        public IDataReader ExecuteReader(IList<CustomParameter> parameters)
        {
            IDataReader dr;
            dr = OleDbHelper.ExecuteReader(base.ConnectionString, CommandType.StoredProcedure, StoredProcedureName, ConvertToSQLParam(parameters));
            return dr;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string connectionString)
        {
            //OleDbDataReader dr;
            return OleDbHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, StoredProcedureName);
        }

        /// <summary>
        /// Execute A valid Non Query Command.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            if (commandText.Contains("--") || commandText.Contains("Drop "))
            {
                throw new Exception("Not a Valid OleDb Syntex.");
            }
            return OleDbHelper.ExecuteNonQuery(base.ConnectionString, commandType, commandText);
        }


        /// <summary>
        /// Get or Set the Parameters that required by procedure.
        /// </summary>
        public IList<CustomParameter> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        /// <summary>
        /// Make stored procedure param.
        /// </summary>
        /// <param name="ParamName">Name of param.</param>
        /// <param name="DbType">Param type.</param>
        /// <param name="Size">Param size.</param>
        /// <param name="Direction">Parm direction.</param>
        /// <param name="Value">Param value.</param>
        /// <returns>New parameter.</returns>
        public static OleDbParameter MakeParam(string ParamName, OleDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            OleDbParameter param;

            if (Size > 0)
                param = new OleDbParameter(ParamName, DbType, Size);
            else
                param = new OleDbParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }

        private OleDbParameter[] ConvertToSQLParam(IList<CustomParameter> param)
        {
            OleDbParameter[] Sparameters = new OleDbParameter[param.Count];
            for (int i = 0; i < param.Count; i++)
            {
                Sparameters.SetValue(new OleDbParameter(param[i].Name, param[i].Value), i);
            }
            return Sparameters;
        }
    }
}
