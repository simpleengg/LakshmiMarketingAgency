<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="AddNewCustomer.aspx.vb" Inherits="AddNewCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 139px;
        }
        .style2
        {
            width: 204px;
        }
        .style3
        {
            width: 75px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <br />
    <table style="font-size: small; font-family: Calibri" width="100%">
        <tr>
        <td class="style1">
            <asp:Label ID="lb_custname" runat="server" Text="Customer Name" 
                Font-Names="Calibri" Font-Size="Small"></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="tx_customername" runat="server" Font-Names="Calibri" 
                Font-Size="Small"></asp:TextBox>
        </td>
        <td class="style3">
        <asp:Label ID="lb_mobile" runat="server" Text="Mobile" Font-Names="Calibri" 
                Font-Size="Small"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="tx_mobile" runat="server" Font-Names="Calibri" Font-Size="Small"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td></td>
        </tr>       
        <tr>
        <td></td>
        </tr>
        <tr>
         <td class="style1">         
            <asp:Label ID="lb_landline" runat="server" Text="Customer Landline" 
                 Font-Names="Calibri" Font-Size="Small"></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="tx_landline" runat="server" Font-Names="Calibri" 
                Font-Size="Small"></asp:TextBox>
        </td>
        <td class="style3">
        <asp:Label ID="lb_city" runat="server" Text="City" Font-Names="Calibri" 
                Font-Size="Small"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="tx_city" runat="server" Font-Names="Calibri" Font-Size="Small"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td></td>
        </tr>       
        <tr>
        <td></td>
        </tr>
        <tr>
         <td class="style1">         
            <asp:Label ID="lb_addr" runat="server" Text="Customer Address" 
                 Font-Names="Calibri" Font-Size="Small"></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="tx_address" runat="server" Height="70px" Font-Names="Calibri" 
                Font-Size="Small" TextMode="MultiLine"></asp:TextBox>
        </td>
        <td class="style3">
        <asp:Label ID="lb_landmark" runat="server" Text="Landmark" Font-Names="Calibri" 
                Font-Size="Small"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="tx_landmark" runat="server" Font-Names="Calibri" Font-Size="Small"></asp:TextBox>
        </td>
        </tr>
        </table>
        <br />
    <br />
        <table style="font-size: small; font-family: Calibri" width="100%"></table>
         <table style="font-size: small; width: 100%; font-family: Calibri">
                <tr>
                    <td style="width: 139px; height: 107px">
                    </td>
                    <td style="height: 26px" align="left">
                        <asp:Button ID="btn_submit" runat="server" Text="Submit" style="font-size: small; font-family: Calibri" /></td>
                        <td>
                            <asp:Label ID="lb_success" runat="server" Text="New customer data has been entered successfully" Visible="False" ForeColor="#006600"></asp:Label>
                            <br />
                            <asp:Label ID="lb_failure" runat="server" Text="Failed to enter new customer details" Visible="False" ForeColor="#CC3300"></asp:Label>
                            </td>
                </tr>
            </table>
    </asp:Content>

