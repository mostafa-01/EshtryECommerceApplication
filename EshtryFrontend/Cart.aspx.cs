using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EshtryFrontend
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserControl.UserControlClient uc = new UserControl.UserControlClient();
            string[][] items = uc.Viewcart(1);
            Displaying(items);
        }
        protected void Displaying(string[][] items)
        {
            StringBuilder myStringBuilder = new StringBuilder();
              myStringBuilder.Append("<div class='ridge centerAligns' runat='server'>");
            pnl.Controls.Add(new LiteralControl(myStringBuilder.ToString()));
            int i = 0;
            for (i = 0; i < items.Length - 1; i++)
            {
                myStringBuilder = new StringBuilder();
                //loop for items
                string itemID = items[i][0];
                string itemTitle = items[i][1];
                string itemQuantity = items[i][2];
                string itemPrice = items[i][3];
                string itemImg = items[i][4];
                string totalQuantity = items[i][5];
                myStringBuilder.Append("<div class='cartimg inset'>");
                myStringBuilder.Append($"<img class='orderPicture' src='images/{itemImg}' align='left' HSPACE='10'>");
                myStringBuilder.Append($"<p class='cartItemDetails'>{itemTitle}</p>");
                myStringBuilder.Append($"<p class='cartItemDetails'>Price: {itemPrice}$</p><hr/>");
                pnl.Controls.Add(new LiteralControl(myStringBuilder.ToString()));


                Panel mychild = new Panel();
                Button btn = new Button();
                btn.Text = "Remove";
                btn.ID = $"{itemID}";
                btn.CssClass = "buttondropdown buttonwidth cartheight";
                mychild.Controls.Add(btn);

                DropDownList DDL = new DropDownList();
                for (int j = 1; j <= int.Parse(totalQuantity); j++)
                {
                    DDL.Items.Add(j.ToString());

                }
                DDL.SelectedValue = itemQuantity;   
                DDL.CssClass = "buttondropdown ddlwidth cartheight";
                DDL.ID = $"ddl {itemID}";
                DDL.AutoPostBack = true;
                DDL.CausesValidation = false;
                DDL.SelectedIndexChanged += new EventHandler(ChangeQuantity);
                btn.Click += new EventHandler(remove_Click);
                mychild.Controls.Add(DDL);
                mychild.Visible = true;
                pnl.Controls.Add(mychild);

                StringBuilder myStringBuilder2 = new StringBuilder();
                myStringBuilder2.Append($"</div><br/>");
                pnl.Controls.Add(new LiteralControl(myStringBuilder2.ToString()));
            }
            string totalPrice = items[i][0];
            StringBuilder myStringBuilder3 = new StringBuilder();
            myStringBuilder3.Append("<div style='height: 110px'>");
            myStringBuilder3.Append($"<h2 style='float:left'>Total Price:</h2><h2 style='float:right'>{totalPrice}$</h2>");
            pnl.Controls.Add(new LiteralControl(myStringBuilder3.ToString()));
            Panel checkoutpanel = new Panel();
            Button checkoutbtn = new Button();
            checkoutbtn.Text = "Checkout";
            if (items.Length == 1)
            {
                checkoutbtn.Enabled = false;
            }
            checkoutbtn.CssClass = "buttondropdown checkoutbuttonwidth";
            checkoutpanel.Controls.Add(checkoutbtn);
            checkoutpanel.Visible = true;
            pnl.Controls.Add(checkoutpanel);
            checkoutbtn.Click += new EventHandler(checkout_Click);
            StringBuilder myStringBuilder4 = new StringBuilder();
            myStringBuilder4.Append("</div></div><br />");
            pnl.Controls.Add(new LiteralControl(myStringBuilder4.ToString()));


            pnl.Visible = true;
        }
        protected void remove_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            UserControl.UserControlClient uc = new UserControl.UserControlClient();
            uc.Removefromcart(int.Parse(btn.ID),1);
            Response.Redirect("Cart.aspx");
        }
        protected void checkout_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            UserControl.UserControlClient uc = new UserControl.UserControlClient();
            uc.Checkout(1);
            Response.Redirect("Cart.aspx");
        }
        protected void ChangeQuantity(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;

            UserControl.UserControlClient uc = new UserControl.UserControlClient();
            int quantity =int.Parse(ddl.SelectedValue);
            int itemID = int.Parse(ddl.ID.Split(' ')[1]);
            uc.Removefromcart(itemID, 1);
            uc.AddToCart(itemID, 1, quantity);
            Response.Redirect("Cart.aspx");
        }
    }
}