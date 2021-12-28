using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EshtryFrontend
{
    public partial class UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            error.Visible = false;
        }

        protected void registerbtn_Click(object sender, EventArgs e)
        {
            if (validate() == 1)
            {
                LoginRegisterService.LoginAndRegisterClient LRS = new LoginRegisterService.LoginAndRegisterClient();
                int age = DateTime.Now.Year - (int.Parse(birthdate.Text.Split('-')[0]));
                bool returnValue = LRS.Register(name.Text,password.Text,age, RadioButtonList1.SelectedValue,address.Text,phone.Text,email.Text);
                if (returnValue == true)
                {
                    Response.Redirect("~/UserLogin.aspx");
                }
                else{
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Phone number or Email already exists. please register again.');window.location ='UserRegister.aspx';", true);

                }

            }
            else if (validate() == 0)
            {
                error.Text = "Password doesn't match!";
                error.Visible = true;
            }
            else
            {
                error.Text = "Please fill all the text boxes.";
                error.Visible = true;
            }

        }
        protected int validate()
        {
            if (name.Text != "" && password.Text != "" && repassword.Text != ""
                && birthdate.Text !="" && RadioButtonList1.SelectedIndex>-1 && address.Text!=""
                && phone.Text!="" && email.Text!="")
            {
                if (password.Text == repassword.Text)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            return -1;
        }
    }
}