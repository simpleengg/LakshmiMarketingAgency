Imports System.IO
Imports System.Net.Mail
Imports System.Globalization
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Web.Services.Description
Partial Class ManageFinance
    Inherits System.Web.UI.Page
    Dim sCon1 = ConfigurationManager.ConnectionStrings("rasarscn").ToString()
    Dim oCon1 As New MySqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack = True) Then
            oCon1.ConnectionString = sCon1
            oCon1.Open()
            Dim custcmd As New MySqlCommand("Select Customer_Name From TBL_CustomerInformation", oCon1)
            dl_customer.DataSource = custcmd.ExecuteReader()
            dl_customer.DataValueField = "Customer_Name"
            dl_customer.DataBind()
            oCon1.Close()

        End If
    End Sub

    Protected Sub GO_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles GO.Click
        oCon1.ConnectionString = sCon1
        oCon1.Open()
        Dim finquery As New MySqlCommand("Select * from TBL_Finance where Customer_Name = '" & dl_customer.SelectedValue & "'", oCon1)
        Dim finadapt As New MySqlDataAdapter()
        finadapt.SelectCommand = finquery
        Dim findt As New DataTable()
        finadapt.Fill(findt)
        gr_custdata.DataSource = findt
        gr_custdata.DataBind()
        gr_custdata.Visible = True
        oCon1.Close()
    End Sub

    Protected Sub Modify(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim row As GridViewRow = CType(CType(sender, ImageButton).Parent.Parent, GridViewRow)
        lb_id.Text = gr_custdata.DataKeys(row.RowIndex).Value.ToString()
        tx_amount.Text = row.Cells(3).Text
        tx_advance.Text = row.Cells(4).Text
        tx_balance.Text = row.Cells(5).Text
        popup.Show()
    End Sub
    Protected Sub FinSave(ByVal sender As Object, ByVal e As EventArgs)
        Dim amt, rec, bal As Integer
        amt = tx_amount.Text
        rec = tx_advance.Text
        bal = amt - rec
        oCon1.ConnectionString = sCon1
        oCon1.Open()
        Dim finupd As New MySqlCommand("Update TBL_Finance Set Total_Amount=@Total_Amount, Balance=@Balance, Advance=@Advance where ID=@ID", oCon1)
        finupd.Parameters.AddWithValue("@Total_Amount", tx_amount.Text)
        finupd.Parameters.AddWithValue("@Balance", bal)
        finupd.Parameters.AddWithValue("@Advance", tx_advance.Text)
        finupd.Parameters.AddWithValue("@ID", lb_id.Text)
        finupd.ExecuteNonQuery()
        oCon1.Close()
        gr_custdata.DataBind()
        Response.Redirect("ManageFinance.aspx")
    End Sub
    Protected Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancel.Click
        popup.Hide()
    End Sub
End Class
