<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="contentHeader" ContentPlaceHolderID="head" Runat="Server">
    &lt;LOGO HERE&gt;
</asp:Content>
<asp:Content ID="contentInterface" ContentPlaceHolderID="cphInterface" Runat="Server">
    <asp:TextBox ID="tbSearch" runat="server" Width="820px"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" />
    <br />
    <asp:ImageButton ID="ibFirst" runat="server" ClientIDMode="Static" ImageUrl="~/files/images/first.png" OnClick="ImageButton1_Click" />
    &nbsp;
    <asp:ImageButton ID="ibPrevious" runat="server" ImageUrl="~/files/images/previous.png" />
    &nbsp;
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/files/images/next.png" />
    &nbsp;
    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/files/images/last.png" />
    &nbsp;
    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/files/images/print.png" />
    &nbsp;
    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/files/images/save.png" />
    <br />
    <asp:TextBox ID="tbFilename" runat="server" Width="700px" ReadOnly="True"></asp:TextBox>
    <asp:TextBox ID="tbResultsNum" runat="server" Width="120px" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:TextBox ID="taResult" runat="server" Height="500px" TextMode="MultiLine" Width="820px"></asp:TextBox>
</asp:Content>
