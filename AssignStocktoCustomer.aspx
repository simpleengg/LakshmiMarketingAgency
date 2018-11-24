<%@ page title="" language="VB" masterpagefile="~/Site.master" autoeventwireup="false" inherits="AssignStocktoCustomer, App_Web_uxmyka3m" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    <style type="text/css">
        .style1
        {
            width: 140px;
        }
        .style2
        {
            width: 32px;
            height: 31px;
        }
        .style3
        {
            width: 76px;
            height: 31px;
        }
        .style4
        {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type = "text/javascript">
    function Hidepopup() {
        var modal = $find("popup");
        modal.hide();
        return false;
    }
</script>
   <script src="Scripts/datetimepicker.js" type="text/javascript"></script>
        <asp:GridView ID="gr_assignstock" runat="server" Font-Names="Calibri" 
        Font-Size="Medium" AutoGenerateColumns="False" AllowSorting="True" 
        DataKeyNames="Customer_ID">
            <Columns>           
                <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" />
                <asp:BoundField DataField="Customer_Mobile" HeaderText="Customer Mobile" />
                <asp:BoundField DataField="Customer_Address" HeaderText="Customer Address" />
                <asp:BoundField DataField="Can_ID" HeaderText="Can ID" />
                <asp:BoundField DataField="Assign_Date" 
                    HeaderText="Assigned Date" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="Release_Date"
                    HeaderText="Released Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:TemplateField HeaderText = "Assign">
   <ItemTemplate>
       <asp:ImageButton ID="img_assign" runat="server" imageurl= "~/update_old.jpg" ImageAlign="Middle" OnClick="Assign"></asp:ImageButton>
   </ItemTemplate>
                        <ItemStyle Width="30px" />
    </asp:TemplateField>                 
            </Columns>
            <HeaderStyle BackColor="#3399FF" ForeColor="White" />
        <RowStyle BackColor="#D0E8FF" />
    </asp:GridView>  
    
        <asp:Panel ID="assgnpnl" runat="server" CssClass="ModalWindow" style="display:none; background-color: lightgrey;" Width="800px" BackColor="White">            
            <table ID="Table1" runat="server" font-names="Calibri" font-size="Medium" 
                width="100%">
                <tr>
                <td align="center">
                <asp:Label ID="Label1" runat="server" Text="Assign Stock to Customer" 
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
                            <asp:Label ID="lb_canid" runat="server" Style="font-size: small; font-family: Calibri"
                                Text="Enter can id's for assignment"></asp:Label></td>
                                <td>
            <asp:TextBox ID="tx_canid" Style="font-size: small; font-family: Calibri" runat="server" Width="150px" ReadOnly="False"></asp:TextBox>
            </td>
                    </tr>
                    <tr>
                    <td class="style2"></td>
                        <td class="style3">
                            <asp:Label ID="lb_adate" runat="server" Text="Assignment Date"></asp:Label>                           
                        </td>
                            <td class="style4"><asp:TextBox ID="tx_assigndate" runat="server" Width="150px" style="font-size: small; font-family: Calibri"></asp:TextBox><a href="javascript:NewCal('MainContent_tx_assigndate','ddMMMyyyy','true')"><img src="cal.gif" width="16" height="16" border="0" alt="Pick a date"/></a></td>
                    </tr>
                    </table>
                 <br />
                 <br />
                 <br />
                    <table width="100%">
                    <tr>
                    <td style="width: 32px;"></td>
                        <td align="center">
<asp:Button ID="btnSave" runat="server" Text="Save" OnClick = "Save" />
                            &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel"/>&nbsp;<asp:Button ID="btnRelease" runat="server" Text="Release" /></td>
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
        <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
   <cc1:ModalPopupExtender ID="popup" runat="server" DropShadow="false"
PopupControlID="assgnpnl" TargetControlID = "lnkFake" RepositionMode ="RepositionOnWindowResizeAndScroll"
BackgroundCssClass="modalBackground" CancelControlID="btnCancel">
</cc1:ModalPopupExtender>
     <asp:Panel ID="relpanel" runat="server" CssClass="ModalWindow" style="display:none; background-color: lightgrey;" Width="800px" BackColor="White">
     <table ID="Table2" runat="server" font-names="Calibri" font-size="Medium" 
                width="100%">
                <tr>
                <td align="center">
                <asp:Label ID="Label2" runat="server" Text="Release Stock" 
                        Font-Names="Calibri" Font-Size="Large"></asp:Label>
                </td>
                </tr>
            </table>
            <br /><br />
     </asp:Panel>
    <asp:Label ID="lcname" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="lcmob" runat="server" Text="Label" Visible="False"></asp:Label>
</asp:Content>


