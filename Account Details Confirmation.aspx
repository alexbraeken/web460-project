<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Account Details Confirmation.aspx.cs" Inherits="Account_Details_Confirmation" %>
<%@ PreviousPageType VirtualPath="~/Account Details.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> Confirmation
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:TextBox ID="txtFavLang" runat="server"></asp:TextBox>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <asp:TextBox ID="txtLeastFavLang" runat="server"></asp:TextBox>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <asp:Calendar ID="calLastProgDate" runat="server"></asp:Calendar>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
    <asp:Label ID="lblUserFeedback" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content9" runat="server" contentplaceholderid="ContentPlaceHolderButtons">
            <asp:Button ID="btnUpdate" runat="server" style="float:right;" Text="Update Account" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnDelete" CssClass="btn-danger" runat="server" style="float:right;" Text="Delete Account" OnClick="btnDelete_click" />
</asp:Content>


