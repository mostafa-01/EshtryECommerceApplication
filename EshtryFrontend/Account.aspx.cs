using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EshtryFrontend
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserControl.UserControlClient uc = new UserControl.UserControlClient();
                string[] info = uc.getUserInfo(1);
                TextBox1.Text = info[0];
                TextBox2.Text = info[1];
                DropDownList1.SelectedValue = info[2];
                TextBox4.Text = info[3];
                TextBox5.Text = info[4];
            }
        }
        protected void btn_click(object sender, EventArgs e)
        {
            UserControl.UserControlClient uc = new UserControl.UserControlClient();
            bool ret =  uc.editUserInfo(1, TextBox1.Text, DropDownList1.SelectedValue, TextBox4.Text, TextBox5.Text);
            Response.Redirect("Account.aspx");
        }
        protected void delivered_click(object sender, EventArgs e)
        {
            Response.Redirect("DeliveredOrders.aspx");
        }
        protected void delivering_click(object sender, EventArgs e)
        {
            Response.Redirect("DeliveringOrders.aspx");
        }
    }
}