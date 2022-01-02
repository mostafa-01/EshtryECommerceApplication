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
            <a href="LoggedUser.aspx">HOME</a>
            <a style="float:right" href="UserLogin.aspx">LOGOUT</a>
            <a style="float:right" href="Cart.aspx">CART</a>
            <a style="float:right" href="Account.aspx">ACCOUNT</a>
       </div>
        <br /><br /><br />
         <h3 class="History">Your Cart:</h3>
         <asp:Panel ID="pnl"  runat="server">

         </asp:Panel>
        <div id="CheckoutVisible" visible="false" class='ridge centerAligns' runat='server'>

            <asp:RadioButtonList AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="PayMethod_changed" ID="RadioButtonList1" runat="server">
                <asp:ListItem>Pay by Card</asp:ListItem>
                <asp:ListItem>Cash on delivery</asp:ListItem>
            </asp:RadioButtonList>

            <br />
            <div id="Carddiv" visible="false" runat='server'>
            Card Number<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Name on Card<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Expiry Date<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            CVV<br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <br />
            <asp:Button ID="Proceedbtn" OnClick="Proceed_click" runat="server" Text="Proceed" />
            </div>
            <asp:Button ID="CashProceedbtn" visble="false" OnClick="Proceed_click" runat="server" Text="Proceed" />
        </div>
    </form>
</body>
</html>
