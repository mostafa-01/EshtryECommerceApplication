<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetDelivered.aspx.cs" Inherits="EshtryFrontend.SetDelivered" %>

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
            <a style="float:right" href="SetDelivered.aspx">SET DELIVERED</a>
            <a style="float:right" href="AdminAddItem.aspx">ADD ITEM</a>
       </div>
       <div class="loginmain">
           <div class="loginform">
               
               <div class="container">
                   <h1>Set order to Delivered</h1> 
                   <label class="loginlabel" for="name"><b>ID</b></label>&nbsp;
                   <asp:TextBox ID="name" type="text" runat="server"></asp:TextBox>

                   <asp:button  ID="edit" CssClass="loginbutton"  runat="server" Text="Done" OnClick="donebtn_Click"></asp:button>
                   
                   <br />
                   <br />
                   <asp:Label ID="error" runat="server" Text="Label" Style="color: red;"></asp:Label>
                   
               </div>
           </div>
       </div>
    </form>
</body>
</html>
