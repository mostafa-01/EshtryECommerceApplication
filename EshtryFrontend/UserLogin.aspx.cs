using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EshtryFrontend
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            error.Visible = false;
        }

        protected void registerbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserRegister.aspx");
        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                LoginRegisterService.LoginAndRegisterClient LRS = new LoginRegisterService.LoginAndRegisterClient();
                int returnValue = LRS.Login(Email.Text, password.Text);
                if (returnValue == 0)
                {
                    Response.Redirect("~/Admin.aspx");
                }
                else if (returnValue == -1)
                {
                    error.Text = "Wrong username or password!";
                    error.Visible = true;
                }
                else
                {
                    Page.Session["USERID"] = returnValue.ToString();
                    Response.Redirect("~/LoggedUser.aspx");
                }
            }
            else
            {
                error.Text = "Please fill all the text boxes.";
                error.Visible = true;
            }
        }

        protected bool validate()
        {
            if (Email.Text != "" && password.Text != "")
            {
                return true;
            }

            return false;
        }

       
    }
}