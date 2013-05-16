Public Class string_utils

    Public Sub removeBlanks(ByVal listMovies As List(Of String))
        'retirar espaço em branco
        For Each movie_title As String In listMovies
            If String.IsNullOrEmpty(movie_title) Then
                listMovies.Remove(movie_title)
            End If
        Next
    End Sub
End Class
