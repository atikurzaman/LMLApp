using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LMLApp
{
    class DataBaseHelperSQL : DataAccessBase, IDatabaseHelper
    {
        private IList<CustomParameter> _parameters = new List<CustomParameter>();


        /// <summary>
        /// Costructor that helps to initialize with the procedure name.
        /// </summary>
        /// <param name="storedprocedurename"></param>
        public DataBaseHelperSQL(string storedprocedurename)
        {
            StoredProcedureName = storedprocedurename;
        }

        /// <summary>
        /// 
        /// </summary>
        public DataBaseHelperSQL()
        {
        }

        //OleDbTransaction
        /// <summary>DbTransaction
        /// Run the procedure(Inherited from Base) with the specific transaction
        /// </summary>
        /// <param name="transaction">Sql Transaction</param>
        public void Run(IDbTransaction transaction)
        {
            SqlHelper.ExecuteNonQuery((SqlTransaction)transaction, CommandType.StoredProcedure, StoredProcedureName, ConvertToSQLParam(Parameters));
        }


        /// <summary>
        /// Run the procedure(Inherited from Base) with the specific transaction and required Parameters.
        /// </summary>
        /// <param name="transaction">Sql Transaction</param>
        /// <param name="parameters">Parameters that required by the procedure.</param>
        public void Run(IDbTransaction transaction, IList<CustomParameter> parameters)
        {
            SqlHelper.ExecuteNonQuery((SqlTransaction)transaction, CommandType.StoredProcedure, StoredProcedureName, ConvertToSQLParam(parameters));
        }


        /// <summary>
        /// Run the procedure(Inherited from Base) with required Parameters And Specific Connection String.
        /// </summary>
        /// <param name="connectionstring">Connection string for the Database</param>
        /// <param name="parameters">Parameters that required by the procedure.</param>
        /// <returns> return type is System.Data.DataSet</returns>
        public DataSet Run(string connectionstring, IDbDataParameter[] parameters)
        {
            DataSet ds;
            ds = SqlHelper.ExecuteDataset(connectionstring, StoredProcedureName, parameters);
            return ds;
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
            ds = SqlHelper.ExecuteDataset(connectionstring, StoredProcedureName, ConvertToSQLParam(parameters));
            return ds;
        }


        public DataSet Run(string connectionstring, string textSQL)
        {
            DataSet ds;
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.Text, textSQL);
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
            obj = SqlHelper.ExecuteScalar(connectionstring, StoredProcedureName, ConvertToSQLParam(parameters));
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
            obj = SqlHelper.ExecuteScalar((SqlTransaction)transaction, StoredProcedureName, ConvertToSQLParam(parameters));
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
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, StoredProcedureName);
            return ds;
        }


        //public static DataTable ExecuteDataTable(SqlConnection connection, bool isProc, string commandText)

        public DataTable getTable(string connectionString, bool isProc, string commandText)
        {
            DataTable dt;
            dt = SqlHelper.ExecuteDataTable(connectionString, isProc, commandText);
            return dt;
        }


        /// <summary>
        /// Run the procedure(Inherited from Base). return type void.
        /// </summary>
        public void Run()
        {
            SqlHelper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, StoredProcedureName, ConvertToSQLParam(Parameters));
        }

        /// <summary>
        /// Run the procedure(Inherited from Base). return type void.
        /// </summary>
        public void Run(IList<CustomParameter> param)
        {
            SqlHelper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, StoredProcedureName, ConvertToSQLParam(param));
        }


        /// <summary>
        /// Run the procedure(Inherited from Base) with the parameters list.
        /// </summary>
        /// <param name="parameters">Parameters that required by the procedure.</param>
        /// <returns>Return System.Data.SqlClient.SqlDataReader</returns>
        public IDataReader ExecuteReader(IList<CustomParameter> parameters)
        {
            SqlDataReader dr;
            //SqlParameter[] pram = new SqlParameter[1];            
            //pram.SetValue(new SqlParameter("@Action", "S"), 0);
            dr = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.StoredProcedure, StoredProcedureName, ConvertToSQLParam(parameters));
            return dr;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string connectionString)
        {
            //SqlDataReader dr;
            return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, StoredProcedureName);
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
                throw new Exception("Not a Valid Sql Syntex.");
            }
            return SqlHelper.ExecuteNonQuery(base.ConnectionString, commandType, commandText);
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
        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }


        private SqlParameter[] ConvertToSQLParam(IList<CustomParameter> param)
        {
            SqlParameter[] Sparameters = new SqlParameter[param.Count];
            SqlParameter subParam;
            for (int i = 0; i < param.Count; i++)
            {
                subParam = new SqlParameter(param[i].Name, param[i].Value);

                if (param[i].IsStructuredType == false && param[i].TypeName != null)
                {
                    if (param[i].TypeName == "SqlDbType.Image")
                    {
                        subParam.SqlDbType = SqlDbType.Image;
                    }
                }
                if (param[i].IsStructuredType)
                {
                    subParam.TypeName = param[i].TypeName;
                    subParam.SqlDbType = SqlDbType.Structured;
                }

                Sparameters.SetValue(subParam, i);
            }
            return Sparameters;
        }

        //private SqlParameter[] ConvertToSQLParam(IList<CustomParameter> param)
        //{
        //    SqlParameter[] Sparameters = new SqlParameter[param.Count];
        //    for (int i = 0; i < param.Count; i++)
        //    {
        //        Sparameters.SetValue(new SqlParameter(param[i].Name, param[i].Value), i);
        //    }
        //    return Sparameters;
        //}
    }
}
