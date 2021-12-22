using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 20; i++)
            {
                string img = "Images/jeans.jpg";
                string name = "Tailord Jeans";
                float price = 19.99f;
                string description = "Some text....";
                string id = "Button" + i.ToString();


                StringBuilder myStringBuilder = new StringBuilder();
                myStringBuilder.Append("<div class='card'>");
                myStringBuilder.Append($"<img src='{img}' style='width:100%'/>");
                myStringBuilder.Append($"<h1>{name}</h1>");
                myStringBuilder.Append($"<p class='price'>{price.ToString()}</p>");
                myStringBuilder.Append($"<p>{description}</p>");
                myStringBuilder.Append($"<p>");
                pnl.Controls.Add(new LiteralControl(myStringBuilder.ToString()));


                Panel mychild = new Panel();
                Button btn = new Button();
                btn.Text = "Add to Cart";
                btn.ID = $"{id}";
                btn.CssClass = "button";
                mychild.Controls.Add(btn);
                mychild.Visible = true;
                btn.Click += new EventHandler(btn_Click);
                pnl.Controls.Add(mychild);


                StringBuilder myStringBuilder2 = new StringBuilder();
                myStringBuilder2.Append($"</p></div>");
                pnl.Controls.Add(new LiteralControl(myStringBuilder2.ToString()));
                pnl.Visible = true;
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Response.Write(btn.ID);

        }
    }
}