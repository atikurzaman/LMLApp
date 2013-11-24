using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace LMLApp
{
    class DMLManager:DataAccessBase
    {
        public DMLManager()
        {
        }

        public DMLManager(CoreBase _DMLCore)
        {
            this._DMLCore = _DMLCore;
        }

        public DMLManager(IList<ParamSet> _params)
        {
            //
        }

        private CoreBase _DMLCore;
        public CoreBase DMLCore
        {
            get { return _DMLCore; }
            set { _DMLCore = value; }
        }

        private IList<CoreBase> _DMLCoreList;
        public IList<CoreBase> DMLCoreList
        {
            get { return _DMLCoreList; }
            set { _DMLCoreList = value; }
        }

        public void invoke()
        {
            this.StoredProcedureName = _DMLCore.getProcedureName();
            if (_DMLCore.Action == InvokeOperation.Type.GS)
            {
                GetObjectByID();
            }
            // by shalin on 03.02.2011
            else if (_DMLCore.Action == InvokeOperation.Type.CQ)
            {
                GetObjectByID();
            }
            else if (_DMLCore.Action == InvokeOperation.Type.SE)
            {
                GetList();
            }
            else if (_DMLCore.Action == InvokeOperation.Type.GW)
            {
                GetList();
            }
            else if (_DMLCore.Action == InvokeOperation.Type.SC)
            {
                GetList();
            }
            else if (_DMLCore.Action == InvokeOperation.Type.IN || _DMLCore.Action == InvokeOperation.Type.UP || _DMLCore.Action == InvokeOperation.Type.DL)
            {
                executeDAB();
            }
            else
            {
                throw new Exception("InvokeOperation isn't properly defined");
            }

        }


        private void executeDAB()
        {
            ParameterManager Params;
            try
            {
                if (this._DMLCore.HasEntity())
                {
                    Params = new ParameterManager(this._DMLCore);
                }
                else
                {
                    Params = new ParameterManager(this._DMLCore.ParamSetList_P);
                }
                IDatabaseHelper helper = new DatabaseFactory().CreateDBHelper(base.DBType, StoredProcedureName);
                helper.Run(Params.Parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #region Queries

        public CoreBase GetObjectByID()
        {
            System.Data.IDataReader idr = null;
            ParameterManager Params;
            try
            {
                Params = new ParameterManager(this._DMLCore);
                IDatabaseHelper helper = new DatabaseFactory().CreateDBHelper(base.DBType, StoredProcedureName);
                //idr = helper.ExecuteReader(Params.Parameters);
                using (idr = helper.ExecuteReader(Params.Parameters))
                {
                    if (idr.Read())
                    {
                        Type coreType = _DMLCore.GetType();
                        PropertyInfo[] properties = coreType.GetProperties();
                        foreach (PropertyInfo info in properties)
                        {
                            //info.Name  exists in dataReader
                            if (DataRecordExtensions.HasColumn(idr, info.Name) && !DataRecordExtensions.IsNull(idr, info.Name))
                            {
                                coreType.GetProperty(info.Name).SetValue(_DMLCore, idr[info.Name], null);
                            }
                        }
                        //coreType.GetProperty("").SetValue(_DMLCore, "", null);

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //if (idr != null)
                //{
                //    idr.Close();
                //    idr.Dispose();
                //}
            }

            return _DMLCore;
        }

        private void GetParamFromReader(PropertyInfo[] properties, CoreBase clone, System.Data.IDataReader idr)
        {
            foreach (PropertyInfo info in properties)
            {
                if (!info.PropertyType.IsPrimitive && !info.PropertyType.IsValueType && info.PropertyType != typeof(System.String) && info.PropertyType != typeof(System.Text.StringBuilder) && info.Name.Substring(info.Name.Length - 2, 2) != "_P" && !info.PropertyType.IsGenericType)
                {
                    if (info.PropertyType.ToString() == "System.Byte[]")
                    {
                        //clone.GetType().GetProperty(info.Name).SetValue(clone, idr[info.Name], null);
                    }
                    else
                    {
                        Type childType = info.PropertyType;
                        //CoreBase childClone = (CoreBase)Activator.CreateInstance(childType);
                        CoreBase childClone = GetParamFromReader(childType, idr);
                        //Type t1 = childClone.GetType();
                        //info.PropertyType.InvokeMember(
                        //clone.GetType().GetProperty(info.Name).SetValue(clone, ((childType)childClone), null);
                        MethodInfo castMethod = this.GetType().GetMethod("Cast").MakeGenericMethod(childType);
                        //object castedObject = castMethod.Invoke(null, new object[] { childClone });
                        clone.GetType().GetProperty(info.Name).SetValue(clone, castMethod.Invoke(null, new object[] { childClone }), null);
                        //clone.GetType().GetProperty(info.Name).SetValue(clone, Cast<XMBank.Core.CompanySetup.Company>(childClone), null);
                    }
                }
                else
                {
                    //info.Name  exists in dataReader
                    if (DataRecordExtensions.HasColumn(idr, info.Name) && !DataRecordExtensions.IsNull(idr, info.Name))
                    {
                        clone.GetType().GetProperty(info.Name).SetValue(clone, idr[info.Name], null);
                    }

                }
            }
        }

        private object CreateObject(Type t)
        {
            return Activator.CreateInstance(t);
        }

        private CoreBase GetParamFromReader(Type type, System.Data.IDataReader idr)
        {
            CoreBase clone;
            clone = (CoreBase)CreateObject(type);// Activator.CreateInstance(type);
            PropertyInfo[] properties = type.GetProperties();
            GetParamFromReader(properties, clone, idr);
            //temp
            return clone;
        }

        public IList<CoreBase> GetList()
        {
            System.Data.IDataReader idr = null;
            CoreBase clone;
            ParameterManager Params;
            try
            {
                Params = new ParameterManager(this._DMLCore);
                IDatabaseHelper helper = new DatabaseFactory().CreateDBHelper(base.DBType, StoredProcedureName);
                //idr = helper.ExecuteReader(Params.Parameters);
                using (idr = helper.ExecuteReader(Params.Parameters))
                {
                    while (idr.Read())
                    {
                        Type coreType = _DMLCore.GetType();

                        //this line is written as alternative of the avobe lines[that are comented]
                        clone = GetParamFromReader(coreType, idr);

                        if (_DMLCoreList == null)
                        {
                            _DMLCoreList = new List<CoreBase>();
                        }
                        _DMLCoreList.Add(clone);
                        clone = null;
                        //coreType.GetProperty("").SetValue(_DMLCore, "", null);

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (idr != null)
                {
                    idr.Close();
                    idr.Dispose();
                }
            }

            return _DMLCoreList;
        }
        #endregion

        public static T Cast<T>(object o)
        {
            return (T)o;
        }


    }
}
