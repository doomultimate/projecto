Imports System.Drawing

Public Class sala

    Friend WithEvents Button2 As System.Windows.Forms.Button
    Private _controlCollection As Control.ControlCollection

    Sub New(controlCollection As Control.ControlCollection)

        _controlCollection = controlCollection
        InitializeComponent()

    End Sub

    Private Sub InitializeComponent()
        Dim padding As Integer = 55
        Dim paddingY As Integer = 30

        For i = 1 To 10
            For j = 1 To 10

                Me.Button2 = New System.Windows.Forms.Button()
                Me.Button2.Location = New System.Drawing.Point(25 + i * padding, 400 + j * paddingY)
                Me.Button2.Name = "Button" & i & "-" & j
                Me.Button2.Size = New System.Drawing.Size(50, 25)
                Me.Button2.TabIndex = 3
                Me.Button2.Text = "f " & i & "-" & j
                Me.Button2.BackColor = Color.Green
                AddHandler Button2.Click, AddressOf mudacor  'Obrigatório
                _controlCollection.Add(Button2)
                Button2.Visible = True

            Next
        Next
    End Sub

    Dim nlugar As Integer

    Private Sub mudacor(lugar As Object, e As EventArgs)
        'MsgBox(lugar.Name)

        If lugar.BackColor = Color.Red Then
            lugar.BackColor = Color.Green
            nlugar = nlugar - 1
        Else
            lugar.BackColor = Color.Red
            nlugar = nlugar + 1
        End If
    End Sub
End Class
