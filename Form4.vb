Public Class Form4
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenFileDialog1.Filter = "jpg|*.jpg|bitmap|*.bmp"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        OpenFileDialog1.Filter = "jpg|*.jpg|bitmap|*.bmp"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Form4_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim frm As New Form1
        frm.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim r1, g1, b1 As Integer
        Dim r2, g2, b2 As Integer

        Dim gambar1 As New Bitmap(PictureBox1.Image)
        Dim gambar2 As New Bitmap(PictureBox2.Image)
        Dim maxNumber As Integer = 0

        Dim MSE As Double = 0
        Dim PNSR As Double = 0

        For i As Integer = 1 To gambar1.Width - 1
            For j As Integer = 1 To gambar1.Height - 1


                r1 = gambar1.GetPixel(i, j).R
                g1 = gambar1.GetPixel(i, j).G
                b1 = gambar1.GetPixel(i, j).B

                r2 = gambar2.GetPixel(i, j).R
                g2 = gambar2.GetPixel(i, j).G
                b2 = gambar2.GetPixel(i, j).B

                Dim warna1 = r1 * g1 * b1
                Dim warna2 = r2 * g2 * b2

                If warna1 > maxNumber Then
                    maxNumber = warna1
                End If

                If warna2 > maxNumber Then
                    maxNumber = warna2
                End If

                MSE = MSE + (warna2 - warna1) ^ 2
            Next
        Next
        MSE = MSE / (gambar1.Width * gambar1.Height)
        PNSR = 10 * Math.Log10((maxNumber ^ 2) / MSE)
        Label5.Text = Label5.Text & maxNumber
        Label6.Text = Label6.Text & gambar1.Width * gambar1.Height
        Label7.Text = Label7.Text & MSE
        Label8.Text = Label8.Text & PNSR
    End Sub
End Class