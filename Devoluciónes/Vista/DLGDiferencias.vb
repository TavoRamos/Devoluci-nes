
Public Class DLGDiferencias
    Public Sub DLGDiferencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(sender) Then
            DGVDiferenciasGes.DataSource = New System.ComponentModel.BindingList(Of ItemDevolucion)(sender(0))

            'DGVDiferenciasSuc.DataSource = sender(1)
        End If
        'DGVDiferenciasGes.Columns("Articulo").DataPropertyName = "ItemDevolucion.ArticuloGenerico.CodGestion"
    End Sub
End Class