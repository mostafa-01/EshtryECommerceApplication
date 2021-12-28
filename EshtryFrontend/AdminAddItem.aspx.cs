using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EshtryFrontend
{
    public partial class AdminAddItem : System.Web.UI.Page
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
                AdminCRUDservice.AdminCRUDClient admin = new AdminCRUDservice.AdminCRUDClient();
                admin.AddItem(titletxt.Text, descriptiontxt.Text, imgsrctxt.Text, int.Parse(quantitytxt.Text), float.Parse(pricetxt.Text), sellertxt.Text, categoriesList.Text);
                Response.Redirect("~/Admin.aspx");
            }
        }

        protected bool validate()
        {
            if (titletxt.Text != "" && descriptiontxt.Text != "" && pricetxt.Text != ""
                && imgsrctxt.Text != "" && categoriesList.SelectedIndex > -1 &&
                quantitytxt.Text != "" && sellertxt.Text != "")
            {
                return true;
            }

            return false;
        }
    }
}