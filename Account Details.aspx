<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Account Details.aspx.cs" Inherits="Account_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> Account Details
</asp:Content>
<asp:Content ID="ContentRow1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><asp:Label ID="txtUsername" runat="server" Text=""></asp:Label></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server"><asp:Label ID="txtFavLang" runat="server" Text=""></asp:Label></asp:Content>            
<asp:Content ID="ContentRow2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server"><asp:Label ID="txtCity" runat="server" Text=""></asp:Label></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server"><asp:Label ID="txtLeastFav" runat="server" Text=""></asp:Label></asp:Content>
<asp:Content ID="ContentRow3" ContentPlaceHolderID="ContentPlaceHolder5" runat="server"><asp:Label ID="txtState" runat="server" Text=""></asp:Label></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder6" runat="server"><asp:Label ID="txtLastProgDate" runat="server" Text=""></asp:Label></asp:Content>

<asp:Content ID="account_table" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
    <asp:Button ID="btnExport" CssClass="btn-default" runat="server" Text="Export" style="float:right;" OnClick="btnExport_Click" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Application_ID" DataSourceID="sqlCourse_Project_db" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Width="70%">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Application_ID" HeaderText="Application ID" InsertVisible="False" ReadOnly="True" SortExpression="Application_ID" />
            <asp:BoundField DataField="Application_Name" HeaderText="Application Name" SortExpression="Application_Name" />
            <asp:BoundField DataField="Application_Date" HeaderText="Application Date" SortExpression="Application_Date" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:SqlDataSource ID="sqlCourse_Project_db" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [Application_ID], [Application_Name], [Application_Date] FROM [tblApplications] WHERE ([Username] = ?)">
            <SelectParameters>
                <asp:SessionParameter Name="Username" SessionField="username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:Label ID="lblUserFeedback" runat="server" Text="" CssClass="label"></asp:Label>
</asp:Content>
<asp:Content ID="Content9" runat="server" contentplaceholderid="ContentPlaceHolderButtons">
            <asp:Button ID="btnUpdate" Cssclass="btn-default" runat="server" style="float:right;" Text="Update Account" PostBackUrl="~/Account Details Confirmation.aspx" />
        <asp:Button ID="btnDelete" CssClass="btn-danger" runat="server" style="float:right;" Text="Delete Account" OnClick="btnDelete_click" />
</asp:Content>
