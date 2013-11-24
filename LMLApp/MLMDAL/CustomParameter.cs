using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMLApp
{
    public class CustomParameter
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private object _value;
        public object Value
        {
            get { return _value; }
            set { _value = value; }
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

        public CustomParameter()
        {
        }

        public CustomParameter(string name, object value)
        {
            this._name = name;
            this._value = value;
        }

        public CustomParameter(string name, object value, string typename)
            : this(name, value)
        {
            this._TypeName = typename;
        }

        public CustomParameter(string name, object value, string typename, bool isStructuredType)
            : this(name, value, typename)
        {
            this._IsStructuredType = isStructuredType;
        }

    }
}