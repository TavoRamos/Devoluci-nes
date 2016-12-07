<Serializable()>
Public Class Talle
    Public Property ID As UInteger
    Public Property Descripcion As String
    Public Property CodigoLince As String
    Public Property CodigoDragon As String
    Public Property CodigoGestion As String
    Public Property CodigoHexagono As String
    Public Sub New()
    End Sub
    Public Sub New(ByRef descripcion As String, ByRef cod_lince As String, ByRef cod_dragon As String, ByRef cod_gestion As String,
                   ByRef cod_hexagono As String, ByRef Optional ID As UInteger = Nothing)
        Me.Descripcion = descripcion
        Me.ID = ID
        CodigoLince = cod_lince
        CodigoDragon = cod_dragon
        CodigoGestion = cod_gestion
        CodigoHexagono = cod_hexagono
    End Sub
End Class
