<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="EshtryFrontend.Account" %>

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
         <h3 class="History">Your Account:</h3>
         <asp:Panel ID="pnl"  runat="server">
             <div class="ridge centerAligns" runat="server">
                    <h3>Details:</h3>
                <div class="accountheight inset">
                    <h3>Name: </h3>  <asp:TextBox  ID="TextBox1" runat="server" CssClass="textboxdetails"></asp:TextBox>  
                    <h3>Email:   </h3><asp:TextBox ID="TextBox2" runat="server" CssClass="textboxdetails" Enabled="false"></asp:TextBox> 
                    <h3>Gender: </h3>  <asp:DropDownList ID="DropDownList1" runat="server" CssClass="textboxdetails">
                                         <asp:ListItem value="Male">Male </asp:ListItem>  
                                         <asp:ListItem value="Female">Female </asp:ListItem>  
                                       </asp:DropDownList>  
                    <h3>Phone Number:</h3> <asp:TextBox ID="TextBox4" runat="server" CssClass="textboxdetails"></asp:TextBox>   
                    <h3>Address:</h3> <asp:TextBox ID="TextBox5" runat="server" CssClass="textboxdetails"></asp:TextBox>   

                    <hr/>
                    <asp:Button ID="Button1"  OnClick="btn_click" runat="server" Text="SAVE" CssClass="buttondropdown checkoutbuttonwidth" />
                </div> <br />
                 <div class="orderhistoryheight"> 
                 <h3>Order History:</h3>
                    <asp:Button ID="Button2" OnClick="delivered_click" runat="server" Text="Delivered Orders" CssClass="buttondropdown orderhistorybuttonwidth cartheight" />
                    <asp:Button runat="server" OnClick="delivering_click" Text="Delivering Orders" CssClass="buttondropdown orderhistorybuttonwidth cartheight"></asp:Button>
                    </div>
                </div>
            <br />

         </asp:Panel>

    </form>
</body>
</html>
