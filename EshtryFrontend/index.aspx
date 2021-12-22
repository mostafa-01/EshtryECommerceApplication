<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ecommerce._default" %>

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
       <div class="main">
           <div class="example">
          <input type="text" placeholder="Search.." name="search2"/>
          <asp:DropDownList style="height:42px;" Class="button" ID="DropDownList1" runat="server"> </asp:DropDownList>
          <asp:button  Class="button"  runat="server" Text="Search"></asp:button>  
          &nbsp;</div>
        <asp:Panel ID="pnl" CssClass="parent" runat="server">
            </asp:Panel>

          
       </div>
       
    </form>
</body>
</html>
