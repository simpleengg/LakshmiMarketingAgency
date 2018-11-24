Imports System.IO
Imports System.Net.Mail
Imports System.Globalization
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Web.Services.Description

Partial Class AddNewCustomer
    Inherits System.Web.UI.Page
    Dim sCon1 = ConfigurationManager.ConnectionStrings("rasarscn").ToString()
    Dim oCon1 As MySqlConnection = New MySqlConnection




    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        oCon1.ConnectionString = sCon1
        oCon1.Open()
        Dim custinsertcommand As New MySqlCommand("INSERT INTO TBL_CustomerInformation (Customer_Name, Customer_Address, Customer_Mobile, Customer_Landline, Customer_City, Customer_State, Customer_Pincode, Customer_Landmark) VALUES ('" + tx_customername.Text + "', '" + tx_address.Text + "', '" + tx_mobile.Text + "', '" + tx_landline.Text + "', '" + tx_city.Text + "', '', '', '" + tx_landmark.Text + "')", oCon1)
        Try
            custinsertcommand.ExecuteNonQuery()

            lb_success.Visible = True
            lb_failure.Visible = False
        Catch ex As Exception

            lb_success.Visible = False
            lb_failure.Visible = True
        End Try
        oCon1.Close()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lb_success.Visible = False
        lb_failure.Visible = False
    End Sub
End Class
