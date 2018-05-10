Public Class Form1
    Dim active(5) As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Checkboxes()
        Calculate1d()
    End Sub
    Public Sub Checkboxes()
        For i As Integer = 0 To 5
            active(i) = False
        Next
        If TextBox1.Text <> "" And IsNumeric(TextBox1.Text) Then
            active(0) = True
        End If
        If TextBox2.Text <> "" And IsNumeric(TextBox2.Text) Then
            active(1) = True
        End If
        If TextBox3.Text <> "" And IsNumeric(TextBox3.Text) Then
            active(2) = True
        End If
        If TextBox4.Text <> "" And IsNumeric(TextBox4.Text) Then
            active(3) = True
        End If
        If TextBox5.Text <> "" And IsNumeric(TextBox5.Text) Then
            active(4) = True
        End If
        If TextBox6.Text <> "" And IsNumeric(TextBox6.Text) Then
            active(5) = True
        End If
    End Sub
    Private Sub Calculate1d()

    End Sub
End Class
