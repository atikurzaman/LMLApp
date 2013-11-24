using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace LMLApp
{
    public class CoreBase
    {
        private InvokeOperation.Type _Action;
        public InvokeOperation.Type Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        private IList<ParamSet> _ParamSetList;
        public IList<ParamSet> ParamSetList_P
        {
            get { return _ParamSetList; }
            set { _ParamSetList = value; }
        }

        internal StoredProcedure.Name _ProcedureName;
        public string getProcedureName()
        {
            return _ProcedureName.ToString();
        }

        public void SetProcedureName(StoredProcedure.Name _name)
        {
            this._ProcedureName = _name;
        }

        private bool _HasEntity = true;

        public bool HasEntity()
        {
            return _HasEntity;
        }

        public void HasEntity(bool hasEntity)
        {
            _HasEntity = hasEntity;
        }

        private StringBuilder _SelectString;
        public StringBuilder SelectString
        {
            get { return _SelectString; }
            set { _SelectString = value; }
        }

        private StringBuilder _WhereCondition;
        public StringBuilder WhereCondition
        {
            get { return _WhereCondition; }
            set { _WhereCondition = value; }
        }
        
    }
}