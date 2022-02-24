using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EshtryFrontend
{
    public partial class SetDelivered : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            error.Visible = false;
        }
        protected void donebtn_Click(object sender, EventArgs e)
        {
            if (!validate())
            {
                error.Text = "Please enter an Order ID!";
                error.Visible = true;
            }
            else
            {
                AdminCRUDservice.AdminCRUDClient Admin = new AdminCRUDservice.AdminCRUDClient();
                Admin.SetDelivered(int.Parse(name.Text));
                Response.Redirect("~/Admin.aspx");
            }
        }
        protected bool validate()
        {
            if (name.Text != "")
            {
                return true;
            }

            return false;
        }
    }
}