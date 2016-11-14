Imports System.Data.SqlClient

Public Class ModeloDevoluciones
    Inherits ModeloSQL
    Public Sub New()
        MyBase.New(My.Settings.CNSDevoluciones_Servidor, My.Settings.CNSDevoluciones_Instancia, My.Settings.CNSDevoluciones_BD, My.Settings.CNSDevoluciones_Usuario, My.Settings.CNSDevoluciones_Contrasenia)
    End Sub
    Public Function DevolucionesPendientes() As UInteger
        Dim R1 As Integer
        Dim ConsultaCantidadDev As String = "SELECT COUNT(ID) FROM Devoluciones WHERE FechaAutorizacion IS NULL"

        Try
            Dim CMD1 As New SqlCommand(ConsultaCantidadDev, CNS)
            CNS.Open()
            R1 = CMD1.ExecuteNonQuery
            CNS.Close()
        Catch ex As SqlException
            MsgBox("ModeloDevoluciones.DevolucionesPendientes" + vbCrLf + ex.Message)
            Return Nothing
        End Try
        Return If(R1 = -1, 0, R1)
    End Function
End Class
