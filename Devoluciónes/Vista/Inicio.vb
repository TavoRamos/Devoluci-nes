Imports System.ComponentModel
Imports System.Linq

Public Class Inicio
    Dim Gestion = New ModeloGestion()
    Dim Dragon = New ModeloDragonFish()
    Dim LinceArt = New ModeloLince("Art")
    Dim LinceMov = New ModeloLince("Mov")
    Dim Devoluciones = New Devolucion()
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
            e.Result = Gestion.DetalleDevolucion(parametros(0), parametros(1))
            'e.Result = Gestion.ConvertirCodigosALince(parametros(0), parametros(1), parametros(2))
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
        'DGVGestion.Columns("IDITM").Visible = False
        'DGVGestion.Columns("CONVERTIDO").Visible = False
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
    'Private Sub DGVGestion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVGestion.CellClick
    '    If DGVGestion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.BlanchedAlmond Or DGVGestion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty Then
    '        DGVGestion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
    '        DGVGestion.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
    '        DGVGestion.Rows(e.RowIndex).DefaultCellStyle.Format = FontStyle.Italic
    '    Else
    '        If (DGVGestion.Rows(e.RowIndex).Cells("CONVERTIDO").Value = True) Then
    '            DGVGestion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.BlanchedAlmond
    '        Else
    '            DGVGestion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
    '        End If
    '        DGVGestion.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Empty
    '        DGVGestion.Rows(e.RowIndex).DefaultCellStyle.Format = FontStyle.Regular
    '    End If
    'End Sub
    'Private Sub DGVGestion_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DGVGestion.RowsAdded
    '    'If DGVGestion.Rows(e.RowIndex).Cells("CONVERTIDO").Value = True Then
    '    '    DGVGestion.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.BlanchedAlmond
    '    'End If
    'End Sub
    Dim DTDGVDevAux As DataTable
    Private Sub BTNLimpiarSeleccion_Click(sender As Object, e As EventArgs) Handles BTNLimpiarSeleccion.Click
        DGVDev.DataSource = Nothing
        DGVDev.DataSource = DTDGVDevAux
    End Sub
    Private Sub BTNDiferencias_Click(sender As Object, e As EventArgs) Handles BTNDiferencias.Click
        'Dim Ges = (From p In DGVGestion.Rows
        '           Let Articulo = p.Cells("CODIGO").Value.ToString.Trim
        '           Let Cantidad As Single = p.Cells("CANTIDAD").Value
        '           Let Talle = p.Cells("TALLE").Value.ToString.Trim
        '           Select Cantidad, Articulo, Talle
        '           Group By Cantidad, Articulo, Talle Into Sum(Cantidad)
        '           Order By Articulo, Talle, Cantidad).ToList
        'Dim Suc = (From p In DGVSucursal.Rows
        '           Let Articulo = p.Cells("mart").Value.ToString.Trim
        '           Let Cantidad As Single = p.Cells("canti").Value
        '           Let Talle = p.Cells("mtall").Value.ToString.Trim
        '           Select Cantidad, Articulo, Talle
        '           Group By Cantidad, Articulo, Talle Into Sum(Cantidad)
        '           Order By Articulo, Talle, Cantidad).ToList
        '--------------------------------------------------------------------------- PRIMER INTENTO
        'Dim DiferenciaGest = (From p In Ges
        '                      From q In Suc
        '                      Where p.Articulo <> q.Articulo Or p.Sum <> q.Sum Or p.Talle <> q.Talle
        '                      Let ArticuloGes = p.Articulo
        '                      Let CantGes = p.Cantidad
        '                      Let TalGes = p.Talle
        '                      Let SumGes = p.Sum
        '                      Let ArticuloSuc = q.Articulo
        '                      Let CantSuc = q.Cantidad
        '                      Let TalSuc = q.Talle
        '                      Let SumSuc = q.Sum
        '                      Select CantGes, CantSuc, ArticuloGes, ArticuloSuc, TalGes, TalSuc, SumGes, SumSuc Distinct).ToList
        '--------------------------------------------------------------------------- SEGUNDO INTENTO
        'Dim DiferenciaGest = (From p In Ges Join q In Suc On q.Articulo Equals p.Articulo
        '                      Let ArticuloGes = p.Articulo
        '                      Let CantGes = p.Cantidad
        '                      Let TalGes = p.Talle
        '                      Let SumGes = p.Sum
        '                      Let ArticuloSuc = q.Articulo
        '                      Let CantSuc = q.Cantidad
        '                      Let TalSuc = q.Talle
        '                      Let SumSuc = q.Sum
        '                      Group By ArticuloGes, TalGes Into g = Group
        '                      Order By ArticuloGes, TalGes
        '                      From y In g.DefaultIfEmpty
        '                      Where y.ArticuloGes <> y.ArticuloSuc Or y.SumGes <> y.SumSuc Or y.TalGes <> y.TalSuc
        '                      Select y.ArticuloGes, y.TalGes, y.SumGes Distinct).ToList

        'Dim DiferenciaSuc = (From p In Ges Join q In Suc On q.Articulo Equals p.Articulo
        '                     Let ArticuloGes = p.Articulo
        '                     Let CantGes = p.Cantidad
        '                     Let TalGes = p.Talle
        '                     Let SumGes = p.Sum
        '                     Let ArticuloSuc = q.Articulo
        '                     Let CantSuc = q.Cantidad
        '                     Let TalSuc = q.Talle
        '                     Let SumSuc = q.Sum
        '                     Group By ArticuloSuc, TalSuc Into g = Group
        '                     Order By ArticuloSuc, TalSuc
        '                     From y In g.DefaultIfEmpty
        '                     Where y.ArticuloGes <> y.ArticuloSuc Or y.SumGes <> y.SumSuc Or y.TalGes <> y.TalSuc
        '                     Select y.ArticuloSuc, y.TalSuc, y.SumSuc Distinct).ToList
        Dim A(2)
        'A(0) = DiferenciaGest
        'A(1) = DiferenciaSuc
        'DLGDiferencias.Show()
        'DLGDiferencias.DLGDiferencias_Load(A, EventArgs.Empty)
        '--------------------------------------------------------------------------- TERCER INTENTO        '
        'Dim Diferencias = (From p In Ges.DefaultIfEmpty Join q In Suc.DefaultIfEmpty On p.Articulo Equals q.Articulo
        '                   Order By p.Articulo, p.Talle
        '                   Group By p.Articulo, p.Talle Into g = Group
        '                   From y In g.DefaultIfEmpty()
        '                   Let sum2 = y.q.Sum
        '                   Let art2 = y.q.Articulo
        '                   Let tal2 = y.q.Talle
        '                   Where y.p.Articulo <> art2 Or y.p.Talle <> tal2 Or y.p.Sum <> sum2
        '                   Select y.p.Articulo, art2, y.p.Talle, tal2, y.p.Sum, sum2
        '                   Order By Articulo, art2, Talle, tal2, Sum, sum2
        '                   Group By Articulo, art2, Talle, tal2, Sum, sum2 Into Group).ToList
        '--------------------------------------------------------------------------- CUARTO INTENTO        '
        'Dim Diferencias = (From p In Ges Join q In Suc.DefaultIfEmpty On p.Articulo Equals q.Articulo
        '                   Let Art2 = q.Articulo
        '                   Let Tal2 = q.Talle
        '                   Let Sum2 = q.Sum
        '                   Group By p.Articulo, Art2, p.Talle, Tal2, p.Sum, Sum2 Into g = Group
        '                   From y In g.DefaultIfEmpty
        '                   Where y.p.Articulo <> y.q.Articulo Or y.p.Talle <> y.q.Talle Or y.p.Sum <> y.q.Sum
        '                   Select y.p.Articulo, Art2, y.p.Talle, Tal2, y.p.Sum, Sum2).ToList
        'A(0) = Diferencias
        'A(1) = DiferenciaSuc
        A = Devoluciones.CalcularDiferencias(DGVGestion.DataSource, DGVSucursal.DataSource, Sucursal)
        'A(1) = Devoluciones.CalcularDiferencias(DGVGestion.DataSource, DGVSucursal.DataSource, Sucursal)(1)

        DLGDiferencias.DLGDiferencias_Load(A, EventArgs.Empty)
        DLGDiferencias.Show()
    End Sub
    Dim Sucursal As Sucursal
    Private Sub DGVDev_KeyDown(sender As Object, e As KeyEventArgs) Handles DGVDev.KeyDown
        If e.KeyCode = Keys.Enter Then
            'BTNLimpiarSeleccion.Visible = True
            'If DGVDev.SelectedRows.Count = 1 Then
            '    DTDGVDevAux = DGVDev.DataSource
            '    Dim NuevoDS
            '    NuevoDS = (From p As DataGridViewRow In DGVDev.Rows Select p Where p.Cells("EMP-CODTCM-TCM").Equals(DGVDev.SelectedRows.Item(0).Cells("EMP-CODTCM-TCM").Value) And
            '                                                                 p.Cells("Sucursal").Equals(DGVDev.SelectedRows.Item(0).Cells("Sucursal").Value))
            '    DGVDev.DataSource = NuevoDS
            'End If
            ListaMovsRef.DataSource = Nothing
            Dim ListaMovs As New List(Of Integer)
            Sucursal = New Sucursal(Mid(DGVDev.SelectedRows(0).Cells("Sucursal").Value, 1, InStr(DGVDev.SelectedRows(0).Cells("Sucursal").Value, " ") - 1), Devoluciones)
            Dim dt As DataTable
            dt = If(Sucursal.TieneLince = True, LinceMov.MovimientosPorSucursal(Sucursal), Nothing)
            ListaMovsRef.DataSource = dt
            ListaMovsRef.DisplayMember = "movimiento"
            ListaMovsRef.ValueMember = "mx1"
            '---PRUEBA
            'For Each item As DataRowView In ListaMovsRef.Items
            '    MsgBox(item.ToString)
            'Next
            Dim argumentos As New ArrayList
            Dim ListaComp As New List(Of Integer)
            For Each fila As DataGridViewRow In DGVDev.SelectedRows
                ListaComp.Add(fila.Cells("ID").Value)
            Next
            argumentos.Add(ListaComp)
            argumentos.Add(If(InStr(DGVDev.SelectedRows(0).Cells("EMP-CODTCM-TCM").Value, "DISTRI") <> -1, "Distri", "Lecoq"))
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
        End If
    End Sub
End Class
