Imports System.ComponentModel

Public Class Inicio
    Dim Gestion = New ModeloGestion()
    Dim ConexionDRA As SqlClient.SqlConnection
    Dim ConexionLIN As SqlClient.SqlConnection
    Dim ConexionDEV As SqlClient.SqlConnection
    Dim WithEvents Icono As New NotifyIcon
    Dim WithEvents Timer As New Timer
    'Dim ConexionHEX As SqlClient.SqlConnection
    Private Sub Inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icono.Visible = False
        Icono.Icon = My.Resources.Box2
        ShowInTaskbar = True
        ShowIcon = True
        DGVDev.DataSource = Gestion.ConsultarDevoluciones()
        DGVDev.Columns(0).Visible = False
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
    Public Sub BuscarDevoluciones()

    End Sub
End Class
