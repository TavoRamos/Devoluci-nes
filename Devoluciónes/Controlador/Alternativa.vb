<Serializable()>
Public Class Alternativa
    Public Property ID As UInteger
    Public Property CodigoGestion As String
    Public Property CodigoDragon As String
    Public Property CodigoHexagono As String
    Public Property Descripcion As String
    Public Sub New()
    End Sub
    Public Sub New(ByRef codigo_gestion As String, ByRef codigo_dragon As String, ByRef codigo_hexagono As String, ByRef descripcion As String, ByRef Optional ID As UInteger = Nothing)
        CodigoGestion = codigo_gestion
        CodigoDragon = codigo_dragon
        CodigoHexagono = codigo_hexagono
        Me.Descripcion = descripcion
        Me.ID = ID
    End Sub
End Class
