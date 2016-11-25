Imports System.Data.SqlClient

Public Class Sucursal
    Public Property Id As Integer
    Public Property CodigoGestion As ULong
    Public Property CodigoLince As String
    Public Property CodigoDragon As String
    Public Property TieneLince As Boolean
    Public Property Tipo As Integer
    Public Property Nombre As String
    Public Sub New(ByRef codigo_gestion As ULong, ByRef ConDevoluciones As ModeloDevoluciones)
        Dim CMD As New SqlCommand("SELECT * FROM Sucursales WHERE CodigoGestion=" & codigo_gestion, ConDevoluciones.CNS)
        Dim Lector As SqlDataReader
        Try
            ConDevoluciones.CNS.Open()
            Lector = CMD.ExecuteReader
            While Lector.Read
                Id = Lector(0)
                CodigoGestion = Lector(1)
                CodigoLince = Lector(2)
                CodigoDragon = Lector(3)
                Nombre = Lector(4)
                TieneLince = Lector(5)
                Tipo = Lector(6)
            End While
            Lector.Close()
            ConDevoluciones.CNS.Close()
        Catch ex As SqlException
            MsgBox("Sucursal.New" & vbCrLf & ex.Message)
        End Try
    End Sub
End Class
