Imports System.Text.RegularExpressions.Regex
Module Herramientas
    Function UltimoCaracter(ByRef Codigo As String)
        If Codigo.Contains("-") Then
            Codigo = Codigo.Replace("-", "")
        End If
        If IsNumeric(Mid(Codigo, Len(Codigo), 1)) = False Then
            Codigo = Mid(Codigo, 1, Len(Codigo) - 1)
        End If
        Return Codigo
    End Function
    Public Sub RemoveDuplicates(table As DataTable, keyColumns As List(Of String))
        Dim uniquenessDict As New Dictionary(Of String, String)(table.Rows.Count)
        Dim sb As System.Text.StringBuilder = Nothing
        Dim rowIndex As Integer = 0
        Dim row As DataRow
        Dim rows As DataRowCollection = table.Rows
        While rowIndex < rows.Count
            row = rows(rowIndex)
            sb = New System.Text.StringBuilder()
            For Each colname As String In keyColumns
                sb.Append(DirectCast(row(colname), String))
            Next

            If uniquenessDict.ContainsKey(sb.ToString()) Then
                rows.Remove(row)
            Else
                uniquenessDict.Add(sb.ToString(), String.Empty)
                rowIndex += 1
            End If
        End While
    End Sub

End Module
