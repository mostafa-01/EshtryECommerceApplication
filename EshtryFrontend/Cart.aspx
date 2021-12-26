<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="EshtryFrontend.Cart" %>

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
            <a href="#home">Home</a>
            <a style="float:right" href="#Login">Login</a>
            <a style="float:right" href="#Register">Register</a>
       </div>
        <br /><br /><br />
         <h3 class="History">Your Cart:</h3>
         <asp:Panel ID="pnl"  runat="server">

         </asp:Panel>

    </form>
</body>
</html>
