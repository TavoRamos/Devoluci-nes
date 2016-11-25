Public Class ModeloLince
    Inherits ModeloDBF
    Public Sub New(ByRef Art_Mov As String)
        MyBase.New(If(Art_Mov = "Art", My.Settings.CNSLince_UbicacionBDArt, My.Settings.CNSLince_UbicacionBDMov), If(Art_Mov = "Art", My.Settings.CNSLince_BDArt, My.Settings.CNSLince_BDMov))
    End Sub
    Public Function DetalleMovimiento(ByRef NumMovimiento As Integer) As DataTable
        Dim da
        If Not String.IsNullOrWhiteSpace(NombreDB) Then
            da = New System.Data.Odbc.OdbcDataAdapter("Select mart,mtall,desc,canti FROM " & NombreDB & " WHERE mx1=" & NumMovimiento.ToString, CNS)
        End If
        Dim dt As New DataTable
        Try
            CNS.Open()
            da.Fill(dt)
            CNS.Close()
        Catch ex As Exception
            MessageBox.Show("ModeloDBF.DetalleMovimiento" & vbCrLf & ex.Message)
        End Try
        If dt.Rows.Count >= 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Function MovimientosPorSucursal(ByRef Sucursal As Sucursal) As DataTable
        If Sucursal.TieneLince = False Then
            MsgBox("La sucursal especificada no tiene usa Lince")
            Return Nothing
        End If
        Dim da
        If Not String.IsNullOrWhiteSpace(NombreDB) Then
            da = New System.Data.Odbc.OdbcDataAdapter("SELECT 'Num. '+ltrim(rtrim(str(numr)))+' - Rem. '+ltrim(rtrim(rem))+' ('+ltrim(rtrim(str(SUM(canti))))+')' As 'movimiento',SUM(canti),rem,numr,fchr,mx1 FROM " & NombreDB & " WHERE mcli='" & Sucursal.CodigoLince & "' AND estado<>1 GROUP BY rem,fchr,numr ORDER BY fchr", CNS)
        End If
        Dim dt As New DataTable
        Try
            CNS.Open()
            da.Fill(dt)
            CNS.Close()
        Catch ex As Exception
            MessageBox.Show("ModeloDBF.MovimientosPorSucursal" & vbCrLf & ex.Message)
            CNS.Close()
        End Try
        If dt.Rows.Count >= 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
End Class
