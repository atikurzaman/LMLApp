using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace LMLApp
{
    public class ProcessManager:IProcess
    {
        public ProcessManager()
        {
        }

        public ProcessManager(CoreBase _BLLCore)
        {
            this._BLLCore = _BLLCore;
        }

        private CoreBase _BLLCore;
        public CoreBase BLLCore
        {
            get { return _BLLCore; }
            set { _BLLCore = value; }
        }

        private IList<CoreBase> _BLLCoreList;
        public IList<CoreBase> BLLCoreList
        {
            get { return _BLLCoreList; }
            set { _BLLCoreList = value; }
        }

        public virtual void invoke()
        {
            DMLManager dml;
            if (_BLLCore != null && _BLLCore.Action != null)
            {
                //createParameterSet();
                dml = new DMLManager(_BLLCore);
                dml.invoke();
            }
            else
            {
                throw new Exception(this.ToString() + ":" + MethodBase.GetCurrentMethod().Name + ";" + " Object Missing");
            }
        }


        public IList<T> GetList<T>(CoreBase _Core)
        {
            //_Core = (CoreBase) HttpContext.Current.Session["Core"];
            DMLManager dml;
            try
            {
                dml = new DMLManager(_BLLCore);
                dml.invoke();
                _BLLCoreList = dml.DMLCoreList;
                dml.DMLCoreList = null;
                dml = null;
                if (_BLLCoreList != null)
                {
                    return CastList<T>(_BLLCoreList);
                }
                else
                {
                    return new List<T>();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //
            }

        }


        public IList<T> GetList<T>()
        {
            return GetList<T>(_BLLCore);
        }

        public T GetObjectByID<T>(CoreBase _Core)
        {
            DMLManager dml;
            if (_BLLCore.Action == InvokeOperation.Type.GS)
            {
                dml = new DMLManager(_BLLCore);
                dml.invoke();
                _BLLCore = dml.DMLCore;
                dml.DMLCore = null;
                return Cast<T>(_BLLCore);
            }
            // by shalin on 03.02.2011
            else if (_BLLCore.Action == InvokeOperation.Type.CQ)
            {
                dml = new DMLManager(_BLLCore);
                dml.invoke();
                _BLLCore = dml.DMLCore;
                dml.DMLCore = null;
                return Cast<T>(_BLLCore);
            }
            else
            {
                throw new Exception("Action is not Defined for the current Operation"); ;
            }
            //return _BLLCore;
        }

        public IList<CoreBase> GetListWhere(CoreBase _Core)
        {
            return _BLLCoreList;
        }

        public IList<CoreBase> GetListByCustomQuery(CoreBase _Core)
        {
            return _BLLCoreList;
        }

        public static IList<T> CastList<T>(IList<CoreBase> source)
        {
            IList<T> cloneList = new List<T>();
            foreach (object ob in source)
            {
                cloneList.Add((T)ob);
            }
            return cloneList;
        }

        public static T Cast<T>(object o)
        {
            return (T)o;
        }
    }
}