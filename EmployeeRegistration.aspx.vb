Imports System.Data.SqlClient
Public Class EmployeeRegistration
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblErr.Visible = False
        lblSucess.Visible = False
        btnUpdate.Visible = False


        If Not IsPostBack Then
            Dim con As SqlConnection
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader


            Try
                con = New SqlConnection("Data Source=GUNA;Initial Catalog=dbase;Integrated Security=True")

                con.Open()

                cmd = New SqlCommand

                cmd.CommandText = "Gender"

                cmd.CommandType = CommandType.StoredProcedure

                cmd.Connection = con

                dr = cmd.ExecuteReader()

                Dim li = New ListItem
                While dr.Read()

                    li = New ListItem

                    li.Value = dr("GenderId")
                    li.Text = dr("Gender")

                    rdGender.Items.Add(li)

                    li = Nothing

                End While



            Catch ex As Exception

                lblErr.Visible = True
                lblErr.Text = ex.Message

            End Try


        End If

        If Request("Mode") = "D" Then
            Delete(Request("EmpId"))
        End If


        If Request("Mode") = "E" And Request("btnUpdate") = "" Then
            btnSubmit.Visible = False
            btnUpdate.Visible = True

            Dim con As SqlConnection
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader


            Try
                con = New SqlConnection("Data Source=GUNA;Initial Catalog=dbase;Integrated Security=True")

                con.Open()

                cmd = New SqlCommand

                cmd.CommandText = "EmployeeDetails"

                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("EmpId", Request("EmpId"))

                cmd.Connection = con

                dr = cmd.ExecuteReader()

                If dr.Read() Then

                    txtEmpName.Text = dr("EmployeeName")

                    rdGender.SelectedValue = dr("Gender")

                    drpQual.SelectedValue = dr("Qualification")

                End If



            Catch ex As Exception

                lblErr.Visible = True
                lblErr.Text = ex.Message

            End Try




        End If



    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click


        Dim con As SqlConnection
        Dim cmd As SqlCommand


        Try
            con = New SqlConnection("Data Source=GUNA;Initial Catalog=dbase;Integrated Security=True")

            con.Open()

            cmd = New SqlCommand

            cmd.CommandText = "EmployeeAdd"

            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@EmployeeName", Request("txtEmpName"))
            cmd.Parameters.AddWithValue("@Gender", Request("rdGender"))
            cmd.Parameters.AddWithValue("@Qualification", Request("drpQual"))
            cmd.Parameters.AddWithValue("@Terms", Request("chAgree"))

            cmd.Connection = con

            cmd.ExecuteNonQuery()

            con.Close()
            cmd.Dispose()

            lblSucess.Visible = True
            lblSucess.Text = "Employee Registration Sucessfully done..!"


        Catch ex As Exception

            lblErr.Visible = True
            lblErr.Text = ex.Message

        End Try




    End Sub

    Private Sub Delete(ByVal EmpID As Integer)

        Dim con As SqlConnection
        Dim cmd As SqlCommand


        Try
            con = New SqlConnection("Data Source=GUNA;Initial Catalog=dbase;Integrated Security=True")

            con.Open()

            cmd = New SqlCommand

            cmd.CommandText = "EmployeeDelete"

            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@EmpId", Request("EmpId"))


            cmd.Connection = con

            cmd.ExecuteNonQuery()

            con.Close()
            cmd.Dispose()

            lblSucess.Visible = True
            lblSucess.Text = "Employee Records deleted Sucessfully..!"


        Catch ex As Exception

            lblErr.Visible = True
            lblErr.Text = ex.Message

        End Try



    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click


        Dim con As SqlConnection
        Dim cmd As SqlCommand


        Try
            con = New SqlConnection("Data Source=GUNA;Initial Catalog=dbase;Integrated Security=True")

            con.Open()

            cmd = New SqlCommand

            cmd.CommandText = "EmployeeUpdate"

            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@EmpId", Request("EmpId"))
            cmd.Parameters.AddWithValue("@EmployeeName", Request("txtEmpName"))
            cmd.Parameters.AddWithValue("@Gender", Request("rdGender"))
            cmd.Parameters.AddWithValue("@Qualification", Request("drpQual"))
            cmd.Parameters.AddWithValue("@Terms", Request("chAgree"))

            cmd.Connection = con

            cmd.ExecuteNonQuery()

            con.Close()
            cmd.Dispose()


            lblSucess.Visible = True

            lblSucess.Text = "Employee Records Updated Sucessfully"


        Catch ex As Exception

            lblErr.Visible = True
            lblErr.Text = ex.Message

        End Try




    End Sub
End Class
