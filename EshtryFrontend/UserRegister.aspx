<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="EshtryFrontend.UserRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <a href="default.aspx">HOME</a>
       </div>
       <div class="loginmain">
           <div class="loginform">
               
               <div class="container">
                   <h1>REGISTER</h1> 
                   <label class="loginlabel" for="name"><b>Name</b></label>&nbsp;
                   <asp:TextBox ID="name" type="text" runat="server"></asp:TextBox>

                   <label class="loginlabel" for="psw"><b>Password</b></label>
                   <asp:TextBox ID="password" type="password" runat="server"></asp:TextBox>

                   <label class="loginlabel" for="repsw"><b>Re-Enter Password</b></label>
                   <asp:TextBox ID="repassword" type="password" runat="server"></asp:TextBox>

                   <label class="loginlabel" for="bd"><b>Birthdate</b></label>
                   &nbsp;<asp:TextBox ID="birthdate" type="date" runat="server" ></asp:TextBox>

                   <label class="loginlabel" for="gender"><b>Gender</b></label>
                   <asp:RadioButtonList CssClass="registerradio" ID="RadioButtonList1" runat="server">
                       <asp:ListItem>Male</asp:ListItem>
                       <asp:ListItem>Female</asp:ListItem>
                   </asp:RadioButtonList>

                   <label class="loginlabel" for="add"><b>Address</b></label>
                   <asp:TextBox ID="address" runat="server"></asp:TextBox>

                   <label class="loginlabel" for="num"><b>Phone Number</b></label>
                   &nbsp;<asp:TextBox ID="phone" type="text" runat="server"></asp:TextBox>

                   <label class="loginlabel" for="mail"><b>E-Mail</b></label>

                   &nbsp;<asp:TextBox ID="email" type="email" runat="server"></asp:TextBox>

                   <asp:button  ID="registerbtn" CssClass="loginbutton"  runat="server" Text="Register" OnClick="registerbtn_Click"></asp:button> 
                   <br />
                   <br />
                   <asp:Label ID="error" runat="server" Text="Label" Style="color: red;"></asp:Label>
                   
               </div>
           </div>
       </div>

    </form>
</body>
</html>