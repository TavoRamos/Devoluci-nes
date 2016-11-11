Imports System.Data.SqlClient

Public Class ModeloDevoluciones
    Inherits Modelo
    Public Sub New()
        MyBase.New(My.Settings.CNSDevoluciones_Servidor, My.Settings.CNSDevoluciones_Instancia, My.Settings.CNSDevoluciones_BD, My.Settings.CNSDevoluciones_Usuario, My.Settings.CNSDevoluciones_Contrasenia)
    End Sub
    Public Function DevolucionesPendientes()
        Dim ConsultaCantidadDev As String = "SELECT COUNT(ID) FROM Devoluciones WHERE FechaAutorizacion IS NULL"
        Dim ConsultaCantidadGestion As String = ""
        Dim DT = New DataTable
        Try
            Dim CMD As New SqlCommand(Consulta, If(IsNothing(CNS), Conectar(), CNS))
            Dim DA = New SqlDataAdapter(CMD)
            DA.Fill(DT)
        Catch ex As SqlException
            MsgBox("ModeloGestion.ListaDevGestion" + vbCrLf + ex.Message)
            Return Nothing
        End Try
        Return DT
    End Function
    End Function
End Class
