Imports MySql.Data.MySqlClient

Public Class DBConnection
    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=dbpupclinic")
    Public Function open() As MySqlConnection
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return connection
    End Function
    Public Function close() As MySqlConnection
        Try
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return connection
    End Function
End Class