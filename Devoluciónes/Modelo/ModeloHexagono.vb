Public Class ModeloHexagono
    Inherits ModeloSQL
    Public Sub New()
        MyBase.New(My.Settings.CNSHexagono_Servidor, My.Settings.CNSHexagono_Instancia, My.Settings.CNSHexagono_BD, My.Settings.CNSHexagono_Usuario, My.Settings.CNSHexagono_Contrasenia)
    End Sub
End Class
