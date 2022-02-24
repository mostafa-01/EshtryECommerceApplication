using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EshtryFrontend
{
    public partial class AdminAddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            error.Visible = false;
        }

        protected void donebtn_Click(object sender, EventArgs e)
        {
            if(!validate())
            {
                error.Text = "Please enter a name for the category!";
                error.Visible = true;
            }
            else
            {
                AdminCRUDservice.AdminCRUDClient Admin = new AdminCRUDservice.AdminCRUDClient();
                Admin.AddCategory(name.Text);
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