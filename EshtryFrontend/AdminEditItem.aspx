<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEditItem.aspx.cs" Inherits="EshtryFrontend.AdminEditItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/styles.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <a href="Admin.aspx">ADMIN</a>
            <a style="float:right" href="UserLogin.aspx">LOGOUT</a>
            <a style="float:right" href="AdminAddCategory.aspx">ADD CATEGORY</a>
            <a style="float:right" href="AdminAddItem.aspx">ADD ITEM</a>
       </div>
       <div class="loginmain">
           <div class="loginform">
               
               <div class="container">
                   <h1>Edit Item Details</h1> 
                   <label class="loginlabel" for="title"><b>Title</b></label>&nbsp;
                   <asp:TextBox 
                       ID="titletxt" type="text" runat="server"></asp:TextBox>

                   <label class="loginlabel" for="dsc"><b>Description</b></label>
                   <asp:TextBox ID="descriptiontxt" type="text" runat="server"></asp:TextBox>

                   <label class="loginlabel" for="price"><b>Price</b></label>
                   <asp:TextBox ID="pricetxt" type="number" runat="server"></asp:TextBox>

                   <label class="loginlabel" for="bd"><b>Image Source</b></label>
                   &nbsp;<asp:TextBox ID="imgsrctxt" type="text" runat="server" ></asp:TextBox>

                   <label class="loginlabel" for="categ"><b>Category</b></label><br /><br />
                   <asp:DropDownList CssClass="registerradio" ID="categoriesList" runat="server">
                   </asp:DropDownList><br /><br />

                   &nbsp;<label class="loginlabel" for="quantity"><b>Quantity</b></label>
                   <asp:TextBox ID="quantitytxt" type="number" runat="server"></asp:TextBox>

                   <label class="loginlabel" for="num"><b>Seller</b></label>
                   &nbsp;<asp:TextBox ID="sellertxt" type="text" runat="server"></asp:TextBox>


                   <asp:button  ID="edit" CssClass="loginbutton"  runat="server" Text="Done" OnClick="donebtn_Click"></asp:button>
                   <asp:button  ID="remove" CssClass="loginbutton" style="background-color:red;" runat="server" Text="Remove" OnClick="removebtn_Click"></asp:button>
                   <br />
                   <br />
                   <asp:Label ID="error" runat="server" Text="Label" Style="color: red;"></asp:Label>
                   
               </div>
           </div>
       </div>
    </form>
</body>
</html>