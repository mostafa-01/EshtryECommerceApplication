﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliveringOrders.aspx.cs" Inherits="EshtryFrontend.DeliveringOrders" %>

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
        <br /><br /><br />
         <h3 class="History">Delivering Orders:</h3>
        <asp:Panel ID="pnl"  runat="server">
            
            </asp:Panel>
    </form>
</body>
</html>
