Imports System.Data.SqlClient

Public Class ModeloGestion
    Inherits Modelo
    Dim CNS As SqlConnection = Nothing
    Public Sub New()
        MyBase.New(My.Settings.CNSGestion_Servidor, My.Settings.CNSGestion_Instancia, My.Settings.CNSGestion_BD, My.Settings.CNSGestion_Usuario, My.Settings.CNSGestion_Contrasenia)
    End Sub
    Public Function ConsultarDevoluciones() As DataTable
        Dim Consulta As String = "SELECT 'LE COQ-'+CAST(TCM.GIT05Id As Varchar) +'-'+ TCM.CodTCm As 'EMP-CODTCM-TCM',
                                    CPB.NumComO As 'Comprobante',
                                    CPB.FecCom As 'Fecha',
                                    ANA.CodAna+' - '+REPLACE(SUBSTRING(ANA.DesAna,CHARINDEX('(',ANA.DesAna)+1,LEN(ANA.DesAnA)),')','') As 'Sucursal',
                                    ISNULL(SUM(ITS.Cantid),0) As 'Cantidad'
                                    FROM GI_DN.dbo.GIN01CPB AS CPB
                                    INNER JOIN GI_DN.dbo.GIT05TCM AS TCM ON TCM.GIT05Id=CPB.IDGIT05O
                                    INNER JOIN GI_DN.dbo.GIM02ANA AS ANA ON CPB.IdGIM02O=ANA.GIM02Id
                                    LEFT JOIN GI_DN.dbo.GIN02ITS AS ITS ON CPB.GIN01Id=ITS.IdGIN01O
                                    WHERE TCM.GIT05Id=341 AND ANA.DesAna LIKE 'DISTRINANDO S.A_%(%' AND ANA.GIM02Id <> 36707 AND ANA.GIM02Id <> 4193 AND ANA.GIM02Id <> 38238 AND ANA.GIM02Id <> 37962
                                    GROUP BY NumComO,GIT05Id,CodTCm,FecCom,CodAna,DesAna
                                    UNION
                                    SELECT 'LE COQ-'+CAST(TCM.GIT05Id As Varchar) +'-'+ TCM.CodTCm As 'EMP-CODTCM-TCM',
                                    CPB.NumComO As 'Comprobante',
                                    CPB.FecCom As 'Fecha',
                                    ANA.CodAna+' - '+REPLACE(SUBSTRING(ANA.DesAna,CHARINDEX('(',ANA.DesAna)+1,LEN(ANA.DesAnA)),')','') As 'Sucursal',
                                    ISNULL(SUM(ITS.Cantid),0) As 'Cantidad'
                                    FROM GI_DN2.dbo.GIN01CPB AS CPB
                                    INNER JOIN GI_DN2.dbo.GIT05TCM AS TCM ON TCM.GIT05Id=CPB.IDGIT05O
                                    INNER JOIN GI_DN2.dbo.GIM02ANA AS ANA ON CPB.IdGIM02O=ANA.GIM02Id
                                    LEFT JOIN GI_DN2.dbo.GIN02ITS AS ITS ON CPB.GIN01Id=ITS.IdGIN01O
                                    WHERE TCM.GIT05Id=341 AND ANA.DesAna LIKE 'DISTRINANDO S.A_%(%' AND ANA.GIM02Id <> 36707 AND ANA.GIM02Id <> 4193 AND ANA.GIM02Id <> 38238 AND ANA.GIM02Id <> 37962
                                    GROUP BY NumComO,GIT05Id,CodTCm,FecCom,CodAna,DesAna
                                    ORDER BY [Fecha]"
        Dim DT = New DataTable
        Try
            Dim CMD As New SqlCommand(Consulta, If(IsNothing(CNS), Conectar(), CNS))
            Dim DA = New SqlDataAdapter(CMD)
            DA.Fill(DT)
        Catch ex As SqlException
            MsgBox("ModeloGestion.ListaDevGestion" + vbCrLf + ex.Message)
            Return Nothing
        End Try
        Return DT
    End Function
End Class
