<%@ Page Title="Prorgamaholics - Home" Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web460 Course Project</title>
    <link href="HomeSheet.css" rel="stylesheet" type="text/css" />
    <link href="bootstrap-theme.css" rel="stylesheet" type="text/css" />
    <link href="bootstrap.css" rel="stylesheet" type="text/css" />
</head>
    <body style="height: 624px">
        <div id="main_content">

        <form id="form1" runat="server" class="auto-style1">
               <div class="home_logo">PROGRAMAHOLICS</div>
            <p/>
                <asp:TextBox ID="txtUsername" runat="server" ></asp:TextBox>
            <p/>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br/>
            <asp:Button ID="btnLogin" Cssclass="btn-primary" onClick="btnLogin_Click" runat="server" Text="Log In" />
            <br/>
            <asp:Button ID="btnCreate" CssClass="btn-info" OnClick="btnCreate_Click" runat="server" Text="Create New Account" />
                <asp:Label ID="lblUserFeedback" runat="server" Text=""></asp:Label>
        </form>

        </div>
    </body>
</html>