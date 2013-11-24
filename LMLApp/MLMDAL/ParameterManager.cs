using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace LMLApp
{
    class ParameterManager
    {
        private IList<CustomParameter> _parameters = new List<CustomParameter>();
        public IList<CustomParameter> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }


        private object _pObj;

        //DatabaseType.Type _type;

        public ParameterManager(object _pObj)
        {
            this._pObj = _pObj;
            CreateParameterSet(this._pObj);
        }

        public ParameterManager(IList<ParamSet> _params)
        {
            //this._pObj = _pObj;
            CreateParameterSet(_params);
        }

        //public void createParameters(CoreBase obj)
        //{
        //    Type objType = obj.GetType();
        //    PropertyInfo[] properties = objType.GetProperties();
        //    bool flag = false;
        //    foreach (PropertyInfo info in properties)
        //    {
        //        if (info.GetValue(obj, null) != null && flag)
        //        {
        //            AddParameterValue(info.Name, info.GetValue(obj, null));
        //        }
        //    }

        //    //will change
        //    //return new List<CustomParameter>();
        //}


        //for calling direct procedure where does not have any specific object.
        public void CreateParameterSet(IList<ParamSet> paramSetList)
        {
            foreach (ParamSet param in paramSetList)
            {
                if (param.IsStructuredType)// if custom table type are called as parameter of procedure.
                {
                    if (param.TypeName == null)
                        throw new Exception("Structured Parameter need Type name as well");
                    AddParameterValue(param.DBPramName, param.PropertyValue, param.TypeName, true);
                }
                else
                {
                    AddParameterValue(param.DBPramName, param.PropertyValue);
                }
            }
            //return new List<CustomParameter>();
        }

        public void CreateParameterSet(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            foreach (PropertyInfo info in properties)
            {
                //string s = info.Name.Substring(info.Name.Length - 2, 2);
                if (info.GetValue(obj, null) != null && info.Name.Substring(info.Name.Length - 2, 2) != "_P" && info.PropertyType.ToString() != "System.Byte[]")
                {
                    AddParameterValue(info.Name, info.GetValue(obj, null));

                }
                if (info.PropertyType.ToString() == "System.Byte[]")
                {
                    AddParameterValue(info.Name, info.GetValue(obj, null), "SqlDbType.Image", false);
                    //string type_pic = info.PropertyType.ToString();
                }
            }
        }

        public void AddParameterValue(string propertyName, object value)
        {
            //if (propertyName == "Action")
            //{
            //    value = value.ToString();
            //}
            Parameters.Add(new CustomParameter("@" + propertyName, value.ToString()));
        }

        public void AddParameterValue(string propertyName, object value, string typeName, bool IsStructuredType)
        {
            if (IsStructuredType == true)
            {
                Parameters.Add(new CustomParameter("@" + propertyName, value, typeName, true));
            }
            if (IsStructuredType == false)
            {
                Parameters.Add(new CustomParameter("@" + propertyName, value, typeName, false));
            }
        }
    }
}
