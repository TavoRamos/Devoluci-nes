Public Class Devolucion
    Inherits ModeloDevoluciones
    Public Sub New()
        MyBase.New()
    End Sub
    Public Function CalcularDiferencias(ByRef DevGestion As DataTable, ByRef DevSucursal As DataTable, ByRef suc As Sucursal) As List(Of ItemDevolucion)
        Dim RESULTADO = New List(Of ItemDevolucion)
        Dim ListaGes = New List(Of ItemDevolucion)
        Dim ListaSuc = New List(Of ItemDevolucion)
        Dim ArtAux = New ArticuloGenerico()
        Dim TalAux = New Talle()
        Dim AltAux = New Alternativa()
        Try
            '---------------------- GENERO LISTA DESDE GESTION Y AGRUPO LOS Articulos Por Codigo, alernativa y talle
            For Each Fila As DataRow In DevGestion.Rows
                If Not IsNothing(BuscarArticulo(Trim(Fila.Item("CODIGO")))) Then
                    ArtAux = BuscarArticulo(Trim(Fila.Item("CODIGO")))
                Else
                    ArtAux = New ArticuloGenerico(Nothing, Nothing, Trim(Fila.Item("CODIGO")), Nothing, Fila.Item("ARTICULO"), Nothing)
                End If
                If Not IsNothing(BuscarTalle(Trim(Fila.Item("TALLE")))) Then
                    TalAux = BuscarTalle(Trim(Fila.Item("TALLE")))
                Else
                    TalAux = New Talle(Nothing, Nothing, Nothing, Trim(Fila.Item("TALLE")), Nothing)
                End If
                If Not IsNothing(BuscarAlternativa(Trim(Fila.Item("COD. ALTERNATIVA")))) Then
                    AltAux = BuscarAlternativa(Trim(Fila.Item("COD. ALTERNATIVA")))
                Else
                    AltAux = New Alternativa(Trim(Fila.Item("COD. ALTERNATIVA")), Nothing, Nothing, Fila.Item("ALTERNATIVA"))
                End If

                If ListaGes.Exists(Function(P As ItemDevolucion) P.Articulo.CodGestion.Equals((ArtAux.CodGestion)) And P.Alternativa.CodigoGestion.Equals(AltAux.CodigoGestion) And P.Talle.CodigoGestion.Equals(TalAux.CodigoGestion)) Then
                    ListaGes.Find(Function(P As ItemDevolucion) P.Articulo.CodGestion.Equals((ArtAux.CodGestion)) And P.Alternativa.CodigoGestion.Equals(AltAux.CodigoGestion) And P.Talle.CodigoGestion.Equals(TalAux.CodigoGestion)).Cantidad += Fila.Item("Cantidad")
                Else
                    ListaGes.Add(New ItemDevolucion(ArtAux, AltAux, TalAux, Fila.Item("CANTIDAD")))
                End If
            Next
            '---------------------- GENERO LISTA DESDE LINCE Y AGRUPO LOS Articulos Por Codigo y talle
            For Each Fila As DataRow In DevSucursal.Rows
                If Not IsNothing(BuscarArticulo(Trim(Fila.Item("codigo")))) Then
                    ArtAux = BuscarArticulo(Trim(Fila.Item("codigo")))
                Else
                    If suc.TieneLince Then
                        ArtAux = New ArticuloGenerico(Trim(Fila.Item("codigo")), Nothing, Nothing, Nothing, Fila.Item("ARTICULO"), Nothing)
                    Else
                        ArtAux = New ArticuloGenerico(Nothing, Trim(Fila.Item("codigo")), Nothing, Nothing, Fila.Item("ARTICULO"), Nothing)
                    End If
                End If
                If Not IsNothing(BuscarTalle(Trim(Fila.Item("talle")))) Then
                    TalAux = BuscarTalle(Trim(Fila.Item("talle")))
                Else
                    If suc.TieneLince Then
                        TalAux = New Talle(Nothing, Trim(Fila.Item("talle")), Nothing, Nothing, Nothing)
                    Else
                        TalAux = New Talle(Nothing, Nothing, Trim(Fila.Item("talle")), Nothing, Nothing)
                    End If
                End If
                If Fila.Table.Columns.Contains("COD. ALTERNATIVA") Then
                    If Not IsNothing(BuscarAlternativa(Trim(Fila.Item("COD. ALTERNATIVA")))) Then
                        AltAux = BuscarAlternativa(Trim(Fila.Item("COD. ALTERNATIVA")))
                    Else
                        If suc.TieneLince = False Then
                            AltAux = New Alternativa(Nothing, Trim(Fila.Item("COD. ALTERNATIVA")), Nothing, Fila.Item("ALTERNATIVA"))
                        End If
                    End If
                Else
                    AltAux = New Alternativa()
                End If
                If suc.TieneLince Then
                    If ListaSuc.Exists(Function(P As ItemDevolucion) P.Articulo.CodLince.Equals(ArtAux.CodLince) And P.Talle.CodigoLince.Equals(TalAux.CodigoLince)) Then
                        ListaSuc.Find(Function(P As ItemDevolucion) P.Articulo.CodLince.Equals(ArtAux.CodLince) And P.Talle.CodigoLince.Equals(TalAux.CodigoLince)).Cantidad += Fila.Item("cantidad")
                    Else
                        ListaSuc.Add(New ItemDevolucion(ArtAux, AltAux, TalAux, Fila.Item("cantidad")))
                    End If
                Else
                    If ListaSuc.Exists(Function(P As ItemDevolucion) P.Articulo.CodDragon.Equals(ArtAux.CodDragon) And P.Alternativa.CodigoDragon.Equals(AltAux.CodigoDragon) And P.Talle.CodigoDragon.Equals(TalAux.CodigoDragon)) Then
                        ListaSuc.Find(Function(P As ItemDevolucion) P.Articulo.CodDragon.Equals(ArtAux.CodDragon) And P.Alternativa.CodigoDragon.Equals(AltAux.CodigoDragon) And P.Talle.CodigoDragon.Equals(TalAux.CodigoDragon)).Cantidad += Fila.Item("cantidad")
                    Else
                        ListaSuc.Add(New ItemDevolucion(ArtAux, AltAux, TalAux, Fila.Item("cantidad")))
                    End If
                End If
            Next
            '---------------------- COMPLETO CODIGOS DE LINCE EN LISTA GESTION
            For Each Item As ItemDevolucion In ListaGes
                If String.IsNullOrWhiteSpace(Item.Articulo.CodLince) Then
                    Item.Articulo.CodLince = ModeloGestion.ConvertirCodigo(Item)
                End If
                If suc.TieneLince Then
                    If Not ListaSuc.Exists(Function(P As ItemDevolucion) P.Articulo.CodLince = Item.Articulo.CodLince And P.Talle.CodigoLince = Item.Talle.CodigoLince And P.Cantidad = Item.Cantidad) Then
                        RESULTADO.Add(Item)
                    End If

                Else
                    If Not ListaSuc.Exists(Function(P As ItemDevolucion) P.Articulo.CodDragon = Item.Articulo.CodDragon And P.Talle.CodigoDragon = Item.Talle.CodigoDragon And P.Cantidad = Item.Cantidad) Then
                        RESULTADO.Add(Item)
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("Devolucion.CalcularDiferencias" + vbCrLf + ex.Message)
            Return Nothing
        End Try
        Return RESULTADO
    End Function
End Class
