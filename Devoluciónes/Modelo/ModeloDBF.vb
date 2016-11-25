Imports System.Data.Odbc

Public Class ModeloDBF
    Public CNS As OdbcConnection
    Protected Friend Property Ubicacion As String
    Protected Friend Property NombreDB As String

    Public Sub New(ByRef ubicacion As String, ByRef nombre_db As String)
        Dim a = New OdbcConnection("Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" & ubicacion & ";")
        Try
            a.Open()
            a.Close()
        Catch ex As Exception
            MsgBox("ERROR AL CONECTAR DB" + vbCrLf + ex.Message)
            CNS = Nothing
            NombreDB = Nothing
            a.Close()
            Return
        End Try
        CNS = a
        CNS.ConnectionString = a.ConnectionString
        NombreDB = nombre_db
    End Sub
    Public Sub New(ByRef ubicacion As String)
        Dim a As New OdbcConnection("Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" &
                ubicacion & ";")
        Try
            a.Open()
            a.Close()
        Catch ex As Exception
            MsgBox("Error AL CONECTAR DB" + vbCrLf + ex.Message)
            CNS = Nothing
            NombreDB = Nothing
            a.Close()
            Return
        End Try
        CNS = a
        NombreDB = Nothing
    End Sub
    Public Function buscarArticulo(ByRef cod_art As String, ByRef Optional nomBD As String = Nothing) As Boolean
        Dim da
        If Not String.IsNullOrWhiteSpace(nomBD) Then
            da = New System.Data.Odbc.OdbcDataAdapter("Select * FROM  " & nomBD & " WHERE artcod = '" & cod_art & "'", CNS)
        Else
            da = New System.Data.Odbc.OdbcDataAdapter("Select * FROM  " & NombreDB & " WHERE artcod = '" & cod_art & "'", CNS)
        End If
        Dim dt As New DataTable
        Try
            CNS.Open()
            da.Fill(dt)
            CNS.Close()
        Catch ex As Exception
            MessageBox.Show("Error al abrir la base de datos" & vbCrLf & ex.Message)
        End Try
        If dt.Rows.Count = 1 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ObtenerArticulo(ByRef cod_art As String, ByRef Optional nomBD As String = Nothing) As DataTable
        Dim da
        If Not String.IsNullOrWhiteSpace(nomBD) Then
            da = New System.Data.Odbc.OdbcDataAdapter("Select * FROM  " & nomBD & " WHERE artcod = '" & cod_art & "'", CNS)
        Else
            da = New System.Data.Odbc.OdbcDataAdapter("Select * FROM  " & NombreDB & " WHERE artcod = '" & cod_art & "'", CNS)
        End If
        Dim dt As New DataTable
        Try
            CNS.Open()
            da.Fill(dt)
            CNS.Close()
        Catch ex As Exception
            MessageBox.Show("Error al abrir la base de datos" & vbCrLf & ex.Message)
        End Try
        If dt.Rows.Count = 1 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Function ObtenerGrupo(ByRef cod_grupo As String, ByRef Optional nomBD As String = Nothing) As DataTable
        Dim da
        If Not String.IsNullOrWhiteSpace(nomBD) Then
            da = New System.Data.Odbc.OdbcDataAdapter("Select * FROM  " & nomBD & " WHERE matcod = '" & cod_grupo & "'", CNS)
        Else
            da = New System.Data.Odbc.OdbcDataAdapter("Select * FROM  " & NombreDB & " WHERE matcod = '" & cod_grupo & "'", CNS)
        End If
        Dim dt As New DataTable
        Try
            Using CNS
                CNS.Open()
                da.Fill(dt)
                CNS.Close()

            End Using
        Catch ex As Exception
            MessageBox.Show("Error al abrir la base de datos" & vbCrLf & ex.Message)
        End Try
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function LlenarDGV(ByRef BD As ModeloDBF) As DataTable
        Dim da
        If Not String.IsNullOrWhiteSpace(BD.NombreDB) Then
            da = New System.Data.Odbc.OdbcDataAdapter("Select * FROM  " & BD.NombreDB, BD.CNS)
        End If
        Dim dt As New DataTable
        Try
            Using BD.CNS
                BD.CNS.Open()
                da.Fill(dt)
                BD.CNS.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al abrir la base de datos" & vbCrLf & ex.Message)
        End Try
        If dt.Rows.Count >= 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function LlenarDGV(ByRef BD As ModeloDBF, ByRef Consulta As String) As DataTable
        Dim da
        da = New System.Data.Odbc.OdbcDataAdapter(Consulta, BD.CNS)
        Dim dt As New DataTable
        Try
            Using BD.CNS
                BD.CNS.Open()
                da.Fill(dt)
                BD.CNS.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al abrir la base de datos" & vbCrLf & ex.Message)
        End Try
        If dt.Rows.Count >= 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
End Class
