using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMLAPP.MLMCore;
using LMLApp.MLMCore;

namespace LMLApp.UI
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Action = InvokeOperation.Type.IN;
            string agentID = txtAgentID.Text;
            if (agentID != "")
                customer.AgentID = agentID;
            else
                return;
            string sponsorID = txtSopnsorID.Text;
            if (sponsorID != "")
                customer.SponsorID = sponsorID;
            else
                return;
            customer.CustomerName = txtFullName.Text;
            customer.Country = ddlCountry.SelectedItem.Text;
            customer.Phone = txtMobileNo.Text;
            customer.Email = txtEmail.Text;
            customer.ActivityStatus = "true";
            customer.DOB = DateTime.Now;
            customer.FatherName = "";
            customer.IsEmailEnabled = true;
            customer.IsWebEnabled = true;
            customer.IsSMSEnabled = true;
            customer.MailingAddress = "";
            customer.MotherName = "";
            customer.NationalID = "";
            customer.Notes = "";
            customer.PermanentAddress = "";
            customer.RegistrationDate = DateTime.Now;
            customer.Sex = "";
            customer.Zip = "";
            if (txtUserID.Text != "")
                customer.CustomerID = txtUserID.Text;
            else
                return;
            CustomerSecret secret = new CustomerSecret();
            secret.Action = InvokeOperation.Type.IN;
            if (txtUserID.Text != "")
                secret.CustomerID = txtUserID.Text;
            if (txtPassword.Text != "")
                secret.Password = txtPassword.Text;
            try
            {
                new ProcessManager(customer).invoke();
            }
            catch
            { }
            try
            {
                new ProcessManager(secret).invoke(); ;
            }
            catch { }
            
            

            

            Response.Redirect("Home.aspx");
        }
    }
}