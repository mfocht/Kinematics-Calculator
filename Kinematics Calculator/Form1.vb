﻿Public Class Form1
    Dim active(5) As Boolean
    Dim data(5) As String
    Dim empty As Boolean = True
    Dim done As Boolean = True
    Dim times As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Checkboxes()
        done = True
        RunCalculations()
        Output()
        times = 0
    End Sub
    Public Sub Checkboxes()
        For i As Integer = 0 To 5
            active(i) = False
            data(i) = ""
            empty = True
        Next
        If TextBox1.Text <> "" And IsNumeric(TextBox1.Text) Then
            active(0) = True
            data(0) = TextBox1.Text
        End If
        If TextBox2.Text <> "" And IsNumeric(TextBox2.Text) Then
            active(1) = True
            data(1) = TextBox2.Text
        End If
        If TextBox3.Text <> "" And IsNumeric(TextBox3.Text) Then
            active(2) = True
            data(2) = TextBox3.Text
        End If
        If TextBox4.Text <> "" And IsNumeric(TextBox4.Text) Then
            active(3) = True
            data(3) = TextBox4.Text
        End If
        If TextBox5.Text <> "" And IsNumeric(TextBox5.Text) Then
            active(4) = True
            data(4) = TextBox5.Text
        End If
        If TextBox6.Text <> "" And IsNumeric(TextBox6.Text) Then
            active(5) = True
            data(5) = TextBox6.Text
        End If
        For i As Integer = 0 To 5
            If active(i) = True Then
                empty = False
            End If
        Next
        If empty = True Then
            MsgBox("Please enter more values.")
        End If
    End Sub
    Private Sub RunCalculations()
        While done = True
            done = False
            If active(3) = False Then
                Calculatex()
            End If
            If active(5) = False Then
                Calculatetime()
            End If
            If active(4) = False Then
                Calculateinitialx()
            End If
            If active(2) = False Then
                Calculateacceleration()
            End If
            If active(0) = False Then
                Calculatevelocity()
            End If
            If active(1) = False Then
                Calculateinitialvelocity()
            End If
            For i As Integer = 0 To 5
                If active(i) = False Then
                    done = True
                End If
            Next
            times += 1
            If times > 30 Then
                MsgBox("Error, I cannot calculate that with the data entered.")
                done = False
                times = 0
                For i As Integer = 0 To 5
                    active(i) = False
                Next
            End If
        End While
    End Sub
    Private Sub Calculateacceleration()
        If active(0) = True And active(1) = True And active(5) = True Then
            data(2) = (data(0) - data(1)) / data(5)
            active(2) = True
        ElseIf active(1) = True And active(3) = True And active(4) = True And active(5) = True Then
            data(2) = ((data(3) - data(4) - (data(1) * data(5))) / (data(5) * data(5)))
            active(2) = True
        ElseIf active(0) = True And active(1) = True And active(3) = True And active(4) = True Then
            data(2) = (((data(0) * data(0)) - (data(1) * data(1))) / (2 * (data(3) - data(4))))
            active(2) = True
        End If
    End Sub
    Private Sub Calculatevelocity()
        If active(1) = True And active(5) = True And active(2) = True Then
            data(0) = data(1) + data(2) * data(5)
            active(0) = True
        ElseIf active(1) = True And active(2) = True And active(3) = True And active(4) = True Then
            data(0) = Math.Sqrt(data(1) * data(1) + (2 * data(2) * (data(3) - data(4))))
            active(0) = True
        End If
    End Sub
    Private Sub Calculateinitialx()
        If active(3) = True And active(1) = True And active(5) = True And active(2) = True Then
            data(4) = data(3) - (data(1) * data(5)) + (0.5 * data(5) * data(5) * data(2))
            active(4) = True
        ElseIf active(0) = True And active(1) = True And active(2) = True And active(3) = True Then
            data(4) = (((data(0) * data(0)) - (data(1) * data(1))) / (2 * data(2)))
            active(4) = True
        End If
    End Sub
    Private Sub Calculateinitialvelocity()
        If active(0) = True And active(2) = True And active(5) = True Then
            data(1) = data(0) - data(2) * data(5)
            active(1) = True
        ElseIf active(0) = True And active(2) = True And active(3) = True And active(4) = True Then
            data(1) = Math.Sqrt(data(0) * data(0) - (2 * data(2) * (data(3) - data(4))))
            active(1) = True
        End If
    End Sub
    Private Sub Calculatex()
        If active(0) = False And active(4) = True And active(1) = True And active(2) = True And active(5) = True Or active(1) = True And active(4) = True And active(2) = True And active(5) = True Then
            data(3) = data(4) + (data(1) * data(5)) + (0.5 * data(2) * data(5) * data(5))
            active(3) = True
        ElseIf active(5) = False And active(0) = True And active(1) = True And active(2) = True And active(4) = True Then
            data(3) = ((data(0) * data(0) - data(1) * data(1)) * 0.5) / data(2) + data(4)
            active(3) = True
        End If
    End Sub
    Private Sub Calculatetime()
        If active(0) = True And active(1) = True And active(2) = True And data(2) <> 0 Then
            active(5) = True
            data(5) = (data(0) - data(1)) / data(2)
        ElseIf active(1) = True And active(3) = True And active(4) = True And data(2) = 0 Then
            data(5) = (data(3) - data(4)) / data(1)
            active(5) = True
        End If
    End Sub
    Private Sub Output()
        velocitylabel.Text = data(0)
        ivelocitylabel.Text = data(1)
        accelerationlabel.Text = data(2)
        xlabel.Text = data(3)
        xinitiallabel.Text = data(4)
        timelabel.Text = data(5)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Show()
        Me.Hide()
    End Sub
End Class