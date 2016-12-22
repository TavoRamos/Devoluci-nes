Imports System.Data.SqlClient
Imports System.Text.RegularExpressions.Regex
Public Class ModeloGestion
    Inherits ModeloSQL
    Public Sub New()
        MyBase.New(My.Settings.CNSGestion_Servidor, My.Settings.CNSGestion_Instancia, My.Settings.CNSGestion_BD, My.Settings.CNSGestion_Usuario, My.Settings.CNSGestion_Contrasenia)
    End Sub
    Public Function ConsultarDevoluciones() As DataTable
        Dim Consulta As String = "SELECT 'LE COQ-'+CAST(TCM.GIT05Id As Varchar) +'-'+ TCM.CodTCm As 'EMP-CODTCM-TCM',
                                    CPB.GIN01Id AS 'ID',
                                    CPB.NumComO As 'Comprobante',
                                    CPB.FecCom As 'Fecha',
                                    ANA.CodAna+' - '+REPLACE(SUBSTRING(ANA.DesAna,CHARINDEX('(',ANA.DesAna)+1,LEN(ANA.DesAnA)),')','') As 'Sucursal',
                                    ISNULL(SUM(ITS.Cantid),0) As 'Cantidad',
                                    CPB.ConPas As 'Concepto'
                                    FROM GI_DN.dbo.GIN01CPB AS CPB
                                    INNER JOIN GI_DN.dbo.GIT05TCM AS TCM ON TCM.GIT05Id=CPB.IDGIT05O
                                    INNER JOIN GI_DN.dbo.GIM02ANA AS ANA ON CPB.IdGIM02O=ANA.GIM02Id
                                    LEFT JOIN GI_DN.dbo.GIN02ITS AS ITS ON CPB.GIN01Id=ITS.IdGIN01O
                                    WHERE (TCM.GIT05Id=341 OR TCM.GIT05Id=342 OR TCM.GIT05Id=343) AND (ANA.DesAna LIKE 'DISTRINANDO S.A_%(%' OR ANA.GIM02Id=484)  /*AND ANA.GIM02Id <> 36707*/ AND ANA.GIM02Id <> 4193 AND ANA.GIM02Id <> 38238 AND ANA.GIM02Id <> 37962 AND CPB.Estado<>'A' 
                                    GROUP BY CPB.GIN01Id,NumComO,GIT05Id,CodTCm,FecCom,CodAna,DesAna,ConPas
                                    UNION
                                    SELECT 'DISTRI-'+CAST(TCM.GIT05Id As Varchar) +'-'+ TCM.CodTCm As 'EMP-CODTCM-TCM',
                                    CPB.GIN01Id AS 'ID',
                                    CPB.NumComO As 'Comprobante',
                                    CPB.FecCom As 'Fecha',
                                    ANA.CodAna+' - '+REPLACE(SUBSTRING(ANA.DesAna,CHARINDEX('(',ANA.DesAna)+1,LEN(ANA.DesAnA)),')','') As 'Sucursal',
                                    ISNULL(SUM(ITS.Cantid),0) As 'Cantidad',
                                    CPB.ConPas As 'Concepto'
                                    FROM GI_DN2.dbo.GIN01CPB AS CPB
                                    INNER JOIN GI_DN2.dbo.GIT05TCM AS TCM ON TCM.GIT05Id=CPB.IDGIT05O
                                    INNER JOIN GI_DN2.dbo.GIM02ANA AS ANA ON CPB.IdGIM02O=ANA.GIM02Id
                                    LEFT JOIN GI_DN2.dbo.GIN02ITS AS ITS ON CPB.GIN01Id=ITS.IdGIN01O
                                    WHERE (TCM.GIT05Id=341 OR TCM.GIT05Id=342 OR TCM.GIT05Id=343) AND (ANA.DesAna LIKE 'DISTRINANDO S.A_%(%' OR ANA.GIM02Id=484) /*AND ANA.GIM02Id <> 36707*/ AND ANA.GIM02Id <> 4193 AND ANA.GIM02Id <> 38238 AND ANA.GIM02Id <> 37962 AND CPB.Estado<>'A'
                                    GROUP BY CPB.GIN01Id,NumComO,GIT05Id,CodTCm,FecCom,CodAna,DesAna,ConPas
                                    ORDER BY [Comprobante],[Fecha] DESC"
        Dim DT = New DataTable
        Try
            Dim CMD As New SqlCommand(Consulta, MyBase.CNS)
            Dim DA = New SqlDataAdapter(CMD)
            DA.Fill(DT)
        Catch ex As SqlException
            MsgBox("ModeloGestion.ListaDevGestion" + vbCrLf + ex.Message)
            Return Nothing
        End Try
        Return DT
    End Function
    Public Function ConsultarCantDevoluciones() As Integer
        Dim R As Integer
        Dim ConsultaCantidadGestion As String = "DECLARE @CantLecoq As int
                                                    SET @CantLecoq=(SELECT DISTINCT COUNT(CPB.NUMCOMO) As 'Cantidad devoluciones' FROM GI_DN.dbo.GIN01CPB AS CPB INNER JOIN GI_DN.dbo.GIT05TCM AS TCM ON TCM.GIT05Id=CPB.IDGIT05O INNER JOIN GI_DN.dbo.GIM02ANA AS ANA ON CPB.IdGIM02O=ANA.GIM02Id WHERE TCM.GIT05Id=341 AND ANA.DesAna LIKE 'DISTRINANDO S.A_%(%' AND ANA.GIM02Id <> 36707 AND ANA.GIM02Id <> 4193 AND ANA.GIM02Id <> 38238 AND ANA.GIM02Id <> 37962 AND CPB.Estado<>'A')
                                                    DECLARE @CantDistri As int
                                                    SET @CantDistri=(SELECT DISTINCT COUNT(CPB.NUMCOMO) As 'Cantidad devoluciones' FROM GI_DN2.dbo.GIN01CPB AS CPB INNER JOIN GI_DN2.dbo.GIT05TCM AS TCM ON TCM.GIT05Id=CPB.IDGIT05O INNER JOIN GI_DN2.dbo.GIM02ANA AS ANA ON CPB.IdGIM02O=ANA.GIM02Id WHERE TCM.GIT05Id=341 AND ANA.DesAna LIKE 'DISTRINANDO S.A_%(%' AND ANA.GIM02Id <> 36707 AND ANA.GIM02Id <> 4193 AND ANA.GIM02Id <> 38238 AND ANA .GIM02Id <> 37962 AND CPB.Estado<>'A')
                                                    SELECT @CantLecoq+@CantDistri As 'Cant. devoluciones Gestion'"
        Try
            Dim DT As New DataTable
            Dim DA As New SqlDataAdapter(ConsultaCantidadGestion, MyBase.CNS)
            DA.Fill(DT)
            R = DT.Rows(0).Item(0)
            DA.Dispose()
            DT.Dispose()
        Catch ex As SqlException
            MsgBox("ModeloGestion.ListaDevGestion" + vbCrLf + ex.Message)
            Return Nothing
        End Try
        Return R
    End Function
    Public Function ConsultarCantDevolucionesPorLocal() As Integer
        Dim R As Integer
        Dim ConsultaCantidadGestion As String = "DECLARE @CantLecoq As int
                                                    SET @CantLecoq=(SELECT DISTINCT COUNT(CPB.NUMCOMO) As 'Cantidad devoluciones' FROM GI_DN.dbo.GIN01CPB AS CPB INNER JOIN GI_DN.dbo.GIT05TCM AS TCM ON TCM.GIT05Id=CPB.IDGIT05O INNER JOIN GI_DN.dbo.GIM02ANA AS ANA ON CPB.IdGIM02O=ANA.GIM02Id WHERE TCM.GIT05Id=341 AND ANA.DesAna LIKE 'DISTRINANDO S.A_%(%' AND ANA.GIM02Id <> 36707 AND ANA.GIM02Id <> 4193 AND ANA.GIM02Id <> 38238 AND ANA.GIM02Id <> 37962 AND CPB.Estado<>'A')
                                                    DECLARE @CantDistri As int
                                                    SET @CantDistri=(SELECT DISTINCT COUNT(CPB.NUMCOMO) As 'Cantidad devoluciones' FROM GI_DN2.dbo.GIN01CPB AS CPB INNER JOIN GI_DN2.dbo.GIT05TCM AS TCM ON TCM.GIT05Id=CPB.IDGIT05O INNER JOIN GI_DN2.dbo.GIM02ANA AS ANA ON CPB.IdGIM02O=ANA.GIM02Id WHERE TCM.GIT05Id=341 AND ANA.DesAna LIKE 'DISTRINANDO S.A_%(%' AND ANA.GIM02Id <> 36707 AND ANA.GIM02Id <> 4193 AND ANA.GIM02Id <> 38238 AND ANA .GIM02Id <> 37962 AND CPB.Estado<>'A')
                                                    SELECT @CantLecoq+@CantDistri As 'Cant. devoluciones Gestion'"
        Try
            Dim DT As New DataTable
            Dim DA As New SqlDataAdapter(ConsultaCantidadGestion, MyBase.CNS)
            DA.Fill(DT)
            R = DT.Rows(0).Item(0)
            DA.Dispose()
            DT.Dispose()
        Catch ex As SqlException
            MsgBox("ModeloGestion.ListaDevGestion" + vbCrLf + ex.Message)
            Return Nothing
        End Try
        Return R
    End Function
    Public Function DetalleDevolucion(ByRef ID_comp As Integer, ByRef distri_Lecoq As String) As DataTable
        Dim str = If(distri_Lecoq = "Distri", "GI_DN.DBO.", "GI_DN2.DBO.")
        Dim Consulta As String = "SELECT
                                        ITS.GIN02ID AS 'IDITM',
                                        /*LTRIM(RTRIM(ART.CodArt))+'-'+LTRIM(RTRIM(GIT521.CODDSC)) AS 'CODIGO-VARIANTE',*/
                                        LTRIM(RTRIM(ART.CodArt)) AS 'CODIGO',
                                        LTRIM(RTRIM(GIT521.CODDSC)) AS 'COD. ALTERNATIVA',
                                        LTRIM(RTRIM(GIT521.DESDSC)) AS 'ALTERNATIVA',
                                        LTRIM(RTRIM(ART.DesArt)) AS 'ARTICULO',
                                        /*LTRIM(RTRIM(ART.DesArt))+' - '+LTRIM(RTRIM(GIT521.DESDSC)) AS 'ARTICULO',*/
                                        ISNULL(GIT522.CODDSC,GIT521.CODDSC) AS 'TALLE',
                                        ITS.Cantid AS 'CANTIDAD',
                                        ITS.Observ AS 'OBSERVACIÓN'
                                        FROM " & str & "GIN02ITS AS ITS
                                        INNER JOIN " & str & "GIM21ART AS ART ON ART.GIM21Id=ITS.IdGIM21
                                        LEFT JOIN " & str & "GIT52DSC AS GIT521 ON ITS.IdGIT521=GIT521.GIT52Id
                                        LEFT JOIN " & str & "GIT52DSC AS GIT522 ON ITS.IdGIT522=GIT522.GIT52Id
                                        INNER JOIN " & str & "GIN01CPB AS CPB ON CPB.GIN01Id=ITS.IdGIN01O
                                        WHERE CPB.GIN01Id=" & ID_comp & "
                                        ORDER BY CPB.NumComO"
        Dim DT = New DataTable
        Try
            Dim CMD As New SqlCommand(Consulta, CNS)
            Dim DA = New SqlDataAdapter(CMD)
            DA.Fill(DT)
        Catch ex As SqlException
            MsgBox("ModeloGestion.DetalleDevolucion" + vbCrLf + ex.Message)
            Return Nothing
        End Try
        Return DT
    End Function
    Public Function DetalleDevolucion(ByRef ListaComprobantes As List(Of Integer), ByRef distri_Lecoq As String) As DataTable
        Dim DT As New DataTable
        'Dim DTAux As New DataTable
        For Each Comp As Integer In ListaComprobantes
            DT.Merge(DetalleDevolucion(Comp, distri_Lecoq))
        Next
        Return DT
    End Function
    Public Shared Function ConvertirCodigo(ByVal ITM As ItemDevolucion) As String
        Dim DBFArticulos = New ModeloDBF(My.Settings.CNSLince_UbicacionBDArt, My.Settings.CNSLince_BDArt)
        ITM.Articulo.CodLince = ITM.Articulo.CodGestion

        While IsMatch(Mid(ITM.Articulo.CodLince, Len(ITM.Articulo.CodLince) - 3, 4), "(-)|([-LIMN]{1,2}$)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            ITM.Articulo.CodLince = UltimoCaracter(ITM.Articulo.CodLince)
        End While
        If Not ITM.Articulo.CodLince.Contains("-") Then
            If Mid(ITM.Articulo.CodLince, 1, 1).ToUpper = "K" Then
                ITM.Articulo.CodLince = ITM.Articulo.CodLince.Insert(2, "-")
            ElseIf Mid(ITM.Articulo.CodLince, 1, 1).ToUpper = "S" Then
                ITM.Articulo.CodLince = ITM.Articulo.CodLince.Insert(1, "-")
                ITM.Articulo.CodLince = ITM.Articulo.CodLince.Insert(3, "-")
            Else
                ITM.Articulo.CodLince = ITM.Articulo.CodLince.Insert(1, "-")
            End If
        End If
        If IsMatch(Mid(ITM.Articulo.CodLince, 1, 1).ToUpper, "[C]-*") = True Then
            'ES CROCS
            'VERIFICO EXISTENCIA
            If DBFArticulos.buscarArticulo(ITM.Articulo.CodLince.ToUpper) = False Then
                ITM.Articulo.CodLince = Nothing
            End If
        ElseIf IsMatch(Mid(ITM.Articulo.CodLince, 1, 1).ToUpper, "[0-9]-*") = True Then
            'ES LECOQ
            If DBFArticulos.buscarArticulo(ITM.Articulo.CodLince.ToUpper) = False Then
                'CONCATENO CODIGO DE VARIANTE
                ITM.Articulo.CodLince = String.Concat(ITM.Articulo.CodLince, ITM.Alternativa.CodigoGestion)
                'VUELVO A VERIFICAR EXISTENCIA
                If DBFArticulos.buscarArticulo(ITM.Articulo.CodLince.ToUpper) = False Then
                    ITM.Articulo.CodLince = Nothing
                End If
            End If
        ElseIf IsMatch(Mid(ITM.Articulo.CodLince, 1, 5).ToUpper, "([S]-[0-9]-[S])") = True Then
            'ES SUPERGA
            If DBFArticulos.buscarArticulo(ITM.Articulo.CodLince.ToUpper) = False Then
                ITM.Articulo.CodLince = Nothing
            End If
        ElseIf IsMatch(Mid(ITM.Articulo.CodLince, 1, 5).ToUpper, "[K]-?-?-*") = True Then
            If (From c As Char In ITM.Articulo.CodLince Where c = "-" Select c).Count > 1 Then
                ITM.Articulo.CodLince = ITM.Articulo.CodLince.Remove(1, 1)
            End If
            If ITM.Articulo.CodLince.Length > 13 Then
                    ITM.Articulo.CodLince = ITM.Articulo.CodLince.Replace("-", "")
                End If
            If DBFArticulos.buscarArticulo(ITM.Articulo.CodLince.ToUpper) = False Then
                'CONCATENO CODIGO DE VARIANTE
                ITM.Articulo.CodLince = String.Concat(ITM.Articulo.CodLince, ITM.Alternativa.CodigoGestion)
                'VUELVO A VERIFICAR EXISTENCIA
                Dim ArtAux As String = ITM.Articulo.CodLince
                If ITM.Articulo.CodLince.Length > 13 Then
                    ITM.Articulo.CodLince = ITM.Articulo.CodLince.Replace("-", "")
                    If DBFArticulos.buscarArticulo(ITM.Articulo.CodLince.ToUpper) = False Then
                        ITM.Articulo.CodLince = Mid(ArtAux, 1, ArtAux.Length - 1)
                        If DBFArticulos.buscarArticulo(ITM.Articulo.CodLince.ToUpper) = False Then
                            ITM.Articulo.CodLince = Nothing
                        End If
                    End If
                Else
                    If DBFArticulos.buscarArticulo(ITM.Articulo.CodLince.ToUpper) = False Then
                        ITM.Articulo.CodLince = Nothing
                    End If
                End If
            End If
        End If
        Return ITM.Articulo.CodLince.ToUpper
    End Function
    Public Function ConvertirCodigosALince(ByRef id_comp As Integer, ByRef distri_Lecoq As String, ByVal Suc As Sucursal) As DataTable
        Dim DT As New DataTable
        DT = DetalleDevolucion(id_comp, distri_Lecoq)
        Dim PK(0) As DataColumn
        PK(0) = DT.Columns(0)
        DT.PrimaryKey = PK
        Try
            DT.Columns.Add(New DataColumn("CONVERTIDO", Type.GetType("System.Boolean")))
            Dim DBFArticulos = New ModeloDBF(My.Settings.CNSLince_UbicacionBDArt, My.Settings.CNSLince_BDArt)
            Dim ArtOriginal As String
            'ES CROCS
            Dim CROCS = (From p As DataRow In DT Select p Where p.Item("CODIGO") Like "C-*").ToList
            For Each fila As DataRow In CROCS
                ArtOriginal = fila.Item("CODIGO").ToString
                'ELIMINO IDENTIFICADOR INTERNO.
                While IsMatch(Mid(fila.Item("CODIGO").ToString, Len(fila.Item("CODIGO").ToString) - 3, 4), "(-)|([-LIMN]{1,2}$)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    fila.Item("CODIGO") = UltimoCaracter(fila.Item("CODIGO".ToString))
                    fila.Item("CODIGO") = fila.Item("CODIGO").ToString.Insert(1, "-")
                End While
                'VERIFICO EXISTENCIA
                If DBFArticulos.buscarArticulo(fila.Item("CODIGO").ToString.ToUpper) = False Then
                    fila.Item("CODIGO") = ArtOriginal
                    fila.Item("CONVERTIDO") = False
                Else
                    fila.Item("CONVERTIDO") = True
                End If
                'DT.Rows.Remove(DT.Rows.Find(fila.Item("IDITM")))
            Next
            'ES LECOQ
            Dim LECOQ = (From p As DataRow In DT Select p Where p.Item("CODIGO").ToString Like "[0-9]-*").ToList
            For Each fila As DataRow In LECOQ
                ArtOriginal = fila.Item("CODIGO").ToString
                'ELIMINO IDENTIFICADOR INTERNO.
                While IsMatch(Mid(fila.Item("CODIGO").ToString, Len(fila.Item("CODIGO").ToString) - 3, 4), "(-)|([-LIMN]{1,2}$)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    fila.Item("CODIGO") = UltimoCaracter(fila.Item("CODIGO").ToString)
                    fila.Item("CODIGO") = fila.Item("CODIGO").ToString.Insert(1, "-")
                End While
                'VERIFICO EXISTENCIA / *** MEJORAR DOBLE VERIFICACION *** VER REGEX (REGEXR.COM) *** /
                If DBFArticulos.buscarArticulo(fila.Item("CODIGO").ToString.ToUpper) = False Then
                    'CONCATENO CODIGO DE VARIANTE
                    fila.Item("CODIGO") = String.Concat(fila.Item("CODIGO"), fila.Item("VARIANTE"))
                    'VUELVO A VERIFICAR EXISTENCIA
                    If DBFArticulos.buscarArticulo(fila.Item("CODIGO").ToString.ToUpper) = False Then
                        fila.Item("CODIGO") = ArtOriginal
                        fila.Item("CONVERTIDO") = False
                    Else
                        fila.Item("CONVERTIDO") = True
                    End If
                Else
                    fila.Item("CONVERTIDO") = True
                End If
                'DT.Rows.Remove(DT.Rows.Find(fila.Item("IDITM")))
            Next
            'ES SUPERGA
            Dim SUPERGA = (From p As DataRow In DT Select p Where IsMatch(p.Item("CODIGO").ToString, "^([S-]+\d{1}[-S]+)\w*") = True).ToList
            For Each fila As DataRow In SUPERGA
                ArtOriginal = fila.Item("CODIGO").ToString
                'ELIMINO IDENTIFICADOR INTERNO.
                While IsMatch(Mid(fila.Item("CODIGO").ToString, Len(fila.Item("CODIGO").ToString) - 3, 4), "(-)|([-LIMN]{1,2}$)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    fila.Item("CODIGO") = UltimoCaracter(fila.Item("CODIGO").ToString)
                End While
                'VERIFICO EXISTENCIA
                If DBFArticulos.buscarArticulo(fila.Item("CODIGO").ToString.ToUpper) = False Then
                    fila.Item("CODIGO") = ArtOriginal
                    fila.Item("CONVERTIDO") = False
                Else
                    fila.Item("CONVERTIDO") = True
                End If
                'DT.Rows.Remove(DT.Rows.Find(fila.Item("IDITM")))
            Next
            'ES KAPPA
            'Dim KAPPA = (From p As DataRow In DT Select p Where IsMatch(p.Item("CODIGO").ToString, "^([K-]{2}\d{1}[-]{1})\w*") = True).ToList
            Dim KAPPA = (From p As DataRow In DT Select p Where p.Item("CODIGO").ToString Like "K-?-*" Or p.Item("CODIGO").ToString Like "k-?-*").ToList
            For Each fila As DataRow In KAPPA
                ArtOriginal = fila.Item("CODIGO").ToString
                'ELIMINO IDENTIFICADOR INTERNO.
                'While IsNumeric(Mid(fila.Item("CODIGO".ToString), Len(fila.Item("CODIGO".ToString)), 1)) = False
                '    fila.Item("CODIGO") = UltimoCaracter(fila.Item("CODIGO".ToString))
                'End While
                If IsMatch(Mid(fila.Item("CODIGO").ToString, Len(fila.Item("CODIGO").ToString) - 3, 4), "(-)|([-LIMN]{1,2}$)", System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then
                    For i = 1 To 3
                        fila.Item("CODIGO") = UltimoCaracter(fila.Item("CODIGO".ToString))
                    Next
                End If
                'ELIMINO PRIMER GUION
                fila.Item("CODIGO") = fila.Item("CODIGO").ToString.Remove(1, 1)
                'VERIFICO EXISTENCIA / *** MEJORAR DOBLE VERIFICACION *** VER REGEX (REGEXR.COM) *** /
                If DBFArticulos.buscarArticulo(fila.Item("CODIGO").ToString.ToUpper) = False Then
                    'CONCATENO CODIGO DE VARIANTE
                    fila.Item("CODIGO") = String.Concat(fila.Item("CODIGO"), fila.Item("VARIANTE"))
                    'VERIFICO EL LARGO
                    If Len(fila.Item("CODIGO")) > 13 Then
                        fila.Item("CODIGO") = fila.Item("CODIGO").ToString.Replace("-", "")
                        fila.Item("CODIGO") = fila.Item("CODIGO").ToString.Insert(1, "-")
                    End If
                    'VERIFICO EXISTENCIA (Otra vez)
                    If DBFArticulos.buscarArticulo(fila.Item("CODIGO").ToString.ToUpper) = False Then
                        fila.Item("CODIGO") = ArtOriginal
                        fila.Item("CONVERTIDO") = False
                    Else
                        fila.Item("CONVERTIDO") = True
                    End If
                Else
                    fila.Item("CONVERTIDO") = False
                End If
                'DT.Rows.Remove(DT.Rows.Find(fila.Item("IDITM")))
            Next
            If CROCS.Count > 0 Then
                DT.Merge(CROCS.CopyToDataTable)
            End If
            If SUPERGA.Count > 0 Then
                DT.Merge(SUPERGA.CopyToDataTable)
            End If
            If LECOQ.Count > 0 Then
                DT.Merge(LECOQ.CopyToDataTable)
            End If
            If KAPPA.Count > 0 Then
                DT.Merge(KAPPA.CopyToDataTable)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim x = New List(Of String)
        Return DT
    End Function
    Public Function ConvertirCodigosALince(ByRef id_comp As List(Of Integer), ByRef distri_Lecoq As String, ByVal Suc As Sucursal) As DataTable
        Dim DT As New DataTable
        DT = DetalleDevolucion(id_comp, distri_Lecoq)
        Dim PK(0) As DataColumn
        PK(0) = DT.Columns(0)
        DT.PrimaryKey = PK
        Try
            DT.Columns.Add(New DataColumn("CONVERTIDO", Type.GetType("System.Boolean")))
            Dim DBFArticulos = New ModeloDBF(My.Settings.CNSLince_UbicacionBDArt, My.Settings.CNSLince_BDArt)
            Dim ArtOriginal As String
            'ES CROCS
            Dim CROCS = (From p As DataRow In DT Select p Where p.Item("CODIGO") Like "C-*").ToList
            For Each fila As DataRow In CROCS
                ArtOriginal = fila.Item("CODIGO").ToString
                'ELIMINO IDENTIFICADOR INTERNO.
                While IsMatch(Mid(fila.Item("CODIGO").ToString, Len(fila.Item("CODIGO").ToString) - 3, 4), "(-)|([-LIMN]{1,2}$)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    fila.Item("CODIGO") = UltimoCaracter(fila.Item("CODIGO".ToString))
                    fila.Item("CODIGO") = fila.Item("CODIGO").ToString.Insert(1, "-")
                End While
                'VERIFICO EXISTENCIA
                If DBFArticulos.buscarArticulo(fila.Item("CODIGO").ToString.ToUpper) = False Then
                    fila.Item("CODIGO") = ArtOriginal
                    fila.Item("CONVERTIDO") = False
                Else
                    fila.Item("CONVERTIDO") = True
                End If
                'DT.Rows.Remove(DT.Rows.Find(fila.Item("IDITM")))
            Next
            'ES LECOQ
            Dim LECOQ = (From p As DataRow In DT Select p Where p.Item("CODIGO").ToString Like "[0-9]-*").ToList
            For Each fila As DataRow In LECOQ
                ArtOriginal = fila.Item("CODIGO").ToString
                'ELIMINO IDENTIFICADOR INTERNO.
                While IsMatch(Mid(fila.Item("CODIGO").ToString, Len(fila.Item("CODIGO").ToString) - 3, 4), "(-)|([-LIMN]{1,2}$)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    fila.Item("CODIGO") = UltimoCaracter(fila.Item("CODIGO").ToString)
                    fila.Item("CODIGO") = fila.Item("CODIGO").ToString.Insert(1, "-")
                End While
                'VERIFICO EXISTENCIA / *** MEJORAR DOBLE VERIFICACION *** VER REGEX (REGEXR.COM) *** /
                If DBFArticulos.buscarArticulo(fila.Item("CODIGO").ToString.ToUpper) = False Then
                    'CONCATENO CODIGO DE VARIANTE
                    fila.Item("CODIGO") = String.Concat(fila.Item("CODIGO"), fila.Item("VARIANTE"))
                    'VUELVO A VERIFICAR EXISTENCIA
                    If DBFArticulos.buscarArticulo(fila.Item("CODIGO").ToString.ToUpper) = False Then
                        fila.Item("CODIGO") = ArtOriginal
                        fila.Item("CONVERTIDO") = False
                    Else
                        fila.Item("CONVERTIDO") = True
                    End If
                Else
                    fila.Item("CONVERTIDO") = True
                End If
                'DT.Rows.Remove(DT.Rows.Find(fila.Item("IDITM")))
            Next
            'ES SUPERGA
            Dim SUPERGA = (From p As DataRow In DT Select p Where IsMatch(p.Item("CODIGO").ToString, "^([S-]+\d{1}[-S]+)\w*") = True).ToList
            For Each fila As DataRow In SUPERGA
                ArtOriginal = fila.Item("CODIGO").ToString
                'ELIMINO IDENTIFICADOR INTERNO.
                While IsMatch(Mid(fila.Item("CODIGO").ToString, Len(fila.Item("CODIGO").ToString) - 3, 4), "(-)|([-LIMN]{1,2}$)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    fila.Item("CODIGO") = UltimoCaracter(fila.Item("CODIGO").ToString)
                End While
                'VERIFICO EXISTENCIA
                If DBFArticulos.buscarArticulo(fila.Item("CODIGO").ToString.ToUpper) = False Then
                    fila.Item("CODIGO") = ArtOriginal
                    fila.Item("CONVERTIDO") = False
                Else
                    fila.Item("CONVERTIDO") = True
                End If
                'DT.Rows.Remove(DT.Rows.Find(fila.Item("IDITM")))
            Next
            'ES KAPPA
            'Dim KAPPA = (From p As DataRow In DT Select p Where IsMatch(p.Item("CODIGO").ToString, "^([K-]{2}\d{1}[-]{1})\w*") = True).ToList
            Dim KAPPA = (From p As DataRow In DT Select p Where p.Item("CODIGO").ToString Like "K-?-*" Or p.Item("CODIGO").ToString Like "k-?-*").ToList
            For Each fila As DataRow In KAPPA
                ArtOriginal = fila.Item("CODIGO").ToString
                'ELIMINO IDENTIFICADOR INTERNO.
                'While IsNumeric(Mid(fila.Item("CODIGO".ToString), Len(fila.Item("CODIGO".ToString)), 1)) = False
                '    fila.Item("CODIGO") = UltimoCaracter(fila.Item("CODIGO".ToString))
                'End While
                If IsMatch(Mid(fila.Item("CODIGO").ToString, Len(fila.Item("CODIGO").ToString) - 3, 4), "(-)|([-LIMN]{1,2}$)", System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then
                    For i = 1 To 3
                        fila.Item("CODIGO") = UltimoCaracter(fila.Item("CODIGO".ToString))
                    Next
                End If
                'ELIMINO PRIMER GUION
                fila.Item("CODIGO") = fila.Item("CODIGO").ToString.Remove(1, 1)
                'VERIFICO EXISTENCIA / *** MEJORAR DOBLE VERIFICACION *** VER REGEX (REGEXR.COM) *** /
                If DBFArticulos.buscarArticulo(fila.Item("CODIGO").ToString.ToUpper) = False Then
                    'CONCATENO CODIGO DE VARIANTE
                    fila.Item("CODIGO") = String.Concat(fila.Item("CODIGO"), fila.Item("VARIANTE"))
                    'VERIFICO EL LARGO
                    If Len(fila.Item("CODIGO")) > 13 Then
                        fila.Item("CODIGO") = fila.Item("CODIGO").ToString.Replace("-", "")
                        fila.Item("CODIGO") = fila.Item("CODIGO").ToString.Insert(1, "-")
                    End If
                    'VERIFICO EXISTENCIA (Otra vez)
                    If DBFArticulos.buscarArticulo(fila.Item("CODIGO").ToString.ToUpper) = False Then
                        fila.Item("CODIGO") = ArtOriginal
                        fila.Item("CONVERTIDO") = False
                    Else
                        fila.Item("CONVERTIDO") = True
                    End If
                Else
                    fila.Item("CONVERTIDO") = False
                End If
                'DT.Rows.Remove(DT.Rows.Find(fila.Item("IDITM")))
            Next
            If CROCS.Count > 0 Then
                DT.Merge(CROCS.CopyToDataTable)
            End If
            If SUPERGA.Count > 0 Then
                DT.Merge(SUPERGA.CopyToDataTable)
            End If
            If LECOQ.Count > 0 Then
                DT.Merge(LECOQ.CopyToDataTable)
            End If
            If KAPPA.Count > 0 Then
                DT.Merge(KAPPA.CopyToDataTable)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim x = New List(Of String)
        Return DT
    End Function
End Class
