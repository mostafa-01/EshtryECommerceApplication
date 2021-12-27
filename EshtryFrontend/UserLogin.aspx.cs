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
                /*
                 if(correctCredentials)
                {
                    //take to dashboard
                }
                else{
                    error.Text = "Wrong username or password!";
                    error.Visible = true;
                }

                 */
            }
            else
            {
                error.Text = "Please fill all the text boxes.";
                error.Visible = true;
            }
        }

        protected bool validate()
        {
            if (uname.Text != "" && password.Text != "")
            {
                return true;
            }

            return false;
        }

       
    }
}