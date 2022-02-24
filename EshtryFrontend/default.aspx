<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="EshtryFrontend._default1" %>

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
            <a href="#home">HOME</a>
            <a style="float:right" href="UserLogin.aspx">LOGIN</a>
            <a style="float:right" href="UserRegister.aspx">REGISTER</a>
       </div>
         <div class="slideshow-container">

            <div class="mySlides fade">
             <div class="numbertext">1 / 3</div>
             <img src="Images/fashion.jpg" style="width:100%"/>
            </div>

            <div class="mySlides fade">
             <div class="numbertext">2 / 3</div>
             <img src="Images/fashion3.jpg" style="width:100%"/>
           </div>

          <div class="mySlides fade">
            <div class="numbertext">3 / 3</div>
            <img src="Images/fashion2.jpg" style="width:100%"/>
           </div>

        </div>
        <br/>

        <div style="text-align:center">
            <span class="dot"></span> 
            <span class="dot"></span> 
            <span class="dot"></span> 
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

    <script>
        var slideIndex = 0;
        showSlides();

        function showSlides() {
            var i;
            var slides = document.getElementsByClassName("mySlides");
            var dots = document.getElementsByClassName("dot");
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";  
            }
            slideIndex++;
            if (slideIndex > slides.length) {slideIndex = 1}    
             for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" active", "");
             }
            slides[slideIndex-1].style.display = "block";  
            dots[slideIndex-1].className += " active";
            setTimeout(showSlides, 3000); // Change image every 3 seconds
        }
    </script>

</body>
</html>


