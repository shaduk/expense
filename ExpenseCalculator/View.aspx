﻿<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="ExpenseCalculator.WebForm2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    <asp:ListItem>Pankaj</asp:ListItem>
    <asp:ListItem>Kartik</asp:ListItem>
    <asp:ListItem>Rahul</asp:ListItem>
    <asp:ListItem>Abhinav</asp:ListItem>
    <asp:ListItem>Shad</asp:ListItem>
</asp:DropDownList>
&nbsp;<asp:LinkButton ID="viewall" runat="server" onclick="viewall_Click">View 
All</asp:LinkButton>
&nbsp;<asp:GridView ID="GridView1" runat="server" CellPadding="4" onselectedindexchanged="GridView1_SelectedIndexChanged" 
    Width="490px" AutoGenerateDeleteButton="True" DataKeyNames="serial" 
    ForeColor="#333333" GridLines="None" onrowdeleting="GridView1_RowDeleting">
    <RowStyle BackColor="#EFF3FB" />
    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
    <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
<br />
<br />
&nbsp;<asp:Label ID="total" runat="server"></asp:Label>
<br />
&nbsp;<asp:Label ID="perhead" runat="server"></asp:Label>
</asp:Content>
