<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="contentHeader" ContentPlaceHolderID="head" Runat="Server">
    &lt;LOGO HERE&gt;
</asp:Content>
<asp:Content ID="contentInterface" ContentPlaceHolderID="cphInterface" Runat="Server">
    <asp:RequiredFieldValidator ID="rfvSearch" runat="server" ErrorMessage="Search query was empty." ControlToValidate="tbSearch" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="tbSearch" runat="server" Width="820px"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    <br />
    <asp:ImageButton ID="ibFirst" runat="server" ImageUrl="~/files/images/first.png" OnClick="ibFirst_Click" />
    &nbsp;
    <asp:ImageButton ID="ibPrevious" runat="server" ImageUrl="~/files/images/previous.png" OnClick="ibPrevious_Click" />
    &nbsp;
    <asp:ImageButton ID="ibNext" runat="server" ImageUrl="~/files/images/next.png" OnClick="ibNext_Click" />
    &nbsp;
    <asp:ImageButton ID="ibLast" runat="server" ImageUrl="~/files/images/last.png" OnClick="ibLast_Click" />
    &nbsp;
    <asp:ImageButton ID="ibPrint" runat="server" ImageUrl="~/files/images/print.png" />
    &nbsp;
    <asp:ImageButton ID="ibSave" runat="server" ImageUrl="~/files/images/save.png" />
    <br />
    <asp:TextBox ID="tbFilename" runat="server" Width="700px" ReadOnly="True"></asp:TextBox>
    <asp:TextBox ID="tbResultsNum" runat="server" Width="120px" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:TextBox ID="taResult" runat="server" Height="500px" TextMode="MultiLine" Width="820px"></asp:TextBox>
</asp:Content>
