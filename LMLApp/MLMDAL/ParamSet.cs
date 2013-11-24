using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMLApp
{
   public class ParamSet
    {
        public ParamSet()
        {
            //
        }

        public ParamSet(string _DBPramName, string _PropertyName)
        {
            this._DBPramName = _DBPramName;
            this._PropertyName = _PropertyName;
        }

        public ParamSet(string _DBPramName, string _PropertyName, object _PropertyValue)
            : this(_DBPramName, _PropertyName)
        {
            this._PropertyValue = _PropertyValue;
        }

        //public ParamSet(string _DBPramName, string _PropertyName, InvokeOperation.Type _Action)
        //    : this(_DBPramName, _PropertyName)
        //{           
        //    this._Action = _Action;
        //}

        //public ParamSet(string _DBPramName, string _PropertyName, object _PropertyValue, InvokeOperation.Type _Action)
        //    : this(_DBPramName, _PropertyName, _PropertyValue)
        //{
        //    this._Action = _Action;
        //}


        private string _DBPramName;
        /// <summary>
        /// Parameter name in stored procedure. Like: @Name
        /// </summary>
        public string DBPramName
        {
            get { return _DBPramName; }
            set { _DBPramName = value; }
        }

        private string _PropertyName;
        /// <summary>
        /// Property Name of Object defined in CORE
        /// </summary>
        public string PropertyName
        {
            get { return _PropertyName; }
            set { _PropertyName = value; }
        }

        private object _PropertyValue;
        /// <summary>
        /// 
        /// </summary>
        public object PropertyValue
        {
            get { return _PropertyValue; }
            set { _PropertyValue = value; }
        }

        private string _TypeName;
        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }

        private bool _IsStructuredType = false;
        public bool IsStructuredType
        {
            get { return _IsStructuredType; }
            set { _IsStructuredType = value; }
        }

        //private InvokeOperation.Type _Action;
        ///// <summary>
        ///// Optional Invoke Operation.
        ///// </summary>
        //public InvokeOperation.Type Action
        //{
        //    get { return _Action; }
        //    set { _Action = value
    }
}
