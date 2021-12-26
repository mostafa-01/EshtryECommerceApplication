using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EshtryFrontend
{
    public partial class DeliveringOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserControl.UserControlClient uc = new UserControl.UserControlClient();
            string[][] items = uc.getOrdersHistory(1,0);
            Displaying(items);

        }
        protected void Displaying(string[][] items)
        {
            UserControl.UserControlClient uc = new UserControl.UserControlClient();
            string orderNum = "";
            string date = "";
            string TotalPrice = "";
            string TotalQuantity = "";
            StringBuilder myStringBuilder = new StringBuilder();
            for (int i = 0; i < items.Length - 1; i++)
            {

                if (items[i][0] == ".")
                {
                    //loop for orders
                    orderNum = items[++i][0];
                    date = items[i][1];
                    TotalPrice = items[i][2];
                    i++;
                    TotalQuantity = uc.OrderItemsQuantity(int.Parse(orderNum)).ToString();
                    myStringBuilder.Append("<div class='ridge centerAligns' runat='server'>");
                    myStringBuilder.Append($"<h2>Order id: #{orderNum}</h2>");
                    myStringBuilder.Append($"<h4>Order Date: {date}</h4>");
                    myStringBuilder.Append($"<h4>Num of items: {TotalQuantity}</h4>");
                    myStringBuilder.Append($"<h4>Total Price: {TotalPrice}$</h4><hr /><h4>Items in your order:</h4>");
                }

                //loop for items
                string itemTitle = items[i][0];
                string itemQuantity = items[i][1];
                string itemPrice = items[i][2];
                string itemImg = items[i][3];
                myStringBuilder.Append("<div class='orderimg'>");
                myStringBuilder.Append($"<img class='orderPicture' src='images/{itemImg}' align='left' HSPACE='10'>");
                myStringBuilder.Append($"<p class='itemDetails'>{itemTitle}</p>");
                myStringBuilder.Append($"<p class='itemDetails'>QTY: {itemQuantity}</p>");
                myStringBuilder.Append($"<p class='itemDetails'>Price: {itemPrice}$</p></div>");

                if (items[i + 1][0] == ".")
                {
                    //end of order
                    myStringBuilder.Append("</div><br />");
                }
            }
            pnl.Controls.Add(new LiteralControl(myStringBuilder.ToString()));
            pnl.Visible = true;
        }
    }
}