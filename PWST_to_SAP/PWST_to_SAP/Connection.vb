Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data.SqlClient
Public Class Connection

    Public Shared Function ObtenerConexion() As SqlConnection
        Dim connectionString As String = "Data Source=127.0.0.1;" + "Initial Catalog=istmaniaPWST;" + "User id=sa;" + "Password=12345;"
        Dim con As SqlConnection = New SqlConnection(connectionString)
        con.Open()
        Return con
    End Function

End Class