Public Class info
    Private _movie_name As String
    Private _url_image As String

    Public Sub New(ByVal movie_name As String, ByVal url_image As String)
        _movie_name = movie_name
        _url_image = url_image
    End Sub

    Public ReadOnly Property getMovie
        Get
            Return _movie_name
        End Get
    End Property

    Public ReadOnly Property getUrl
        Get
            Return _url_image
        End Get
    End Property

End Class
