<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AmountDue.aspx.cs" Inherits="ExpenseCalculator.WebForm4" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        
//
// This function will allow users to insert only numbers in the textboxes.
//

function onlyNumbers(evt) {
         var e = event || evt; // for trans-browser compatibility
         var charCode = e.which || e.keyCode;

         if (charCode > 31 && (charCode < 48 || charCode > 57))
             return false;
         return true;
     }

//
// This function is to calculate all the values of textboxes.
//

     function Add() {
         var a, b, c, d,e;
         a = parseFloat(document.getElementById("<%=txt_kartik.ClientID %>").value);
         
//
// If textbox value is null i.e empty, then the below mentioned if condition will 
// come into picture and make the value to '0' to avoid errors.
//

 if (isNaN(a) == true) {
         a = 0;
     }
      b = parseFloat(document.getElementById("<%=txt_pankaj.ClientID %>").value);
     if (isNaN(b) == true) {
         b = 0;
     }
      c = parseFloat(document.getElementById("<%=txt_abhi.ClientID %>").value);
     if (isNaN(c) == true) {
         c = 0;
     }
      d = parseFloat(document.getElementById("<%=txt_rahul.ClientID %>").value);
     if (isNaN(d) == true) {
         d = 0;
     }
      e = parseFloat(document.getElementById("<%=txt_shad.ClientID %>").value);
     if (isNaN(e) == true) {
         e = 0;
     }
     var result = a + b + c + d + e;
     document.getElementById("<%=lbl_total.ClientID %>").innerText = "Total : " + result;
}
</script>

    <style type="text/css">
        .style6
    {
        width: 113%;
    }
        .style13
        {
            height: 49px;
        }
        .style15
        {
            height: 41px;
        }
        .style16
        {
            height: 36px;
        }
        .style17
        {
            height: 33px;
        }
        .style18
        {
            height: 34px;
        }
        .style19
        {
            height: 34px;
            width: 231px;
        }
        .style20
        {
            height: 33px;
            width: 231px;
        }
        .style21
        {
            height: 36px;
            width: 231px;
        }
        .style22
        {
            height: 41px;
            width: 231px;
        }
        .style23
        {
            height: 49px;
            width: 231px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style6" 
        
        style="background-color: #CCFFCC; font-family: 'Times New Roman', Times, serif; font-size: large; font-weight: bolder; font-style: normal; height: 255px;">
    <tr>
        <td class="style18">
            Shad</td>
        <td class="style19">
            <asp:CheckBox ID="chk_shad" runat="server" Text="Being Paid" />
            <asp:TextBox ID="txt_shad" runat="server" Width="90px" 
              onKeyUp="Add()"></asp:TextBox>
        </td>
        <td class="style18">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_shad" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td class="style18">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style17">
            Kartik</td>
        <td class="style20">
            <asp:CheckBox ID="chk_kartik" runat="server" Text="Being Paid" />
            <asp:TextBox ID="txt_kartik" runat="server" Width="92px" 
               onKeyUp="Add()"></asp:TextBox>
        </td>
        <td class="style17">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_kartik" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td class="style17">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style16">
            Abhinav</td>
        <td class="style21">
            <asp:CheckBox ID="chk_abhi" runat="server" Text="Being Paid" />
            <asp:TextBox ID="txt_abhi" runat="server" style="margin-bottom: 0px" 
                onKeyUp="Add()" Width="92px"></asp:TextBox>
        </td>
        <td class="style16">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_abhinav" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        </td>
        <td class="style16">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style15">
            Pankaj</td>
        <td class="style22">
            <asp:CheckBox ID="chk_pankaj" runat="server" Text="Being Paid" />
            <asp:TextBox ID="txt_pankaj" onKeyUp="Add()" runat="server" Width="95px" ></asp:TextBox>
        </td>
        <td class="style15">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_pankaj" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td class="style15">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style13">
            Rahul</td>
        <td class="style23">
            <asp:CheckBox ID="chk_rahul" runat="server" Text="Being Paid" />
            <asp:TextBox ID="txt_rahul" runat="server" Width="95px" onKeyUp="Add()"></asp:TextBox>
        </td>
        <td class="style13">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_rahul" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td class="style13">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lbl_total" runat="server"></asp:Label>
        </td>
        <td colspan="2">
            <asp:Button ID="Button1" runat="server" Text="Clear Dues" 
                onclick="Button1_Click" />
        </td>
    </tr>
</table>
</asp:Content>
