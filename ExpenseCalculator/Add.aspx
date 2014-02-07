<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ExpenseCalculator.WebForm1" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style7
    {
        width: 100%;
    }
    .style8
    {
        height: 59px;
    }
    .style9
    {
        height: 108px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style7">
    <tr>
        <td>
            Person</td>
        <td>
            <asp:DropDownList ID="droplist_person" runat="server">
                <asp:ListItem>Pankaj</asp:ListItem>
                <asp:ListItem>Kartik</asp:ListItem>
                <asp:ListItem>Rahul</asp:ListItem>
                <asp:ListItem>Abhinav</asp:ListItem>
                <asp:ListItem>Shad</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Stuff</td>
        <td>
            <asp:TextBox ID="txt_stuff" runat="server" Height="82px" Width="195px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
&nbsp;
            <br />
        </td>
    </tr>
    <tr>
        <td class="style8">
            Price</td>
        <td class="style8">
            <asp:TextBox ID="txt_price" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style9">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td class="style9">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Add Record" 
                onclick="Button2_Click" />
        </td>
    </tr>
</table>
</asp:Content>
