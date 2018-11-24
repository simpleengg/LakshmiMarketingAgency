<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="GenerateReports.aspx.vb" Inherits="GenerateReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 130px;
        }
        .style2
        {
            width: 133px;
        }
        .style3
        {
            width: 269px;
        }
        .style4
        {
            width: 90px;
        }
        .style5
        {
            width: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<br/>
<br/>
    <table ID="Table1" runat="server" width="100%" 
        style="font-family: Calibri; font-size: medium">
    <tr>
    <td class="style1">
        <asp:Label ID="lb_reporttype" runat="server" Font-Names="Calibri" 
            Font-Size="Medium" Text="Report Type"></asp:Label>
    </td>
    <td class="style3">
        <asp:DropDownList ID="dl_reportytype" runat="server" Font-Names="Calibri" 
            Font-Size="Medium">
            <asp:ListItem>Customer Report - Monthly</asp:ListItem>
            <asp:ListItem>Can Validity</asp:ListItem>
            <asp:ListItem Selected="True">Previous Used Data</asp:ListItem>
        </asp:DropDownList>
        </td><td class="style5">
            <asp:ImageButton ID="img_choose" runat="server" ImageUrl="~/search-btn.png" 
                style="margin-left: 0px" /></td>
                <td class="style4">
                    <asp:Label ID="lb_cid" runat="server" Text="Select Can" Visible="False"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="dl_cid" runat="server" Visible="False">
                        </asp:DropDownList>
                    </td>
                </tr></table>
        <br />
        <table ID="Table3" runat="server" width="100%" 
        style="font-family: Calibri; font-size: medium">
    <tr>
    <td class="style1">
        <asp:Label ID="lb_month" runat="server" Font-Names="Calibri" 
            Font-Size="Medium" Text="Select Month" Visible="False"></asp:Label>
    </td>
    <td class="style2">
        <asp:DropDownList ID="dl_month" runat="server" Font-Names="Calibri" 
            Font-Size="Medium" Visible="False">
            <asp:ListItem>January</asp:ListItem>
            <asp:ListItem>February</asp:ListItem>
            <asp:ListItem>March</asp:ListItem>
            <asp:ListItem>April</asp:ListItem>
            <asp:ListItem Value="May">May</asp:ListItem>
            <asp:ListItem>June</asp:ListItem>
            <asp:ListItem>July</asp:ListItem>
            <asp:ListItem>August</asp:ListItem>
            <asp:ListItem>September</asp:ListItem>
            <asp:ListItem>October</asp:ListItem>
            <asp:ListItem>November</asp:ListItem>
            <asp:ListItem>December</asp:ListItem>
        </asp:DropDownList>
        </td><td>
            <asp:DropDownList ID="dl_year" runat="server" Font-Names="Calibri" 
            Font-Size="Medium" Visible="False">
            <asp:ListItem>2017</asp:ListItem>
            <asp:ListItem>2018</asp:ListItem>
            </asp:DropDownList>
            </td></tr></table>
            <br />
<table ID="Table4" runat="server" width="100%" 
        style="font-family: Calibri; font-size: medium">
    <tr>
    <td class="style1">
        <asp:Label ID="lb_customer" runat="server" Font-Names="Calibri" 
            Font-Size="Medium" Text="Select Customer" Visible="False"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="dl_customer" runat="server" Font-Names="Calibri" 
            Font-Size="Medium" Visible="False">            
        </asp:DropDownList>
        </td></tr></table>
        <br />
        <br />
        <table ID="Table2" runat="server" width="100%" 
        style="font-family: Calibri; font-size: medium">
        <tr><td>
            <asp:Button ID="btn_report" runat="server" Text="Generate" Font-Size="Medium" BorderStyle="Inset" Font-Names="Calibri"/></td></tr>
    </table>
    <br />

    <asp:GridView ID="gr_reports" runat="server" Font-Names="Calibri" 
        Font-Size="Medium" EmptyDataText="No valid data available" 
        AutoGenerateColumns="True" Visible="False">
     
   <HeaderStyle BackColor="#3399FF" ForeColor="White" />
        <RowStyle BackColor="#D0E8FF" />
    </asp:GridView>
    <asp:Label ID="lb_useddata" runat="server" Font-Names="Calibri" 
        Font-Size="Large" ForeColor="#009933" Visible="False"></asp:Label>
    <br />
    <asp:GridView ID="gr_custdata" runat="server" Font-Names="Calibri" 
        Font-Size="Medium" EmptyDataText="No valid data available" 
        AutoGenerateColumns="False" Visible="False" DataKeyNames="ID" 
        AllowSorting="True">
     
            <Columns>           
                <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" />
                <asp:BoundField DataField="Can_ID" HeaderText="Can ID" />
                <asp:BoundField DataField="Can_Status" HeaderText="Can Status" />
                <asp:BoundField DataField="Assign_Date" HeaderText="Date of Delivery" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="Release_Date" HeaderText="Date of Return" DataFormatString="{0:yyyy-MM-dd}" />
                </Columns>
   <HeaderStyle BackColor="#3399FF" ForeColor="White" />
        <RowStyle BackColor="#D0E8FF" />
    </asp:GridView>
</asp:Content>

