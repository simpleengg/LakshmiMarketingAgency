<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CanInventory.aspx.vb" Inherits="CanInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <asp:Panel ID ="contentpanel" Height="100%" runat="server"
        Width="100%" BackColor="#CACACA">
<br/>
<br/>
<br/>

    <asp:Panel ID="Panel1" runat="server" BackColor="White" Height="250px" 
        Width="100%">
        <table>
        <tr>
        <td>
        <asp:Panel ID="Panel2" runat="server" BackColor="#60D760" Height="150px" 
            Width="150px">
            <br />
            <br />           
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lb_total" runat="server" Font-Bold="True" 
                Font-Names="Franklin Gothic Medium" Font-Size="X-Large" ForeColor="White"></asp:Label>
           <br />           
            <asp:Button ID="btn_total" runat="server" BorderStyle="None" 
                Font-Names="Calibri" Text="Cans in Total" Font-Bold="True" 
                Font-Size="Medium" />
        </asp:Panel>
        </td>
        <td width="100px"></td>
        <td>
        <asp:Panel ID="Panel3" runat="server" BackColor="#FFA824" Height="150px" 
            Width="150px">
            <br />
            <br />           
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lb_stock" runat="server" Font-Bold="True" 
                Font-Names="Franklin Gothic Medium" Font-Size="X-Large" ForeColor="White"></asp:Label>
           <br />
            <asp:Button ID="btn_stock" runat="server" Font-Bold="True" Font-Names="Calibri" BorderStyle="None"
                Font-Size="Medium" Text="Cans in Stock" ForeColor="White"></asp:Button>
        </asp:Panel>
        </td>
        <td width="100px"></td>
        <td>
        <asp:Panel ID="Panel4" runat="server" BackColor="#6666FF" Height="150px" 
            Width="150px">
            <br />
            <br />           
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lb_assigned" runat="server" Font-Bold="True" 
                Font-Names="Franklin Gothic Medium" Font-Size="X-Large" ForeColor="White"></asp:Label>
           <br />
            <asp:Button ID="btn_assigned" runat="server" Font-Bold="True" Font-Names="Calibri" BorderStyle="None"
                Font-Size="Medium" Text="Cans Assigned" ForeColor="White"></asp:Button>
        </asp:Panel>
        </td>
        <td width="100px"></td>
        <td>
        <asp:Panel ID="Panel5" runat="server" BackColor="#FF2D2D" Height="150px" 
            Width="150px">
            <br />
            <br />           
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lb_released" runat="server" Font-Bold="True" 
                Font-Names="Franklin Gothic Medium" Font-Size="X-Large" ForeColor="White"></asp:Label>
           <br />
            <asp:Button ID="btn_released" runat="server" Font-Bold="True" Font-Names="Calibri" BorderStyle="None"
                Font-Size="Medium" Text="Cans to be Refilled" ForeColor="White"></asp:Button>
        </asp:Panel>
        </td>
        </tr>
        </table>
    </asp:Panel>
    <asp:GridView ID="gr_dispdata" runat="server" Font-Names="Calibri" 
        Font-Size="Medium" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="ID">
        <Columns>           
                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />                  
                <asp:BoundField DataField="Can_ID" HeaderText="Can ID" />
                <asp:BoundField DataField="Can_Status" HeaderText="Can Status" />                
                </Columns>
                <HeaderStyle BackColor="#3399FF" ForeColor="White" />
        <RowStyle BackColor="#D0E8FF" />
    </asp:GridView>
    </asp:Panel>
</asp:Content>

