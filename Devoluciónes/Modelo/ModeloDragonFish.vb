Public Class ModeloDragonFish
    Inherits ModeloSQL
    Public Sub New()
        MyBase.New(My.Settings.CNSDragon_Servidor, My.Settings.CNSDragon_Instancia, My.Settings.CNSDragon_BD, My.Settings.CNSDragon_Usuario, My.Settings.CNSDragon_Contrasenia)
    End Sub
End Class
