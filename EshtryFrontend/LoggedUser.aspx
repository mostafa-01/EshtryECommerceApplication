<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggedUser.aspx.cs" Inherits="EshtryFrontend.LoggedUser" %>

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
            <a href="LoggedUser.aspx">HOME</a>
            <a style="float:right" href="UserLogin.aspx">LOGOUT</a>
            <a style="float:right" href="Cart.aspx">CART</a>
            <a style="float:right" href="Account.aspx">ACCOUNT</a>
       </div>
       <div class="main">
           <div class="example">
          <input id="search_txtbox" type="text"  placeholder="Search.."  name="search2" runat="server"/>
          <asp:DropDownList style="height:42px;" Class="button" ID="DropDownList1" runat="server"> </asp:DropDownList>
          <asp:button  Class="button"  runat="server" Text="Search"  OnClick="Search_Click"></asp:button>  
          &nbsp;</div>
        <asp:Panel ID="pnl" CssClass="parent" runat="server">
            </asp:Panel>

          
       </div>
       
    </form>
</body>
</html>

