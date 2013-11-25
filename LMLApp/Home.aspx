<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LMLApp.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="login-wrapper" style="width:400px;margin: 100px auto;padding-bottom: 10px;" >
        <h2 class="title">Login</h2>        
        <asp:Label ID="lblMemberId" runat="server" Text="Member Id" Width="150px" CssClass="label"></asp:Label>               
        <asp:TextBox ID="userNameTextBox" runat="server" Width="200px"></asp:TextBox>
        <asp:Label ID="lblPassword" runat="server" Text="Password" Width="150px" CssClass="label"></asp:Label>    
        <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password" Width="200px"></asp:TextBox>				
        <asp:Button ID="btnLogin" runat="server" Text="Login" style="width:100px;margin-left: 165px;"/> 
        <br style="clear: both;"/>
        <ul id="login" style="margin-top: 5px;">                
            <li><asp:LinkButton ID="lbForget" runat="server">Forget Your Password</asp:LinkButton></li>				
            <li><asp:LinkButton ID="lbClickGet" runat="server">Click Here Get</asp:LinkButton></li>				
		</ul> 
    </div>
    
</asp:Content>
