
Imports System.ComponentModel

Public Class DLGDiferencias
    Dim ListaGes As BindingList(Of ItemDevolucion)
    Dim ListaSuc As BindingList(Of ItemDevolucion)
    Public Sub DLGDiferencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(sender) Then
            ListaGes = New BindingList(Of ItemDevolucion)(sender(0))
            ListaSuc = New BindingList(Of ItemDevolucion)(sender(1))
            DGVDiferenciasGes.DataSource = ListaGes
            DGVDiferenciasSuc.DataSource = ListaSuc
        End If
        'DGVDiferenciasGes.Columns("Articulo").DataPropertyName = "ItemDevolucion.ArticuloGenerico.CodGestion"
        DGVDiferenciasGes.Columns(0).Visible = False
        DGVDiferenciasGes.Columns(1).Visible = False
        DGVDiferenciasGes.Columns(5).Visible = False
        DGVDiferenciasSuc.Columns(0).Visible = False
        DGVDiferenciasSuc.Columns(1).Visible = False
        DGVDiferenciasSuc.Columns(5).Visible = False
        'Dim NuevaColumna As New DataGridViewComboBoxColumn
        'NuevaColumna.DataSource = sender(1)
        'DGVDiferenciasGes.Columns.Add(NuevaColumna)
    End Sub
    Private Sub DGVDiferenciasGes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVDiferenciasGes.CellFormatting
        If TypeOf e.Value Is Alternativa Then
            e.Value = TryCast(e.Value, Alternativa).CodigoGestion
        End If
        If TypeOf e.Value Is ArticuloGenerico Then
            e.Value = TryCast(e.Value, ArticuloGenerico).CodGestion
        End If
        If TypeOf e.Value Is Talle Then
            e.Value = TryCast(e.Value, Talle).CodigoGestion
        End If
    End Sub

    Private Sub DGVDiferenciasSuc_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVDiferenciasSuc.CellFormatting
        If TypeOf e.Value Is Alternativa Then
            e.Value = TryCast(e.Value, Alternativa).CodigoDragon
        End If
        If TypeOf e.Value Is ArticuloGenerico Then
            e.Value = TryCast(e.Value, ArticuloGenerico).CodLince
        End If
        If TypeOf e.Value Is Talle Then
            e.Value = TryCast(e.Value, Talle).CodigoLince
        End If
    End Sub
    Private Sub BTNDesglosar_Click(sender As Object, e As EventArgs) Handles BTNDesglosar.Click
        If DGVDiferenciasGes.SelectedRows.Count = 1 Then
            If DGVDiferenciasGes.SelectedRows(0).Cells("Cantidad").Value > 1 Then

                Dim NuevaFila As ItemDevolucion = ListaGes.Item(DGVDiferenciasGes.SelectedRows(0).Index).Clone()
                Dim Posicion As Integer = DGVDiferenciasGes.SelectedRows(0).Index + 1
                NuevaFila.Cantidad -= 1
                NuevaFila.Desglose = True
                ListaGes.Insert(Posicion, NuevaFila)
                ListaGes.Item(DGVDiferenciasGes.SelectedRows(0).Index).Cantidad -= 1
                DGVDiferenciasGes.Rows(DGVDiferenciasGes.SelectedRows(0).Index + 1).DefaultCellStyle.ForeColor = Color.Red
            End If
        End If
    End Sub
    Private Sub BTNFaltante_Click(sender As Object, e As EventArgs) Handles BTNFaltante.Click
        For Each Item As DataGridViewRow In DGVDiferenciasGes.SelectedRows
            ListaGes.Item(Item.Index).Faltante = True
        Next
        For Each Item As DataGridViewRow In DGVDiferenciasSuc.SelectedRows
            ListaSuc.Item(Item.Index).Faltante = True
        Next
        DGVDiferenciasGes.Refresh()
        DGVDiferenciasSuc.Refresh()
    End Sub
    Private Sub BTNSobrante_Click(sender As Object, e As EventArgs) Handles BTNSobrante.Click
        For Each Item As DataGridViewRow In DGVDiferenciasGes.SelectedRows
            ListaGes.Item(Item.Index).Sobrante = True
        Next
        For Each Item As DataGridViewRow In DGVDiferenciasSuc.SelectedRows
            ListaSuc.Item(Item.Index).Sobrante = True
        Next
        DGVDiferenciasGes.Refresh()
        DGVDiferenciasSuc.Refresh()
    End Sub
End Class