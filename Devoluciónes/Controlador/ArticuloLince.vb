Imports System.ComponentModel

Public Class ArticuloLince
    Public Property Codigo As String
    'Public Property Proveedor As Porveedor
    Public Property Descripcion As String
    Public Property Color As String
    'Public Property Grupo As GrupoLince
    'Public Property Grupo As String
    Public Property Precio As List(Of Decimal)
    Public Property Marca() As String
    Public Sub New(ByRef cod As String, ByRef desart As String, ByRef col As String, ByRef grupart As String, ByRef precio As List(Of Decimal))
        Codigo = cod
        Descripcion = desart
        Color = col
        'Grupo = New GrupoLince(grupart, Nothing, Nothing)
        Me.Precio = precio
    End Sub
    Public Shared Function NuevoArticuloDesdeBD(ByRef codart As String) As ArticuloLince
        Dim BD As New ModeloDBF(My.Settings.CNSLince_UbicacionBD, My.Settings.CNSLince_BDArt)
        Dim dt As DataTable = BD.ObtenerArticulo(codart)
        Dim precio = New List(Of Decimal)
        precio.Add(Decimal.TryParse(dt.Rows(0).Item("apr1").ToString, 0))
        precio.Add(Decimal.TryParse(dt.Rows(0).Item("apr2").ToString, 0))
        precio.Add(Decimal.TryParse(dt.Rows(0).Item("apr3").ToString, 0))
        precio.Add(Decimal.TryParse(dt.Rows(0).Item("apr4").ToString, 0))
        precio.Add(Decimal.TryParse(dt.Rows(0).Item("apr5").ToString, 0))
        Dim Articulo As New ArticuloLince(codart, dt.Rows(0).Item("artdes").ToString.Trim, dt.Rows(0).Item("amate").ToString.Trim, dt.Rows(0).Item("artgrupo").ToString.Trim, precio)
        Return Articulo
    End Function
End Class