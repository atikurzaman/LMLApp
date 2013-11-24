using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMLApp.MLMCore
{
    public class M2MTransferCore:CoreBase
    {
         #region Constructors

        public M2MTransferCore()
        {
            _ProcedureName = StoredProcedure.Name.Payments_SPInvestorTransfers;
            Action = InvokeOperation.Type.SE;
        }

        #endregion Constructors

        #region "Private Variables"

        private long? _TransferID;
        private string _FromCustomerID;
        private string _ToCustomerID;
        private DateTime? _TransferDate;
        private decimal? _TransferAmount;
        private string _Descriptions;
        #endregion
        #region "Properties"

        public long? TransferID
        {
            get { return _TransferID; }
            set { _TransferID = value; }
        }

        public string FromCustomerID
        {
            get { return _FromCustomerID; }
            set { _FromCustomerID = value; }
        }

        public string ToCustomerID
        {
            get { return _ToCustomerID; }
            set { _ToCustomerID = value; }
        }

        public DateTime? TransferDate
        {
            get { return _TransferDate; }
            set { _TransferDate = value; }
        }

        public decimal? TransferAmount
        {
            get { return _TransferAmount; }
            set { _TransferAmount = value; }
        }

        public string Descriptions
        {
            get { return _Descriptions; }
            set { _Descriptions = value; }
        }
        #endregion
    }
}