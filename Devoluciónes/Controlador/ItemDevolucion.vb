Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()>
Public Class ItemDevolucion
    Implements ICloneable
    Public Property ID As UInteger
    Public Property IdDevolucion As UInteger
    Public Property Articulo As ArticuloGenerico
    Public Property Alternativa As Alternativa
    Public Property Talle As Talle
    Public Property Observacion As String
    Public Property Cantidad As UInteger
    Public Property Desglose As Boolean
    Public Property Sobrante As Boolean
    Public Property Faltante As Boolean
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

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim m As New MemoryStream()
        Dim f As New BinaryFormatter()
        f.Serialize(m, Me)
        m.Seek(0, SeekOrigin.Begin)
        Return f.Deserialize(m)
    End Function
    'Public Overloads Function ToString()
    '    Return Me.GetHashCode
    'End Function
End Class
