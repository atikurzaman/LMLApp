using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMLApp.MLMCore;

namespace LMLApp.UI
{
    public partial class M2MTransfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            M2MTransferCore m2mTransfer = new M2MTransferCore();

            m2mTransfer.Action = InvokeOperation.Type.SE;
            m2mTransfer.WhereCondition = new System.Text.StringBuilder("1245878");//nee to implement customerid
            IList<M2MTransferCore> payeeList = new ProcessManager(m2mTransfer).GetList<M2MTransferCore>();
          
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            M2MTransferCore m2mTransfer = new M2MTransferCore();
            m2mTransfer.Action = InvokeOperation.Type.IN;
            m2mTransfer.ToCustomerID = txtRecivingID.Text;
            m2mTransfer.FromCustomerID = Session[""].ToString();
            m2mTransfer.TransferAmount =Convert.ToDecimal(txtTransferAmount.Text);
            m2mTransfer.TransferID =4343434;
            m2mTransfer.TransferDate = DateTime.Today;
            m2mTransfer.Descriptions = "";
            ProcessManager pM = new ProcessManager(m2mTransfer);
            
        }
    }
}