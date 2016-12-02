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
#Region "BUSCAR Y OBTENER"
    Public Function BuscarArticulo(ByRef Codigo As String, ByRef Optional ID As Integer = Nothing) As ArticuloGenerico
        Dim RESULTADO As ArticuloGenerico
        Try
            Dim CMD As New SqlCommand("SP_BuscarArticulo", CNS)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@Codigo", SqlDbType.VarChar, 50).Value = Codigo
            CMD.Parameters.Add("@ID", SqlDbType.Int).Value = ID
            Dim Lector As SqlDataReader
            CNS.Open()
            Lector = CMD.ExecuteReader()
            If Lector.HasRows Then
                RESULTADO = New ArticuloGenerico(Lector(0), Lector(2), Lector(1), Lector(3), Lector(4), Lector(5), Lector(6))
            Else
                RESULTADO = Nothing
            End If
            CNS.Close()
        Catch ex As Exception
            MsgBox("ModeloDevoluciones.BuscarArticulo" + vbCrLf + ex.Message)
            CNS.Close()
            Return Nothing
        End Try
        Return RESULTADO
    End Function
    Public Function BuscarAlternativa(ByRef Codigo As String, ByRef Optional ID As Integer = Nothing) As Alternativa
        Dim RESULTADO As Alternativa
        Try
            Dim CMD As New SqlCommand("SP_BuscarAlternativa", CNS)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@Codigo", SqlDbType.VarChar, 50).Value = Codigo
            CMD.Parameters.Add("@ID", SqlDbType.Int).Value = ID
            Dim Lector As SqlDataReader
            CNS.Open()
            Lector = CMD.ExecuteReader()
            If Lector.HasRows Then
                RESULTADO = New Alternativa(Lector(0), Lector(1), Lector(2), Lector(3), Lector(4))
            Else
                RESULTADO = Nothing
            End If
            CNS.Close()
        Catch ex As Exception
            MsgBox("ModeloDevoluciones.BuscarAlternativa" + vbCrLf + ex.Message)
            CNS.Close()
            Return Nothing
        End Try
        Return RESULTADO
    End Function
    Public Function BuscarTalle(ByRef Codigo As String, ByRef Optional ID As Integer = Nothing) As Talle
        Dim RESULTADO As Talle
        Try
            Dim CMD As New SqlCommand("SP_BuscarTalle", CNS)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@Codigo", SqlDbType.VarChar, 50).Value = Codigo
            CMD.Parameters.Add("@ID", SqlDbType.Int).Value = ID
            Dim Lector As SqlDataReader
            CNS.Open()
            Lector = CMD.ExecuteReader()
            If Lector.HasRows Then
                'CodigoLince,CodigoDragon,CodigoGestion,CodigoHexagono,ID,Descripcion
                RESULTADO = New Talle(Lector(5), Lector(0), Lector(1), Lector(2), Lector(3), Lector(4))
            Else
                RESULTADO = Nothing
            End If
            CNS.Close()
        Catch ex As Exception
            MsgBox("ModeloDevoluciones.BuscarTalle" + vbCrLf + ex.Message)
            CNS.Close()
            Return Nothing
        End Try
        Return RESULTADO
    End Function
#End Region
End Class
