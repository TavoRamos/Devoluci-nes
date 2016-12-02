Public Class ItemDevolucion
    Public Property ID As UInteger
    Public Property IdDevolucion As UInteger
    Public Property Articulo As ArticuloGenerico
    Public Property Alternativa As Alternativa
    Public Property Talle As Talle
    Public Property Observacion As String
    Public Property Cantidad As UInteger
    'Public Property IDFalla As UInteger
    Public Sub New()
    End Sub
    Public Sub New(ByRef articulo As ArticuloGenerico, ByRef alternativa As Alternativa, ByRef talle As Talle, ByRef cantidad As UInteger,
                   ByRef Optional observacion As String = Nothing, ByRef Optional id_devolucion As UInteger = Nothing, ByRef Optional ID As UInteger = Nothing)
        Me.Articulo = articulo
        Me.Alternativa = alternativa
        Me.Talle = talle
        Me.Observacion = observacion
        IdDevolucion = id_devolucion
        Me.ID = ID
        Me.Cantidad = cantidad
    End Sub
End Class
