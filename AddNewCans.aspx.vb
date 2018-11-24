Imports System.IO
Imports System.Net.Mail
Imports System.Globalization
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Web.Services.Description
Partial Class AddNewCans
    Inherits System.Web.UI.Page
    Dim sCon1 = ConfigurationManager.ConnectionStrings("rasarscn").ToString()
    Dim oCon1 As MySqlConnection = New MySqlConnection
    Dim logdate As DateTime
    Dim logcdate As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        oCon1.ConnectionString = sCon1
        oCon1.Open()
        Dim cantypecommand As New MySqlCommand("SELECT Can_Type FROM TBL_CanType", oCon1)
        Dim canreader As MySqlDataReader = cantypecommand.ExecuteReader
        While canreader.Read()
            Dim cantype As String = canreader.GetString(0)
            dl_cantype.Items.Add(cantype)

            ' cmb_cantype.ItemsSource = canreader("Can_Type")

        End While
        oCon1.Close()

        oCon1.Open()

        Dim cansizecommand As New MySqlCommand("SELECT Can_Size FROM TBL_CanSize", oCon1)
        Dim sizereader As MySqlDataReader = cansizecommand.ExecuteReader
        While sizereader.Read()
            Dim cansize As String = sizereader.GetString(0)
            dl_cansize.Items.Add(cansize)
        End While

        oCon1.Close()

        logdate = DateTime.Now
        logcdate = logdate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)
        lb_success.Visible = False
    End Sub

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click

        
        If dl_ptype.Text = "NewCan" Then

            AddNewInventory()


        ElseIf dl_ptype.Text = "Refill" Then

            UpdateInventory()

        End If
        lb_success.Visible = True
    End Sub

    Public Sub AddNewInventory()
        Dim pdate As DateTime = Convert.ToDateTime(tx_date.Text).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
        'Dim mysqladate As DateTime = pdate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
        oCon1.Open()
        Dim reqcanid As String
        Dim reqcmd As New MySqlCommand("Select Max(Cast(Can_ID as UNSIGNED)) as value From TBL_CanInfo", oCon1)
        Dim reqreader As MySqlDataReader = reqcmd.ExecuteReader
        While reqreader.Read()
            reqcanid = reqreader.GetString(0)
        End While
        oCon1.Close()
        oCon1.Open()
        Dim lastcanid As String
        Dim lastcancommand As New MySqlCommand("SELECT Can_ID FROM TBL_CanInfo WHERE Can_ID='" & reqcanid & "'", oCon1)
        Dim lastcanreader As MySqlDataReader = lastcancommand.ExecuteReader

        While lastcanreader.Read()
            lastcanid = lastcanreader.GetString(0)
        End While

        oCon1.Close()

        Dim count As String = tx_cannumber.Text

        Dim i, j As Integer
        Dim canstatus As String = "InStock"
        j = 0
        Dim canid As String
        For i = 1 To count
            j = j + 1
            canid = j + lastcanid
            oCon1.Open()
            Dim insertnewcancommand As New MySqlCommand("INSERT INTO TBL_CanInfo (Can_ID, Can_Type, Can_Status, Can_Size, Procurement_Date, Procurement_Type, Stock_Date, Log_Date) VALUES ('" + canid + "', '" + dl_cantype.Text + "', '" + canstatus + "', '" + dl_cansize.Text + "', @Procurement_Date, '" + dl_ptype.Text + "', @Stock_Date, @Log_Date)", oCon1)
            insertnewcancommand.Parameters.AddWithValue("@Procurement_Date", pdate)
            insertnewcancommand.Parameters.AddWithValue("@Stock_Date", pdate)
            insertnewcancommand.Parameters.AddWithValue("@Log_Date", pdate)
            insertnewcancommand.ExecuteNonQuery()

            oCon1.Close()

        Next

    End Sub

    Public Sub UpdateInventory()
        Dim rdate As DateTime = Convert.ToDateTime(tx_date.Text).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
        'Dim mysqladate As DateTime = adate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
        Dim canid_parts As String() = tx_cannumber.Text.Split(New Char() {","c})

        Dim i As Integer

        Dim refillstatus As String = "InStock"
        Dim closestatus As String = "Closed"
        Dim refillcanid As String

        For i = 0 To canid_parts.Length - 1

            ocon1.Open()

            refillcanid = canid_parts(i)

            Dim closecommand As New MySqlCommand("Update TBL_CanInfo Set Can_Status='" + closestatus + "' where Can_ID= '" + refillcanid + "'", oCon1)
            closecommand.ExecuteNonQuery()

            Dim refillcommand As New MySqlCommand("INSERT INTO TBL_CanInfo (Can_ID, Can_Type, Can_Status, Can_Size, Procurement_Type, Stock_Date, Log_Date) VALUES ('" + refillcanid + "', '" + dl_cantype.Text + "', '" + refillstatus + "', '" + dl_cansize.Text + "', '" + dl_ptype.Text + "', @Stock_Date, @Log_Date)", oCon1)
            refillcommand.Parameters.AddWithValue("@Stock_Date", rdate)
            refillcommand.Parameters.AddWithValue("@Log_Date", rdate)
            refillcommand.ExecuteNonQuery()

            ocon1.Close()

        Next

    End Sub
End Class
