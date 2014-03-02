Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim forma As Form2 = New Form2 With {.no = 1}
        forma.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim formb As Form2 = New Form2 With {.no = 2}
        formb.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim formc As Form2 = New Form2 With {.no = 3}
        formc.Show()
    End Sub
End Class
