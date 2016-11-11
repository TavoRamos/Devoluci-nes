Imports System.Data.SqlClient

Public Class Cliente
    Public Property Id As Integer
    Public Property Codigo As ULong
    Public Property Nombre As String
    Private Sub New(ByRef codigo As ULong, ByRef nombre As String, ByRef CNSGestion As SqlClient.SqlConnection,)

    End Sub
    Public Shared Sub BuscarCliente(ByRef Codigo As ULong, ByRef ConexionDev As SqlConnection)

    End Sub
End Class
