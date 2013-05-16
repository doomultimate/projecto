Imports WindowsApplication1.internet_utils
Imports System.Net
Imports System.IO
Imports System.Drawing

Public Class Form1
    Dim posicao As sala
    'Friend WithEvents Button2 As System.Windows.Forms.Button

    Dim net_utils As internet_utils = New internet_utils()
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim listaFilmes As New List(Of info)

        If net_utils.IsOnline Then
            listaFilmes = net_utils.getMovies(ComboBox1.Text)
        Else
            MsgBox("ligue a net")
        End If

        'http://www.vbforums.com/showthread.php?387841-Display-image-from-internet-in-a-Picturebox


        Dim imageData() As Byte = New System.Net.WebClient().DownloadData(listaFilmes.Item(0).getUrl)


        Dim stream As New IO.MemoryStream(imageData)
        PictureBox1.Image = New System.Drawing.Bitmap(stream)


        posicao = New sala(Me.Controls)

    End Sub



    'Public Sub New()

    '    Dim padding As Integer = 55
    '    Dim paddingY As Integer = 30

    '    InitializeComponent()
    '    For i = 1 To 10
    '        For j = 1 To 10


    '            Me.Button2 = New System.Windows.Forms.Button()
    '            Me.Button2.Location = New System.Drawing.Point(25 + i * padding, 400 + j * paddingY)
    '            Me.Button2.Name = "Button" & i & "-" & j
    '            Me.Button2.Size = New System.Drawing.Size(50, 25)
    '            Me.Button2.TabIndex = 3
    '            Me.Button2.Text = "f " & i & "-" & j
    '            Me.Button2.BackColor = Color.Green
    '            AddHandler Button2.Click, AddressOf mudacor  'Obrigatório
    '            Me.Controls.Add(Button2)
    '            Button2.Visible = True

    '        Next
    '    Next
    'End Sub

    'Dim nlugar As Integer

    'Private Sub mudacor(lugar As Object, e As EventArgs)
    '    'MsgBox(lugar.Name)

    '    If lugar.BackColor = Color.Red Then
    '        lugar.BackColor = Color.Green
    '        nlugar = nlugar - 1
    '    Else
    '        lugar.BackColor = Color.Red
    '        nlugar = nlugar + 1
    '    End If
    '    TextBox1.Text = nlugar
    'End Sub
End Class
