Public Class Form2
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenFileDialog1.Filter = "jpg|*.jpg|bitmap|*.bmp"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim r2, g2, b2 As Integer
        Dim r1, g1, b1 As Integer
        Dim r3, g3, b3 As Integer
        Dim r4, g4, b4 As Integer
        ProgressBar1.Value = 0
        Dim matA As Integer = CInt(TextBox1.Text)
        Dim matB As Integer = CInt(TextBox2.Text)
        Dim matC As Integer = CInt(TextBox3.Text)
        Dim matD As Integer = CInt(TextBox4.Text)

        If (matA * matD) - (matB * matC) <> 1 Then
            MessageBox.Show("Nilai Determinan Matriks harus = 1")
            GoTo skip

        End If
        matA = CInt(TextBox4.Text)
        matB = 256 - CInt(TextBox2.Text)
        matC = 256 - CInt(TextBox3.Text)
        matD = CInt(TextBox4.Text)
        Dim gambar As New Bitmap(PictureBox1.Image)
        Dim gambar2 = gambar
        PictureBox2.Image = gambar2
        ProgressBar1.Maximum = gambar.Width

        For i As Integer = 1 To gambar.Width - 2
            For j As Integer = 1 To gambar.Height - 2

                If j Mod 2 = 1 Then
                    r1 = gambar.GetPixel(i, j).R
                    g1 = gambar.GetPixel(i, j).G
                    b1 = gambar.GetPixel(i, j).B

                    r2 = gambar.GetPixel(i, j + 1).R
                    g2 = gambar.GetPixel(i, j + 1).G
                    b2 = gambar.GetPixel(i, j + 1).B

                    r3 = ((r1 * matA) + (r2 * matC)) Mod 256
                    r4 = ((r1 * matB) + (r2 * matD)) Mod 256

                    g3 = ((g1 * matA) + (g2 * matC)) Mod 256
                    g4 = ((g1 * matB) + (g2 * matD)) Mod 256

                    b3 = ((b1 * matA) + (b2 * matC)) Mod 256
                    b4 = ((b1 * matB) + (b2 * matD)) Mod 256

                    gambar2.SetPixel(i, j, Color.FromArgb(r3, g3, b3))
                    gambar2.SetPixel(i, j + 1, Color.FromArgb(r4, g4, b4))


                End If

            Next
            ProgressBar1.Value = ProgressBar1.Value + 1
        Next
skip:
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveFileDialog1.Filter = "jpg|*.jpg|bitmap|*.bmp"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox2.Image.Save(SaveFileDialog1.FileName)
            'PictureBox1.Image.Dispose()
            'PictureBox2.Image.Dispose()
            'System.IO.File.Delete(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Form2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim frm As New Form1
        frm.Show()
    End Sub
End Class
