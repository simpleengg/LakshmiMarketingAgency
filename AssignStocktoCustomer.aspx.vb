Imports System.IO
Imports System.Net.Mail
Imports System.Globalization
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Web.Services.Description
Partial Class AssignStocktoCustomer
    Inherits System.Web.UI.Page
    Dim sCon1 = ConfigurationManager.ConnectionStrings("rasarscn").ToString()
    Dim oCon1 As New MySqlConnection
    Dim finid As Integer
    Dim cname, cmob, canstring, finname, fcanid, amount, balance, advance As String
    Dim sadate, srdate, findate As DateTime '(Variables for stock assign & stock release dates)
    Dim cid As Integer
    'Dim updatedatasource As New SqlDataSource

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack = True) Then
            oCon1.ConnectionString = sCon1
            oCon1.Open()
            Dim selectcmd As New MySqlCommand("Select * from TBL_CustomerInformation", oCon1)
            Dim sda As New MySqlDataAdapter()
            sda.SelectCommand = selectcmd
            Dim dt As New DataTable()
            sda.Fill(dt)
            gr_assignstock.DataSource = dt
            gr_assignstock.DataBind()
            oCon1.Close()
        End If
       
    End Sub

    Protected Sub Assign(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim row As GridViewRow = CType(CType(sender, ImageButton).Parent.Parent, GridViewRow)
        lb_id.Text = gr_assignstock.DataKeys(row.RowIndex).Value.ToString()
        lcname.Text = row.Cells(0).Text
        lcmob.Text = row.Cells(1).Text
        tx_canid.Text = row.Cells(3).Text
        popup.Show()
    End Sub
    
    Protected Sub Save(ByVal sender As Object, ByVal e As EventArgs)
        oCon1.ConnectionString = sCon1
        Dim adate As DateTime = Convert.ToDateTime(tx_assigndate.Text).ToString("yyyy-MM-dd")
        Dim mysqladate As DateTime = adate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)

        'adate = adate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
        oCon1.Open()
        Dim updatecmd As New MySqlCommand("Update TBL_CustomerInformation SET Can_ID= '" & tx_canid.Text & "', Assign_Date= @Assign_Date, Release_Date=@Release_Date Where Customer_ID= '" & lb_id.Text & "'", oCon1)
        updatecmd.Parameters.AddWithValue("@Assign_Date", adate)
        updatecmd.Parameters.Add("@Release_Date", MySqlDbType.DateTime).Value = System.DBNull.Value
        updatecmd.ExecuteNonQuery()
        oCon1.Close()
        sadate = adate.ToString("yyyy-MM-dd")
        UpdateCanInfo()
        finid = lb_id.Text
        finname = lcname.Text
        fcanid = tx_canid.Text
        findate = adate
        InsertFinRecord()
        gr_assignstock.DataBind()
        Response.Redirect("AssignStocktoCustomer.aspx")
    End Sub

    Public Sub InsertFinRecord()
        oCon1.ConnectionString = sCon1
        oCon1.Open()
        Dim fincmd As New MySqlCommand("Insert into TBL_Finance (Customer_ID, Customer_Name, Can_ID, Assign_Date) Values ('" & finid & "', '" & finname & "', '" & fcanid & "',@Assign_Date)", oCon1)
        fincmd.Parameters.AddWithValue("@Assign_Date", findate)
        fincmd.ExecuteNonQuery()
        oCon1.Close()
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        popup.Hide()
    End Sub

    Public Sub UpdateCanInfo()

        Dim canid_parts As String() = tx_canid.Text.Split(New Char() {","c})
        Dim i As Integer
        Dim orgcanstatus As String = "InStock"
        Dim canstatus As String = "Assigned"
        Dim assigncanid As String

        For i = 0 To canid_parts.Length - 1
            assigncanid = canid_parts(i)

            oCon1.Open()

            Dim assigncmd As New MySqlCommand("Update TBL_CanInfo Set Customer_Name=@Customer_Name, Customer_Mobile=@Customer_Mobile, Can_Status=@Can_Status, Assign_Date=@Assign_Date, Log_Date=@Log_Date, Release_Date=@Release_Date Where Can_ID=@Can_ID AND Can_Status='" & orgcanstatus & "'", oCon1)
            assigncmd.Parameters.AddWithValue("@Can_ID", assigncanid)
            assigncmd.Parameters.AddWithValue("@Customer_Name", lcname.Text)
            assigncmd.Parameters.AddWithValue("@Customer_Mobile", lcmob.Text)
            assigncmd.Parameters.AddWithValue("@Can_Status", canstatus)
            assigncmd.Parameters.AddWithValue("@Assign_Date", sadate)
            assigncmd.Parameters.AddWithValue("@Log_Date", sadate)
            assigncmd.Parameters.Add("@Release_Date", MySqlDbType.DateTime).Value = System.DBNull.Value
            assigncmd.ExecuteNonQuery()
            oCon1.Close()
        Next
    End Sub

    

    Protected Sub btnRelease_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRelease.Click
        oCon1.ConnectionString = sCon1
        Dim rdate As DateTime = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
        canstring = tx_canid.Text
        oCon1.Open()
        Dim updatecmd As New MySqlCommand("Update TBL_CustomerInformation SET Can_ID= '" & tx_canid.Text & "', Release_Date= @Release_Date Where Customer_ID= '" & lb_id.Text & "'", oCon1)
        updatecmd.Parameters.AddWithValue("@Release_Date", rdate)
        updatecmd.ExecuteNonQuery()
        oCon1.Close()
        srdate = rdate
        ReleaseCanInfo()
        tx_canid.Text = String.Empty
        gr_assignstock.DataBind()
        Response.Redirect("AssignStocktoCustomer.aspx")
    End Sub

    Public Sub ReleaseCanInfo()
        Dim relcanid_parts As String() = tx_canid.Text.Split(New Char() {","c})
        Dim j As Integer
        Dim relcanstatus As String = "Released"
        Dim inicanstatus As String = "Assigned"
        Dim releasecanid As String
        For j = 0 To relcanid_parts.Length - 1
            releasecanid = relcanid_parts(j)

            oCon1.Open()
            Dim relcmd As New MySqlCommand("Update TBL_CanInfo Set Can_Status=@Can_Status, Release_Date=@Release_Date, Log_Date=@Log_Date Where Can_ID=@Can_ID AND Can_Status='" & inicanstatus & "'", oCon1)
            relcmd.Parameters.AddWithValue("@Can_ID", releasecanid)
            relcmd.Parameters.AddWithValue("@Can_Status", relcanstatus)
            relcmd.Parameters.AddWithValue("@Release_Date", srdate)
            relcmd.Parameters.AddWithValue("@Log_Date", srdate)
            relcmd.ExecuteNonQuery()
            oCon1.Close()
        Next
    End Sub
End Class
