Public Class ArticuloGenerico
    Public Property ID As UInteger
    Public Property CodLince As String
    Public Property CodDragon As String
    Public Property CodGestion As String
    Public Property CodHexagono As String
    Public Property Descripcion As String
    Public Property Marca As String
    Public Sub New()
    End Sub
    Public Sub New(ByRef cod_Lince As String, ByRef cod_dragon As String, ByRef cod_gestion As String, ByRef cod_hexagono As String, ByRef descripcion As String, ByRef marca As String, ByRef Optional ID As UInteger = Nothing)
        CodLince = cod_Lince
        CodDragon = cod_dragon
        CodGestion = cod_gestion
        CodHexagono = cod_hexagono
        Me.Descripcion = descripcion
        Me.Marca = marca
        Me.ID = ID
    End Sub
End Class
