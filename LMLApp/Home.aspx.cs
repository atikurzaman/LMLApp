using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using LMLApp.MLMCore;

namespace LMLApp
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            CustomerSecret secret = new CustomerSecret();
            secret.Action = InvokeOperation.Type.SE;
            secret.CustomerID = userNameTextBox.Text.Trim();
            secret.Password = passwordTextBox.Text.Trim();
            IList<CustomerSecret> listofSecret;
            listofSecret = new ProcessManager(secret).GetList<CustomerSecret>();
            if (listofSecret[0].CustomerID == userNameTextBox.Text.Trim() && listofSecret[0].Password == passwordTextBox.Text.Trim())
            {
                Session["UserName"] = userNameTextBox.Text.Trim();
                Session["Password"] = passwordTextBox.Text.Trim();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            
            }
              
          
        }
    }
}