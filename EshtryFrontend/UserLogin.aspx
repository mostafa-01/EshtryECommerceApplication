<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="EshtryFrontend.UserLogin" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/styles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .loginbutton {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <a href="default.aspx">HOME</a>
       </div>
       <div class="loginmain">
           <div class="loginform">
               <div class="container">
                   <h1>LOGIN</h1>
                   <label for="uname"><b>Email</b></label>
                   &nbsp;<asp:TextBox type="text" placeholder="Enter Email" ID="Email" runat="server"></asp:TextBox>

                   <label for="psw"><b>Password</b></label>
                   &nbsp;&nbsp;<asp:TextBox type="password" placeholder="Enter Password" ID="password" runat="server"></asp:TextBox>

                   <asp:button ID="loginbtn" CssClass="loginbutton"  runat="server" Text="Login" OnClick="loginbtn_Click"></asp:button>
                   <asp:button  ID="registerbtn" CssClass="loginbutton"  runat="server" Text="Register" OnClick="registerbtn_Click"></asp:button> 
                   <br />
                   <br />
                   <asp:Label ID="error" runat="server" Text="Label" Style="color: red;"></asp:Label>
                   
               </div>
           </div>
       </div>

    </form>
</body>
</html>l>
