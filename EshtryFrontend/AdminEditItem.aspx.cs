using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EshtryFrontend
{
    //there is a postback issue
    public partial class AdminEditItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            error.Visible = false;
            SearchService.SearchClient search = new SearchService.SearchClient();
            if (!IsPostBack)
            {
                string[] category = search.getCategories();
                for (int i = 0; i < category.Length; i++)
                {
                    categoriesList.Items.Add(category[i]);
                }
            }
            //get item by id
            string title = "test";
            string description = "";
            string price = "";
            string imgsrc = "";
            string cat = "Fashion";
            string quantity = "";
            string seller = "";

            titletxt.Text = title;
            descriptiontxt.Text = description;
            pricetxt.Text = price;
            imgsrctxt.Text = imgsrc;
            categoriesList.SelectedValue = cat;
            quantitytxt.Text = quantity;
            sellertxt.Text = seller;
        }

        protected void donebtn_Click(object sender, EventArgs e)
        {
            {
                if (!validate())
                {
                    error.Text = "Please fill all item data!";
                    error.Visible = true;
                }
                else
                {
                    //update the item details
                    Response.Redirect("~/Admin.aspx");
                }
            }
                

            


        }

        protected void removebtn_Click(object sender, EventArgs e)
        {
            //remove item from db
            Response.Redirect("~/Admin.aspx");
        }

        protected bool validate()
        { 
            
                if (titletxt.Text != "" && descriptiontxt.Text != "" && pricetxt.Text != ""
                && imgsrctxt.Text != "" &&
                quantitytxt.Text != "" && sellertxt.Text != "")
                {
                    return true;
                }

                return false;
            
        }
    }
}