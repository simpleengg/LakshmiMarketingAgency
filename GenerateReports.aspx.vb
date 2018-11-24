Imports System.IO
Imports System.Net.Mail
Imports System.Globalization
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Web.Services.Description
Partial Class GenerateReports
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
            oCon1.Open()
            Dim cancmd As New MySqlCommand("Select Distinct(Can_ID) From TBL_CanInfo", oCon1)
            dl_cid.DataSource = cancmd.ExecuteReader()
            dl_cid.DataValueField = "Can_ID"
            dl_cid.DataBind()
            oCon1.Close()
            
        End If
    End Sub

    Protected Sub btn_report_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_report.Click
        If dl_reportytype.SelectedValue = "Can Validity" Then
            oCon1.ConnectionString = sCon1
            Dim canstatus As String = "Closed"
            oCon1.Open()
            Dim canvalcmd As New MySqlCommand("Select Can_ID, Count(Can_ID) from TBL_CanInfo where Can_Status='" & canstatus & "' GROUP By Can_ID Order By Count(Can_ID) Desc", oCon1)
            Dim canval As New MySqlDataAdapter()
            canval.SelectCommand = canvalcmd
            Dim canvaldt As New DataTable()
            canval.Fill(canvaldt)
            gr_reports.DataSource = canvaldt
            gr_reports.DataBind()
            gr_reports.Visible = True
            gr_custdata.Visible = False
            lb_useddata.Visible = False
            oCon1.Close()
        ElseIf dl_reportytype.SelectedValue = "Customer Report - Monthly" Then
            oCon1.ConnectionString = sCon1
            oCon1.Open()
            Dim custname As String = dl_customer.SelectedValue
            Dim custcmd As New MySqlCommand("Select * from TBL_CanInfo where Customer_Name='" & custname & "' Order by Assign_Date", oCon1)
            Dim custadp As New MySqlDataAdapter()
            custadp.SelectCommand = custcmd
            Dim custdt As New DataTable()
            custadp.Fill(custdt)
            gr_custdata.DataSource = custdt
            gr_custdata.DataBind()
            gr_reports.Visible = False
            gr_custdata.Visible = True
            lb_useddata.Visible = False
            oCon1.Close()
        ElseIf dl_reportytype.SelectedValue = "Previous Used Data" Then
            oCon1.ConnectionString = sCon1
            oCon1.Open()
            Dim cid As String = dl_cid.Text
            Dim cstatus As String = "Assigned"
            Dim datacmd As New MySqlCommand("Select Customer_Name from TBL_CanInfo where Can_Status='" & cstatus & "' And Can_ID='" & cid & "'", oCon1)
            Dim datareader As MySqlDataReader = datacmd.ExecuteReader()
            While datareader.Read()

                lb_useddata.Text = "This can was last assigned to" & " " & datareader.GetString(0)
                lb_useddata.Visible = True
                gr_reports.Visible = False
                gr_custdata.Visible = False
                oCon1.Close()
                Exit Sub
            End While
            lb_useddata.Text = "This can has not been assigned to any customer yet"
            lb_useddata.Visible = True
            gr_reports.Visible = False
            gr_custdata.Visible = False
            oCon1.Close()
        End If
    End Sub

    Protected Sub dl_reportytype_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles dl_reportytype.Init
        If dl_reportytype.SelectedValue = "Customer Report - Monthly" Then
            lb_month.Visible = True
            dl_month.Visible = True
            dl_year.Visible = True
            lb_customer.Visible = True
            dl_customer.Visible = True
            lb_cid.Visible = False
            dl_cid.Visible = False
        ElseIf dl_reportytype.SelectedValue = "Previous Used Data" Then
            lb_month.Visible = False
            dl_month.Visible = False
            dl_year.Visible = False
            lb_customer.Visible = False
            dl_customer.Visible = False
            lb_cid.Visible = True
            dl_cid.Visible = True
        Else
            lb_month.Visible = False
            dl_month.Visible = False
            dl_year.Visible = False
            lb_customer.Visible = False
            dl_customer.Visible = False
            lb_cid.Visible = False
            dl_cid.Visible = False
        End If
    End Sub

    Protected Sub dl_reportytype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dl_reportytype.SelectedIndexChanged
        If dl_reportytype.SelectedValue = "Customer Report - Monthly" Then
            lb_month.Visible = True
            dl_month.Visible = True
            dl_year.Visible = True
            lb_customer.Visible = True
            dl_customer.Visible = True
        ElseIf dl_reportytype.SelectedValue = "Previous Used Data" Then
            lb_month.Visible = False
            dl_month.Visible = False
            dl_year.Visible = False
            lb_customer.Visible = False
            dl_customer.Visible = False
            lb_cid.Visible = True
            dl_cid.Visible = True
        Else
            lb_month.Visible = False
            dl_month.Visible = False
            dl_year.Visible = False
            lb_customer.Visible = False
            dl_customer.Visible = False
            lb_cid.Visible = False
            dl_cid.Visible = False
        End If
    End Sub

    Protected Sub img_choose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_choose.Click
        If dl_reportytype.SelectedValue = "Previous Used Data" Then
            lb_cid.Visible = True
            dl_cid.Visible = True
            gr_reports.Visible = False
            gr_custdata.Visible = False
            lb_useddata.Visible = False
        ElseIf dl_reportytype.SelectedValue = "Can Validity" Then
            gr_reports.Visible = False
            gr_custdata.Visible = False
            lb_useddata.Visible = True
            lb_cid.Visible = False
            dl_cid.Visible = False
            lb_useddata.Text = "Click on Generate to view results after providing valid inputs"
        ElseIf dl_reportytype.SelectedValue = "Customer Report - Monthly" Then
            gr_reports.Visible = False
            gr_custdata.Visible = False
            lb_useddata.Visible = True
            lb_cid.Visible = False
            dl_cid.Visible = False
            lb_useddata.Text = "Click on Generate to view results after providing valid inputs"
        End If
    End Sub
End Class
