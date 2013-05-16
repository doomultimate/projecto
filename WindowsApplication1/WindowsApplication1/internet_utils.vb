Imports System.IO
Imports HtmlAgilityPack
Imports System.Net
Imports System.Net.Sockets
Imports WindowsApplication1.string_utils

Public Class internet_utils

    Public Function getMovies(ByVal title As String) As List(Of info)
        Dim listMovies As New List(Of info)
        Dim movieTitle As String
        Dim movieImageUrl As String
        Dim string_util As string_utils = New string_utils
        Dim url As String = "http://www.imdb.com/find?q=" & title & "&s=all"

        Dim sourceString As String = New WebClient().DownloadString(url)

        Dim document As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
        document.LoadHtml(sourceString)


        'Este loop encontra a tabela dos filmes através do código XPath(retirado com o firebug)
        For Each node As HtmlNode In document.DocumentNode.SelectNodes("/html/body/div/div/div[4]/div[3]/div/div/div[2]/table")

            For Each elemento As HtmlNode In node.SelectNodes("tr")

                For Each titulos As HtmlNode In elemento.SelectNodes("td")
                    'MsgBox(elemento2.InnerText)
                    If (String.IsNullOrEmpty(titulos.InnerText) <> True) Then
                        movieTitle = titulos.InnerText
                    End If

                    For Each links As HtmlNode In titulos.SelectNodes("a")

                        Dim imagem As List(Of HtmlNode) = links.Elements("img").ToList()

                        If (imagem.Count > 0) Then
                            For Each item As HtmlNode In imagem
                                'MsgBox(item.GetAttributeValue("src", String.Empty))
                                movieImageUrl = item.GetAttributeValue("src", String.Empty)
                            Next
                        End If
                    Next
                Next
                listMovies.Add(New info(movieTitle, movieImageUrl))
            Next
        Next


        Return listMovies
    End Function



    Public Function IsOnline() As Boolean
        Try
            Dim dummy As IPHostEntry = Dns.GetHostEntry("www.google.com")
            Return True
        Catch ex As SocketException
            Return False
        End Try
    End Function

End Class
