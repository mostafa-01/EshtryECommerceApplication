<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="EshtryFrontend.Admin" %>

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
       <div class="main">
           <div class="example">
          <input id="search_txtbox" type="text"  placeholder="Search.."  name="search2" runat="server"/>
          <asp:DropDownList style="height:42px;" AutoPostBack="true" CausesValidation="false" Class="button" OnSelectedIndexChanged="category_Click" ID="DropDownList1" runat="server"> </asp:DropDownList>
          <asp:button  Class="button"  runat="server" Text="Search"  OnClick="Search_Click"></asp:button>  
          &nbsp;</div>
        <asp:Panel ID="pnl" CssClass="parent" runat="server">
            </asp:Panel>

          
       </div>
       
    </form>
</body>
</html>