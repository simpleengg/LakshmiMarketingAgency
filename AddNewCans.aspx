<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="AddNewCans.aspx.vb" Inherits="AddNewCans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 157px;
        }
        .style2
        {
            width: 144px;
        }
        .style3
        {
            width: 72px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script src="Scripts/datetimepicker.js" type="text/javascript"></script>
<table style="font-size: small; font-family: Calibri" width="100%">
</table>
<br />
    <br />
   <table style="font-size: small; font-family: Calibri" width="100%">
        <tr>
        <td class="style1">
    <asp:Label ID="lb_ptype" runat="server" Font-Names="Calibri" Font-Size="Small" 
        Text="Procurement Type"></asp:Label>
        </td>
        <td class="style2"><asp:DropDownList ID="dl_ptype" Font-Names="Calibri" 
                Font-Size="Small" runat="server" style="margin-left: 0px">
            <asp:ListItem Selected="True">Refill</asp:ListItem>
            <asp:ListItem>NewCan</asp:ListItem>
            </asp:DropDownList></td>
            
        <td class="style3">
            <asp:Label ID="lb_cantype" runat="server" Font-Names="Calibri" 
                Font-Size="Small" Text="Can Type"></asp:Label>
            </td>
        <td>
            <asp:DropDownList ID="dl_cantype" runat="server" Font-Names="Calibri" 
                Font-Size="Small">
            </asp:DropDownList>
            </td>
        </tr>
         <tr>
        <td></td>
        </tr>       
        <tr>
        <td></td>
        </tr>
         <tr>
        <td></td>
        </tr>       
        <tr>
        <td></td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="lb_date" runat="server" Font-Names="Calibri" Font-Size="Small" 
                Text="Procurement Date"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="tx_date" runat="server" Font-Names="Calibri" Font-Size="Small" 
                Width="109px"></asp:TextBox><a href="javascript:NewCal('MainContent_tx_date','ddMMMyyyy','true')"><img src="cal.gif" width="16" height="16" border="0" alt="Pick a date"/></a>
            </td>
        <td>
            <asp:Label ID="lb_cansize" runat="server" Font-Names="Calibri" 
                Font-Size="Small" Text="Can Size"></asp:Label>
            </td>
        <td>
            <asp:DropDownList ID="dl_cansize" runat="server" Font-Names="Calibri" 
                Font-Size="Small">
            </asp:DropDownList>
            </td>
        </tr>
         <tr>
        <td></td>
        </tr>       
        <tr>
        <td></td>
        </tr>
         <tr>
        <td></td>
        </tr>       
        <tr>
        <td></td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="lb_canname" runat="server" Font-Names="Calibri" 
                Font-Size="Small" Text="Number of Cans"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="tx_cannumber" runat="server" Font-Names="Calibri" 
                Font-Size="Small" Width="108px"></asp:TextBox>
            </td>
        <td></td>
        <td></td>
        </tr>
        </table>
        <br />
    <br />
        <table width="100%" style="font-family: Calibri; font-size: small">
        <tr>
        <td>
            <asp:Button ID="btn_submit" runat="server" Text="Submit" Font-Size="Small" Font-Names="Calibri" /></td>
            <td>
                            <asp:Label ID="lb_success" runat="server" Text="Can data has been entered successfully" Visible="False" ForeColor="#006600"></asp:Label>
                            <br />
                            <asp:Label ID="lb_failure" runat="server" Text="Failed to enter can details" Visible="False" ForeColor="#CC3300"></asp:Label>
                            </td>
            </tr>
        </table>
</asp:Content>

