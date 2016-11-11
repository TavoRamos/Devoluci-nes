Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class Modelo
    Public Property Servidor As String
    Public Property Instancia As String
    Public Property BD As String
    Public Property Usuario As String
    Public Property Contrasenia As String
    Dim CNS As SqlConnection

    Protected Friend Sub New(ByRef servidor As String, ByRef instancia As String, ByRef bd As String, ByRef usuario As String, ByRef contrasenia As String)
        Me.Servidor = servidor
        Me.Instancia = instancia
        Me.BD = bd
        Me.Usuario = usuario
        Me.Contrasenia = contrasenia
    End Sub
    Public Function Conectar() As SqlConnection
        Dim Conn = New SqlConnection("Server =" + Servidor + "\" + Instancia + ";Database=" + BD + ";User Id=" + Usuario + ";Password =" + Contrasenia + ";")
        Try
            Conn.Open()
        Catch ex As SqlException
            MsgBox("Modelo.Conectar" + vbCrLf + ex.Message)
            Return Nothing
        End Try
        CNS = Conn
        Return CNS
    End Function
End Class
