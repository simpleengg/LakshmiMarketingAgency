Imports System.IO
Imports System.Net.Mail
Imports System.Globalization
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Web.Services.Description
Partial Class CanInventory
    Inherits System.Web.UI.Page
    Dim sCon1 = ConfigurationManager.ConnectionStrings("rasarscn").ToString()
    Dim oCon1 As MySqlConnection = New MySqlConnection
    Dim allcans As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack = True) Then
            oCon1.ConnectionString = sCon1
            oCon1.Open()
            Dim stockstatus As String = "InStock"
            Dim assgnstatus As String = "Assigned"

            Dim selectcmd As New MySqlCommand("Select count(DISTINCT(Can_ID)) from TBL_CanInfo", oCon1)
            lb_total.Text = selectcmd.ExecuteScalar()
            Dim stockcmd As New MySqlCommand("Select count(Can_ID) from TBL_CanInfo where Can_Status='" & stockstatus & "'", oCon1)
            lb_stock.Text = stockcmd.ExecuteScalar()
            Dim assgncmd As New MySqlCommand("Select count(Can_ID) from TBL_CanInfo where Can_Status='" & assgnstatus & "'", oCon1)
            lb_assigned.Text = assgncmd.ExecuteScalar

            lb_released.Text = (CDbl(lb_total.Text) - CDbl(lb_assigned.Text) - CDbl(lb_stock.Text)).ToString()
        End If
        btn_total.BackColor = Drawing.Color.Transparent
        btn_total.ForeColor = Drawing.Color.White
        btn_stock.BackColor = Drawing.Color.Transparent
        btn_stock.ForeColor = Drawing.Color.White
        btn_assigned.BackColor = Drawing.Color.Transparent
        btn_assigned.ForeColor = Drawing.Color.White
        btn_released.BackColor = Drawing.Color.Transparent
        btn_released.ForeColor = Drawing.Color.White
    End Sub

    Protected Sub btn_assigned_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_assigned.Click
        gr_dispdata.DataBind()

        oCon1.ConnectionString = sCon1
        Dim asstatus As String = "Assigned"
        oCon1.Open()
        Dim assgncmd As New MySqlCommand("Select * from TBL_CanInfo where Can_Status='" & asstatus & "'", oCon1)
        Dim asda As New MySqlDataAdapter()
        asda.SelectCommand = assgncmd
        Dim asdt As New DataTable()
        asda.Fill(asdt)
        gr_dispdata.DataSource = asdt
        gr_dispdata.DataBind()
        oCon1.Close()

    End Sub

    Protected Sub btn_total_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_total.Click
        gr_dispdata.DataBind()

        oCon1.ConnectionString = sCon1
        oCon1.Open()
        Dim totalcmd As New MySqlCommand("Select * from TBL_CanInfo Group by Can_ID order by Can_ID Asc", oCon1)
        Dim tda As New MySqlDataAdapter()
        tda.SelectCommand = totalcmd
        Dim tdt As New DataTable()
        tda.Fill(tdt)
        gr_dispdata.DataSource = tdt
        gr_dispdata.DataBind()
        oCon1.Close()
    End Sub

    Protected Sub btn_stock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_stock.Click
        gr_dispdata.DataBind()

        oCon1.ConnectionString = sCon1
        Dim osstatus As String = "InStock"
        oCon1.Open()
        Dim stockcmd As New MySqlCommand("Select * from TBL_CanInfo where Can_Status='" & osstatus & "'", oCon1)
        Dim osda As New MySqlDataAdapter()
        osda.SelectCommand = stockcmd
        Dim osdt As New DataTable()
        osda.Fill(osdt)
        gr_dispdata.DataSource = osdt
        gr_dispdata.DataBind()
        oCon1.Close()

    End Sub

    Protected Sub btn_released_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_released.Click
        gr_dispdata.DataBind()

        oCon1.ConnectionString = sCon1
        Dim rsstatus As String = "Released"
        oCon1.Open()
        Dim relgncmd As New MySqlCommand("Select * from TBL_CanInfo where Can_Status='" & rsstatus & "'Group by Can_ID order by Can_ID Asc", oCon1)
        Dim rsda As New MySqlDataAdapter()
        rsda.SelectCommand = relgncmd
        Dim rsdt As New DataTable()
        rsda.Fill(rsdt)
        gr_dispdata.DataSource = rsdt
        gr_dispdata.DataBind()
        oCon1.Close()
    End Sub
End Class
