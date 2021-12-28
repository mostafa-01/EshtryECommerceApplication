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
                int ItemID = int.Parse(Page.Session["EditItemID"] as string);
                AdminCRUDservice.AdminCRUDClient admin = new AdminCRUDservice.AdminCRUDClient();
                string[] item = admin.getItem(ItemID);
                string[] category = search.getCategories();
                for (int i = 0; i < category.Length; i++)
                {
                    categoriesList.Items.Add(category[i]);
                }
            //get item by id
            string title = item[2];
            string description = item[3];
            string price = item[4];
            string imgsrc = item[1];
            string cat = item[7];
            string quantity = item[5];
            string seller = item[6];

            titletxt.Text = title;
            descriptiontxt.Text = description;
            pricetxt.Text = price;
            imgsrctxt.Text = imgsrc;
            categoriesList.SelectedValue = cat;
            quantitytxt.Text = quantity;
            sellertxt.Text = seller;
            }
        }

        protected void donebtn_Click(object sender, EventArgs e)
        {
                if (!validate())
                {
                    error.Text = "Please fill all item data!";
                    error.Visible = true;
                }
                else
                {
              
                int ItemID = int.Parse(Page.Session["EditItemID"] as string);
                AdminCRUDservice.AdminCRUDClient admin = new AdminCRUDservice.AdminCRUDClient();
                admin.EditItem(ItemID, titletxt.Text, descriptiontxt.Text, imgsrctxt.Text, int.Parse(quantitytxt.Text), float.Parse(pricetxt.Text), sellertxt.Text, categoriesList.Text);
                Response.Redirect("~/Admin.aspx");

                }
            
                

            


        }

        protected void removebtn_Click(object sender, EventArgs e)
        {
            int ItemID = int.Parse(Page.Session["EditItemID"] as string);
            AdminCRUDservice.AdminCRUDClient admin = new AdminCRUDservice.AdminCRUDClient();
            admin.DeleteItem(ItemID);
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