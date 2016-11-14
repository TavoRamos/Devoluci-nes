Public Class ModeloLince
    Public Shared Function DetalleMovimiento(ByRef BD As ModeloDBF, ByRef NumMovimiento As Integer) As DataTable
        Dim da
        If Not String.IsNullOrWhiteSpace(BD.NombreDB) Then
            da = New System.Data.Odbc.OdbcDataAdapter("Select mart,mtall,desc,canti, FROM  " & BD.NombreDB & "WHERE numr='" & NumMovimiento.ToString, BD.CNS)
        End If
        Dim dt As New DataTable
        Try
            Using BD.CNS
                BD.CNS.Open()
                da.Fill(dt)
                BD.CNS.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("ModeloDBF.DetalleMovimiento" & vbCrLf & ex.Message)
        End Try
        If dt.Rows.Count >= 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function MovimientosPorLocal(ByRef BD As ModeloDBF, ByRef Sucursal As String) As DataTable
        Dim da
        If Not String.IsNullOrWhiteSpace(BD.NombreDB) Then
            da = New System.Data.Odbc.OdbcDataAdapter("Select mart,mtall,desc,canti, FROM  " & BD.NombreDB & "WHERE mcli='" & Sucursal.ToString, BD.CNS)
        End If
        Dim dt As New DataTable
        Try
            Using BD.CNS
                BD.CNS.Open()
                da.Fill(dt)
                BD.CNS.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("ModeloDBF.DetalleMovimiento" & vbCrLf & ex.Message)
        End Try
        If dt.Rows.Count >= 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
End Class
