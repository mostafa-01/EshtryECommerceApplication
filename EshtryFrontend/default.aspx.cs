using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EshtryFrontend
{
    public partial class _default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UserControl.UserControlClient uc = new UserControl.UserControlClient();
            string[][] items = uc.ListItems();
            Displaying(items);
            SearchService.SearchClient search = new SearchService.SearchClient();
            if (!IsPostBack)
            {
                string[] cat = search.getCategories();
                DropDownList1.Items.Add("All");
                for (int i = 0; i < cat.Length; i++)
                {
                    DropDownList1.Items.Add(cat[i]);
                }
            }
        }
        protected void Displaying(string[][] items)
        {
            for (int i = 0; i < items.Length; i++)
            {

                string id = items[i][0];
                string img = items[i][1];
                string title = items[i][2];
                string description = items[i][3];
                string price = items[i][4];


                StringBuilder myStringBuilder = new StringBuilder();
                myStringBuilder.Append("<div class='card'>");
                myStringBuilder.Append($"<img src='Images/{img}' style='width:100%'/>");
                myStringBuilder.Append($"<h1>{title}</h1>");
                myStringBuilder.Append($"<p class='price'>{price}$</p>");
                myStringBuilder.Append($"<p>Description: {description}</p>");
                myStringBuilder.Append($"<p>");
                pnl.Controls.Add(new LiteralControl(myStringBuilder.ToString()));


                Panel mychild = new Panel();
                mychild.CssClass = "panelwidth";
                Button btn = new Button();
                btn.Text = "Add to Cart";
                btn.ID = $"{id}";
                btn.CssClass = "buttondropdown buttonwidth";
                mychild.Controls.Add(btn);

                DropDownList DDL = new DropDownList();
                for (int j = 1; j <= int.Parse(items[i][5]); j++)
                {
                    DDL.Items.Add(j.ToString());

                }
                DDL.CssClass = "buttondropdown ddlwidth";
                DDL.ID = $"ddl {id}";
                btn.Click += new EventHandler(btn_Click);
                mychild.Controls.Add(DDL);
                mychild.Visible = true;
                pnl.Controls.Add(mychild);


                StringBuilder myStringBuilder2 = new StringBuilder();
                myStringBuilder2.Append($"</p></div>");
                pnl.Controls.Add(new LiteralControl(myStringBuilder2.ToString()));
                pnl.Visible = true;
            }
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Control ddl = this.FindControl($"ddl {btn.ID}");
            int quantity = int.Parse(((ListControl)ddl).Text);
            UserControl.UserControlClient uc = new UserControl.UserControlClient();
            uc.AddToCart(int.Parse(btn.ID), 1, quantity);
            Response.Redirect("default.aspx");
        }
        protected void Search_Click(object sender, EventArgs e)
        {   /*if (DropDownList1.SelectedValue == "All")
            {
                pnl.Controls.Clear();
                SearchService.SearchClient search = new SearchService.SearchClient();
                Displaying(search.SearchByItemName(search_txtbox.Value));
            }
            else
            {
                pnl.Controls.Clear();
                SearchService.SearchClient search = new SearchService.SearchClient();
                string[][] arr = search.SearchByItemName(search_txtbox.Value);
                Displaying(search.FilterItemsInCategory(arr, DropDownList1.SelectedValue));
            }*/
            pnl.Controls.Clear();
            SearchService.SearchClient search = new SearchService.SearchClient();
            Displaying(search.SearchByItemName(search_txtbox.Value, DropDownList1.SelectedValue));
        }
    }
}
