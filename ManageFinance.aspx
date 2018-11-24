<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ManageFinance.aspx.vb" Inherits="ManageFinance" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 173px;
        }
        .style3
        {
            width: 142px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <br/>
<br/>
<table ID="Table1" runat="server" width="100%" 
        style="font-family: Calibri; font-size: medium;">
    <tr>
    <td class="style3">
        <asp:Label ID="lb_customer" runat="server" Font-Names="Calibri" 
            Font-Size="Medium" Text="Select Customer"></asp:Label>
    </td>
    <td class="style2">
        <asp:DropDownList ID="dl_customer" runat="server" Font-Names="Calibri" 
            Font-Size="Medium">
             </asp:DropDownList>
        </td>
        <td>
            <asp:ImageButton ID="GO" runat="server" ImageUrl="~/search_header.gif" />
        </td>
        </tr></table>
        <br />
        <br />
        <asp:GridView ID="gr_custdata" runat="server" Font-Names="Calibri" 
        Font-Size="Medium" EmptyDataText="No valid data available" 
        AutoGenerateColumns="False" Visible="False" DataKeyNames="ID" 
        AllowSorting="True">
        <Columns>
        <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" />
        <asp:BoundField DataField="Can_ID" HeaderText="Can ID" />
        <asp:BoundField DataField="Assign_Date" HeaderText="Date of Delivery" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="Total_Amount" HeaderText="Total Amount" />
        <asp:BoundField DataField="Advance" HeaderText="Amount Received" />
        <asp:BoundField DataField="Balance" HeaderText="Pending Balance" />
        <asp:TemplateField HeaderText = "Modify">
   <ItemTemplate>
       <asp:ImageButton ID="img_assign" runat="server" imageurl= "~/update1.jpg" ImageAlign="Middle" OnClick="Modify"></asp:ImageButton>
   </ItemTemplate>
   <ItemStyle Width="30px" />
    </asp:TemplateField>               
        </Columns>
        <HeaderStyle BackColor="#3399FF" ForeColor="White" />
        <RowStyle BackColor="#D0E8FF" />
    </asp:GridView>
    <asp:Panel ID="modifypnl" runat="server" CssClass="ModalWindow"
        style="display:none; background-color: lightgrey;" Width="500px" 
        BackColor="White">            
            <table ID="Table2" runat="server" font-names="Calibri" font-size="Medium" 
                width="100%">
                <tr>
                <td align="center">
                <asp:Label ID="lb_modify" runat="server" Text="Payment Updates" 
                        Font-Names="Calibri" Font-Size="Large"></asp:Label>
                </td>
                </tr>
            </table>
            <br /><br />
            <table style="font-size: small; font-family: Calibri" width="100%">
                <tr>
                <td>
                    <asp:Label ID="lb_id" runat="server" Visible="False"></asp:Label></td></tr>
              </table>
              <table style="font-size: small; font-family: Calibri" width="100%">
                    <tr>
                    <td style="width: 32px"></td>
                        <td class="style1">
                            <asp:Label ID="lb_amount" runat="server" Style="font-size: small; font-family: Calibri"
                                Text="Enter total amount"></asp:Label></td>
                                <td>
            <asp:TextBox ID="tx_amount" Style="font-size: small; font-family: Calibri" runat="server" Width="150px" ReadOnly="False"></asp:TextBox>
            </td>
                    </tr>
                    <tr>
                    <td class="style2"></td>
                        <td class="style3">
                            <asp:Label ID="lb_advance" runat="server" Text="Amount Received"></asp:Label>                           
                        </td>
                            <td class="style4"><asp:TextBox ID="tx_advance" runat="server" Width="150px" style="font-size: small; font-family: Calibri"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td></td>
                    <td>
                            <asp:Label ID="lb_balance" runat="server" Text="Pending Balance" Visible="False"></asp:Label>                           
                        </td>
                            <td><asp:TextBox ID="tx_balance" runat="server" Width="150px" style="font-size: small; font-family: Calibri" Visible="False"></asp:TextBox></td>
                    </tr>
                    </table>
                    <br />
                 <br />
                 <br />
                    <table width="100%">
                    <tr>
                    <td style="width: 32px;"></td>
                        <td align="center">
<asp:Button ID="Save" runat="server" Text="Save" OnClick = "FinSave" />
                            &nbsp;<asp:Button ID="Cancel" runat="server" Text="Cancel"/></td>
                            <td style="width :76px"></td>
                    </tr>
                    <tr>
                        <td style="width: 32px">
                        </td>
                        <td align="center">
                        </td>
                        <td style="width: 76px">
                        </td>
                    </tr>
                </table>
                <br />
            </asp:Panel>
   <asp:LinkButton ID="lnkFakeid" runat="server"></asp:LinkButton>
   <cc1:ModalPopupExtender ID="popup" runat="server" DropShadow="false"
PopupControlID="modifypnl" TargetControlID = "lnkFakeid" RepositionMode ="RepositionOnWindowResizeAndScroll"
BackgroundCssClass="modalBackground" CancelControlID="Cancel">
</cc1:ModalPopupExtender>          
</asp:Content>

