using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMLApp.MLMCore
{
    public class CustomerSecret:CoreBase
    {
        public CustomerSecret()
        {
            _ProcedureName = StoredProcedure.Name.Setup_SPCustomerSecret;
            Action = InvokeOperation.Type.SE;
        }
        public string CustomerID
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;

        }

        public string ForgetAutoPassword
        {
            get;
            set;
        }
        public IList<CustomerSecret> CustomerSecretList
        {
            get;
            set;
        }

    }
}