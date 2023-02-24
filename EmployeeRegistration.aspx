<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EmployeeRegistration.aspx.vb" Inherits="Dec08.EmployeeRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Registration</title>
</head>
<body>
    <form id="form1" runat="server">
        <h4>Employee Registration</h4>
        
        <table>
            <tr>
                <td>Employee Name</td>
                <td><asp:TextBox ID="txtEmpName" runat ="server" ></asp:TextBox></td>
            </tr>

            <tr>
                <td valign="top">Gender</td>
                <td><asp:RadioButtonList ID="rdGender" runat ="server" ></asp:RadioButtonList></td>
            </tr>
            <tr>
                <td>Qualification</td>
                <td><asp:DropDownList ID="drpQual" runat ="server" >

                    <asp:ListItem Value ="">---Select---</asp:ListItem>
                    <asp:ListItem Value ="B.E">B.E</asp:ListItem>
                    <asp:ListItem Value ="M.E">M.E</asp:ListItem>
                    <asp:ListItem Value ="BCA">BCA</asp:ListItem>
                    <asp:ListItem Value ="MCA">MCA</asp:ListItem>
                    </asp:DropDownList></td>

            </tr>



            
            <tr><td>
                <asp:CheckBox ID ="chAgree" runat ="server"  />
                </td>
                <td>Agree the terms and conditions</td>

            </tr>


               <tr>
               <td colspan ="2" align="right">
                     <asp:Button ID ="btnSubmit" runat ="server"  Text ="Submit"/>
                  <asp:Button ID ="btnUpdate" runat ="server"  Text ="Update"/>


               </td>
            </tr>





        </table>

        <asp:Label ID="lblErr" runat ="server" ForeColor ="red" Font-Size ="Large"></asp:Label>
        <asp:Label ID="lblSucess" runat ="server" ForeColor ="Green" Font-Size ="Large"></asp:Label>




        <h4>Employee Details</h4>
        
          <%Dim con As System.Data.SqlClient.SqlConnection
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim dr As System.Data.SqlClient.SqlDataReader


            Try
                con = New System.Data.SqlClient.SqlConnection("Data Source=GUNA;Initial Catalog=dbase;Integrated Security=True")

                con.Open()

                cmd = New System.Data.SqlClient.SqlCommand

                cmd.CommandText = "EmployeeList"

                cmd.CommandType = System.Data.CommandType.StoredProcedure

                cmd.Connection = con

                dr = cmd.ExecuteReader()

                %>
        <table border="1" >

            <tr>
                <td>EmployeeName</td>
                <td>Gender</td>
                <td>Qualification</td>
                <td>Terms and Condition</td>
                <td>Action</td>

            </tr>
       



            <%
                    While dr.Read()
                        %>
            <tr>
                <td><%=dr("EmployeeName")%></td>
                <td><%=dr("Gender")%></td>
                <td><%=dr("Qualification")%></td>
                <td><%=dr("Terms")%></td>
                <td>
                    <a href ="EmployeeRegistration.aspx?Mode=E&EmpId=<%=dr("EmpId")%>" >Edit</a>
                    <a href ="EmployeeRegistration.aspx?Mode=D&EmpId=<%=dr("EmpId")%>" onclick="return confirm('Are you sure want to delete ?')" >Delete</a>

                </td>


            </tr>
         <% End While %>   
                   </table>


            <%






                Catch ex As Exception

                   %>

            <span><%=ex.Message%></span>

            <%

                End Try %>


    </form>
</body>
</html>

