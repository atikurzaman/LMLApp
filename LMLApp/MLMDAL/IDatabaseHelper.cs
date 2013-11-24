using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LMLApp
{
   public interface IDatabaseHelper
    {
        //string StoredProcedureName { get; set;}

        IList<CustomParameter> Parameters
        { get; set; }

        /// <summary>
        /// Run for executing A Procedure with Non Query Operation
        /// </summary>
        void Run();

        /// <summary>
        /// Run for executing A Procedure with Non Query Operation
        /// </summary>
        /// <param name="transaction"> Existing transaction reference</param>
        void Run(IDbTransaction transaction);

        /// <summary>
        /// Run for executing A Procedure with Non Query Operation
        /// </summary>
        /// <param name="param"> Array of Custom Parameter[Name , value] object</param>
        void Run(IList<CustomParameter> param);

        /// <summary>
        /// Run for executing A Procedure with Non Query Operation
        /// </summary>
        /// <param name="transaction">Existing transaction reference</param>
        /// <param name="parameters">Array of Custom Parameter[Name , value] object</param>
        void Run(IDbTransaction transaction, IList<CustomParameter> parameters);

        /// <summary>
        /// Run for executing A Procedure To get Dataset.
        /// </summary>
        /// <param name="connectionstring">Base connection String</param>
        /// <param name="parameters">Array of Custom Parameter[Name , value] object</param>
        /// <returns>System.Data.Dataset</returns>
        DataSet Run(string connectionstring, IList<CustomParameter> parameters);

        /// <summary>
        /// Run for executing A Procedure To get Dataset.
        /// </summary>
        /// <param name="connectionstring">Base Connection String</param>
        /// <param name="SQLQuery"></param>
        /// <returns>System.Data.Dataset</returns>
        DataSet Run(string connectionstring, string SQLQuery);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionstring">Base Connection String</param>
        /// <returns></returns>
        DataSet Run(string connectionstring);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="isProc"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        DataTable getTable(string connectionString, bool isProc, string commandText);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        object RunScalar(string a, IList<CustomParameter> b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        object RunScalar(IDbTransaction transaction, IList<CustomParameter> parameters);

        /// <summary>
        /// Run for executing A Procedure To get Data Reader.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>System.Data.IDataReader</returns>
        IDataReader ExecuteReader(IList<CustomParameter> parameters);

        /// <summary>
        /// Run for executing A Procedure[without Parameter] To get Data Reader.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>System.Data.IDataReader</returns>
        IDataReader ExecuteReader(string connectionString);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string commandText, CommandType commandType);
    
    }
}
