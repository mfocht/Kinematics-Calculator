Imports System.ComponentModel

Public Class Form2
    Dim active2(10) As Boolean
    Dim data2(10) As String
    Dim empty As Boolean = True
    Dim done As Boolean = True
    Dim times As Integer = 0
    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Checkboxes()
        done = True
        RunCalculations()
        Output()
        times = 0
    End Sub
    Public Sub Checkboxes()
        For i As Integer = 0 To 10
            active2(i) = False
            data2(i) = ""
        Next
        empty = True
        If TextBox1.Text <> "" And IsNumeric(TextBox1.Text) Then
            active2(0) = True
            data2(0) = TextBox1.Text
        End If
        If TextBox2.Text <> "" And IsNumeric(TextBox2.Text) Then
            active2(1) = True
            data2(1) = TextBox2.Text
        End If
        If TextBox3.Text <> "" And IsNumeric(TextBox3.Text) Then
            active2(2) = True
            data2(2) = TextBox3.Text
        End If
        If TextBox4.Text <> "" And IsNumeric(TextBox4.Text) Then
            active2(3) = True
            data2(3) = TextBox4.Text
        End If
        If TextBox5.Text <> "" And IsNumeric(TextBox5.Text) Then
            active2(4) = True
            data2(4) = TextBox5.Text
        End If
        If TextBox6.Text <> "" And IsNumeric(TextBox6.Text) Then
            active2(5) = True
            data2(5) = TextBox6.Text
        End If
        If TextBox11.Text <> "" And IsNumeric(TextBox11.Text) Then
            active2(6) = True
            data2(6) = TextBox11.Text
        End If
        If TextBox10.Text <> "" And IsNumeric(TextBox10.Text) Then
            active2(7) = True
            data2(7) = TextBox10.Text
        End If
        If TextBox9.Text <> "" And IsNumeric(TextBox9.Text) Then
            active2(8) = True
            data2(8) = TextBox9.Text
        End If
        If TextBox8.Text <> "" And IsNumeric(TextBox8.Text) Then
            active2(9) = True
            data2(9) = TextBox8.Text
        End If
        If TextBox7.Text <> "" And IsNumeric(TextBox7.Text) Then
            active2(10) = True
            data2(10) = TextBox7.Text
        End If
        For i As Integer = 0 To 5
            If active2(i) = True Then
                empty = False
            End If
        Next
        If Empty = True Then
            MsgBox("Please enter more values.")
        End If
    End Sub
    Private Sub RunCalculations()
        While done = True
            done = False
            If active2(3) = False Then
                Calculatex()
            End If
            If active2(5) = False Then
                Calculatetime()
            End If
            If active2(4) = False Then
                Calculateinitialx()
            End If
            If active2(2) = False Then
                Calculateacceleration()
            End If
            If active2(0) = False Then
                Calculatevelocity()
            End If
            If active2(1) = False Then
                Calculateinitialvelocity()
            End If
            If active2(6) = False Then
                Calculatevelocityy()
            End If
            If active2(7) = False Then
                Calculateinitialvelocityy()
            End If
            If active2(8) = False Then
                Calculateaccelerationy()
            End If
            If active2(9) = False Then
                Calculatey()
            End If
            If active2(10) = False Then
                Calculateinitialy()
            End If
            For i As Integer = 0 To 10
                If active2(i) = False Then
                    done = True
                End If
            Next
            times += 1
            If times > 30 Then
                MsgBox("Error, I cannot calculate that with the data entered.")
                done = False
                times = 0
                For i As Integer = 0 To 5
                    active2(i) = False
                Next
            End If
        End While

    End Sub
    Private Sub Calculateacceleration()
        If active2(0) = True And active2(1) = True And active2(5) = True Then
            data2(2) = (data2(0) - data2(1)) / data2(5)
            active2(2) = True
        ElseIf active2(1) = True And active2(3) = True And active2(4) = True And active2(5) = True Then
            data2(2) = ((data2(3) - data2(4) - (data2(1) * data2(5))) / (data2(5) * data2(5)))
            active2(2) = True
        ElseIf active2(0) = True And active2(1) = True And active2(3) = True And active2(4) = True Then
            data2(2) = (((data2(0) * data2(0)) - (data2(1) * data2(1))) / (2 * (data2(3) - data2(4))))
            active2(2) = True
        End If
    End Sub
    Private Sub Calculateaccelerationy()
        If active2(6) = True And active2(7) = True And active2(5) = True Then
            data2(8) = (data2(6) - data2(7)) / data2(5)
            active2(8) = True
        ElseIf active2(7) = True And active2(9) = True And active2(10) = True And active2(5) = True Then
            data2(8) = ((data2(9) - data2(10) - (data2(7) * data2(5))) / (data2(5) * data2(5)))
            active2(8) = True
        ElseIf active2(0) = True And active2(7) = True And active2(9) = True And active2(10) = True Then
            data2(8) = (((data2(6) * data2(6)) - (data2(7) * data2(7))) / (2 * (data2(9) - data2(10))))
            active2(8) = True
        End If
    End Sub
    Private Sub Calculatevelocity()
        If active2(1) = True And active2(5) = True And active2(2) = True Then
            data2(0) = data2(1) + data2(2) * data2(5)
            active2(0) = True
        ElseIf active2(1) = True And active2(2) = True And active2(3) = True And active2(4) = True Then
            data2(0) = Math.Sqrt(data2(1) * data2(1) + (2 * data2(2) * (data2(3) - data2(4))))
            active2(0) = True
        End If
    End Sub
    Private Sub Calculateinitialx()
        If active2(3) = True And active2(1) = True And active2(5) = True And active2(2) = True Then
            data2(4) = data2(3) - (data2(1) * data2(5)) + (0.5 * data2(5) * data2(5) * data2(2))
            active2(4) = True
        ElseIf active2(0) = True And active2(1) = True And active2(2) = True And active2(3) = True Then
            data2(4) = (((data2(0) * data2(0)) - (data2(1) * data2(1))) / (2 * data2(2)))
            active2(4) = True
        End If
    End Sub
    Private Sub Calculateinitialvelocity()
        If active2(0) = True And active2(2) = True And active2(5) = True Then
            data2(1) = data2(0) - data2(2) * data2(5)
            active2(1) = True
        ElseIf active2(0) = True And active2(2) = True And active2(3) = True And active2(4) = True Then
            data2(1) = Math.Sqrt(data2(0) * data2(0) - (2 * data2(2) * (data2(3) - data2(4))))
            active2(1) = True
        End If
    End Sub
    Private Sub Calculatex()
        If active2(0) = False And active2(4) = True And active2(1) = True And active2(2) = True And active2(5) = True Or active2(1) = True And active2(4) = True And active2(2) = True And active2(5) = True Then
            data2(3) = data2(4) + (data2(1) * data2(5)) + (0.5 * data2(2) * data2(5) * data2(5))
            active2(3) = True
        ElseIf active2(5) = False And active2(0) = True And active2(1) = True And active2(2) = True And active2(4) = True Then
            data2(3) = ((data2(0) * data2(0) - data2(1) * data2(1)) * 0.5) / data2(2) + data2(4)
            active2(3) = True
        End If
    End Sub
    Private Sub Calculatevelocityy()
        If active2(7) = True And active2(5) = True And active2(8) = True Then
            data2(6) = data2(7) + data2(8) * data2(5)
            active2(6) = True
        ElseIf active2(7) = True And active2(8) = True And active2(9) = True And active2(10) = True Then
            data2(6) = Math.Sqrt(data2(7) * data2(7) + (2 * data2(8) * (data2(9) - data2(10))))
            active2(6) = True
        End If
    End Sub
    Private Sub Calculateinitialy()
        If active2(9) = True And active2(7) = True And active2(5) = True And active2(8) = True Then
            data2(10) = data2(9) - (data2(7) * data2(5)) + (0.5 * data2(5) * data2(5) * data2(8))
            active2(4) = True
        ElseIf active2(6) = True And active2(7) = True And active2(8) = True And active2(9) = True Then
            data2(10) = (((data2(6) * data2(6)) - (data2(7) * data2(7))) / (2 * data2(8)))
            active2(10) = True
        End If
    End Sub
    Private Sub Calculateinitialvelocityy()
        If active2(6) = True And active2(8) = True And active2(5) = True Then
            data2(7) = data2(6) - data2(8) * data2(5)
            active2(7) = True
        ElseIf active2(6) = True And active2(8) = True And active2(9) = True And active2(10) = True Then
            data2(7) = Math.Sqrt(data2(6) * data2(6) - (2 * data2(8) * (data2(9) - data2(10))))
            active2(7) = True
        End If
    End Sub
    Private Sub Calculatey()
        If active2(6) = False And active2(10) = True And active2(7) = True And active2(8) = True And active2(5) = True Or active2(7) = True And active2(10) = True And active2(8) = True And active2(5) = True Then
            data2(9) = data2(10) + (data2(7) * data2(5)) + (0.5 * data2(8) * data2(5) * data2(5))
            active2(9) = True
        ElseIf active2(5) = False And active2(6) = True And active2(7) = True And active2(8) = True And active2(10) = True Then
            data2(9) = ((data2(6) * data2(6) - data2(7) * data2(7)) * 0.5) / data2(8) + data2(10)
            active2(9) = True
        End If
    End Sub
    Private Sub Calculatetime()
        If active2(0) = True And active2(1) = True And active2(2) = True And data2(2) <> 0 Then
            active2(5) = True
            data2(5) = (data2(0) - data2(1)) / data2(2)
        ElseIf active2(6) = True And active2(7) = True And active2(8) = True And data2(8) <> 0 Then
            active2(5) = True
            data2(5) = (data2(6) - data2(7)) / data2(8)
        ElseIf active2(1) = True And active2(3) = True And active2(4) = True And data2(2) = 0 Then
            data2(5) = (data2(3) - data2(4)) / data2(1)
            active2(5) = True
        ElseIf active2(7) = True And active2(9) = True And active2(10) = True And data2(8) = 0 Then
            data2(5) = (data2(9) - data2(10)) / data2(7)
            active2(5) = True
        End If
    End Sub
    Private Sub Output()
        velocitylabel.Text = data2(0)
        ivelocitylabel.Text = data2(1)
        accelerationlabel.Text = data2(2)
        xlabel.Text = data2(3)
        xinitiallabel.Text = data2(4)
        timelabel.Text = data2(5)
        velocitylabely.Text = data2(6)
        initialvelocitylabely.Text = data2(7)
        accelerationy.Text = data2(8)
        ylabel.Text = data2(9)
        initialy.Text = data2(10)
    End Sub
End Class