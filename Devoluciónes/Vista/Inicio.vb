Imports System.ComponentModel

Public Class Inicio
    Dim Gestion = New ModeloGestion()
    Dim Dragon = New ModeloDragonFish()
    Dim LinceArt = New ModeloLince("Art")
    Dim LinceMov = New ModeloLince("Mov")
    Dim Devoluciones = New ModeloDevoluciones()
    Dim ConexionHEX = New ModeloHexagono()
    Dim WithEvents Icono As New NotifyIcon
    Dim WithEvents Timer As New Timer
    Private Sub Inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icono.Visible = False
        Icono.Icon = My.Resources.Box2
        ShowInTaskbar = True
        ShowIcon = True
        DGVDev.DataSource = Gestion.ConsultarDevoluciones()
        DGVDev.Columns(0).Visible = False
        DGVDev.Columns(1).Visible = False
        Timer.Enabled = True
        Timer.Interval = My.Settings.IntervaloBusqueda
        Timer.Start()
    End Sub
    Private Sub Inicio_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        Hide()
        Icono.Visible = True
        'Icono.BalloonTipText = ""
        'Icono.ShowBalloonTip(500)
    End Sub
    Public Sub Maximizar() Handles Icono.DoubleClick
        Show()
        Icono.Visible = False
    End Sub
    Public Sub BuscarDevoluciones() Handles Timer.Tick
        Icono.BalloonTipTitle = "Devoluciones locales"
        Icono.BalloonTipText = (Gestion.ConsultarCantDevoluciones() - Devoluciones.DevolucionesPendientes()).ToString + If((Gestion.ConsultarCantDevoluciones() - Devoluciones.DevolucionesPendientes()) = 1, " Pendiente", " Pendientes")
        Icono.ShowBalloonTip(500)
    End Sub
    Private Sub DGVDev_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVDev.CellContentClick
        ListaMovsRef.DataSource = Nothing
        Dim Sucursal = New Sucursal(Mid(DGVDev.Item("Sucursal", e.RowIndex).Value, 1, InStr(DGVDev.Item("Sucursal", e.RowIndex).Value, " ") - 1), Devoluciones)
        Dim dt As DataTable
        dt = If(Sucursal.TieneLince = True, LinceMov.MovimientosPorSucursal(Sucursal), Nothing)
        ListaMovsRef.DataSource = dt
        ListaMovsRef.DisplayMember = "movimiento"
        ListaMovsRef.ValueMember = "mx1"
        For Each item As DataRowView In ListaMovsRef.Items
            MsgBox(item.ToString)
        Next
        Dim argumentos As New ArrayList
        argumentos.Add(DGVDev.Item("ID", e.RowIndex).Value)
        argumentos.Add(If(InStr(DGVDev.Item("EMP-CODTCM-TCM", e.RowIndex).Value, "DISTRI") <> -1, "Distri", "Lecoq"))
        argumentos.Add(Sucursal)
        If BGW1.IsBusy Then
            BGW1.CancelAsync()
        End If
        DGVGestion.SuspendLayout()
        PBDGVGestion.Visible = True
        BGW1.RunWorkerAsync(argumentos)
        'Gestion.DetalleDevolucion(DGVDev.Item("ID", e.RowIndex).Value, If(InStr(DGVDev.Item("EMP-CODTCM-TCM", e.RowIndex).Value, "DISTRI") <> -1, "Distri", "Lecoq"))
        DGVSucursal.DataSource = Nothing
        'Gestion.ConvertirCodigosALince(DGVDev.Item("ID", e.RowIndex).Value, If(InStr(DGVDev.Item("EMP-CODTCM-TCM", e.RowIndex).Value, "DISTRI") <> -1, "Distri", "Lecoq"), Sucursal)
    End Sub
    Private Sub SplitContainer2_DoubleClick(sender As Object, e As EventArgs) Handles SplitContainer2.DoubleClick
        If SplitContainer2.SplitterDistance = 25 Then
            SplitContainer2.SplitterDistance = 151
        Else
            SplitContainer2.SplitterDistance = 0
        End If
    End Sub
    Private Sub ListaMovsRef_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles ListaMovsRef.ItemCheck
        If e.NewValue = CheckState.Unchecked Then

        Else
            Try
                If IsNothing(DGVSucursal.DataSource) Then
                    DGVSucursal.DataSource = LinceMov.DetalleMovimiento(ListaMovsRef.SelectedValue)
                Else
                    DirectCast(DGVSucursal.DataSource, DataTable).Merge(LinceMov.DetalleMovimiento(ListaMovsRef.SelectedValue))
                    'Dim DT As DataTable = Nothing
                    'For Each item As DataRowView In ListaMovsRef.CheckedItems
                    '    If IsNothing(DGVSucursal.DataSource) Then
                    '        DT = LinceMov.DetalleMovimiento(item.Item("mx1"))
                    '    Else
                    '        DT.Merge(LinceMov.DetalleMovimiento(item.Item("mx1")))
                    '    End If

                    'Next
                    'DGVSucursal.DataSource = DT
                    'DT.Merge(LinceMov.DetalleMovimiento(ListaMovsRef.SelectedValue))
                    'DGVSucursal.DataSource = DT
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub BGW1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BGW1.DoWork
        Try
            Dim parametros As ArrayList
            parametros = DirectCast(e.Argument, ArrayList)
            BGW1.ReportProgress(50)
            e.Result = Gestion.ConvertirCodigosALince(parametros(0), parametros(1), parametros(2))
            BGW1.ReportProgress(75)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub BGW1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BGW1.RunWorkerCompleted
        DGVGestion.DataSource = e.Result
        PBDGVGestion.Value = 100
        DGVGestion.ResumeLayout()
        PBDGVGestion.Visible = False
        DGVGestion.Columns("IDITM").Visible = False
        DGVGestion.Columns("CONVERTIDO").Visible = False
    End Sub
    Private Sub BGW1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BGW1.ProgressChanged
        PBDGVGestion.Value = e.ProgressPercentage
    End Sub
    Private Sub SplitContainer1_DoubleClick(sender As Object, e As EventArgs) Handles SplitContainer1.DoubleClick
        If SplitContainer1.SplitterDistance = 455 Then
            SplitContainer1.SplitterDistance = 0
        Else
            SplitContainer1.SplitterDistance = 455
        End If
    End Sub
    Private Sub DGVGestion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVGestion.CellClick
        If DGVGestion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.BlanchedAlmond Or DGVGestion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty Then
            DGVGestion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
            DGVGestion.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
            DGVGestion.Rows(e.RowIndex).DefaultCellStyle.Format = FontStyle.Italic
        Else
            If (DGVGestion.Rows(e.RowIndex).Cells("CONVERTIDO").Value = True) Then
                DGVGestion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.BlanchedAlmond
            Else
                DGVGestion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
            DGVGestion.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Empty
            DGVGestion.Rows(e.RowIndex).DefaultCellStyle.Format = FontStyle.Regular
        End If
    End Sub
    Private Sub DGVGestion_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DGVGestion.RowsAdded
        If DGVGestion.Rows(e.RowIndex).Cells("CONVERTIDO").Value = True Then
            DGVGestion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.BlanchedAlmond
        End If
    End Sub


End Class
