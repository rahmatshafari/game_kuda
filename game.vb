Imports MySql.Data.MySqlClient
Imports System.Data.Odbc
Public Class game
    Dim atas, kanan, kiri, bawah, ujung, ujung1, ujung2, atas1, kiri1, kanan1, bawah1 As Boolean
    Dim koneksi As New MySqlConnection
    Dim command As New MySqlCommand
    Dim makan, kasih, status, uang As Integer
    Dim start As String

    Sub konek()
        start = "Server=localhost; userid=root; password=; database=peternakan"
        koneksi = New MySqlConnection(start)
        koneksi.Open()
    End Sub
    Private Sub game_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call konek()
        atas = True
        kiri = True
        bawah = True
        kanan = True
        atas1 = True
        kiri1 = True
        kanan1 = True
        bawah1 = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If atas = True Then
            PictureBox1.Left += 10
        Else
            PictureBox1.Left -= 10
        End If
        If bawah = True Then
            PictureBox5.Left += 10
        Else
            PictureBox5.Left -= 10
        End If
        If kiri = True Then
            PictureBox7.Left += 10
        Else
            PictureBox7.Left -= 10
        End If
        If PictureBox5.Left <= Me.PictureBox11.Right Then
            bawah = True
        End If
        If PictureBox5.Left + PictureBox5.Width >= Me.PictureBox12.Left Then
            bawah = False
        End If
        If PictureBox1.Left <= Me.ClientRectangle.Left Then
            atas = True
        End If
        If PictureBox1.Left + PictureBox1.Width >= Me.PictureBox11.Left Then
            atas = False
        End If
        If PictureBox7.Left <= Me.PictureBox12.Right Then
            kiri = True
        End If
        If PictureBox7.Left + PictureBox7.Width >= Me.ClientRectangle.Right Then
            kiri = False
        End If

        If ujung = True Then
            PictureBox2.Left += 10
        Else
            PictureBox2.Left -= 10
        End If
        If ujung1 = True Then
            PictureBox4.Left += 10
        Else
            PictureBox4.Left -= 10
        End If
        If ujung2 = True Then
            PictureBox6.Left += 10
        Else
            PictureBox6.Left -= 10
        End If
        If PictureBox2.Left <= Me.ClientRectangle.Left Then
            ujung = True
        End If
        If PictureBox2.Left + PictureBox2.Width >= Me.PictureBox13.Left Then
            ujung = False
        End If
        If PictureBox4.Left <= Me.PictureBox13.Right Then
            ujung1 = True
        End If
        If PictureBox4.Left + PictureBox4.Width >= Me.PictureBox14.Left Then
            ujung1 = False
        End If
        If PictureBox6.Left <= Me.PictureBox14.Right Then
            ujung2 = True
        End If
        If PictureBox6.Left + PictureBox6.Width >= Me.ClientRectangle.Right Then
            ujung2 = False
        End If
    End Sub

    Private Sub Bounds()
        Dim x As Integer = PictureBox3.Location.X
        Dim y As Integer = PictureBox3.Location.Y

        If y <= 0 Then
            atas1 = False
        Else
            atas1 = True
        End If

        If x <= 0 Then
            kiri1 = False
        Else
            kiri1 = True
        End If

        If x >= 799 Then
            kanan1 = False
        Else
            kanan1 = True
        End If

        If y >= 478 Then
            bawah1 = False
        Else
            bawah1 = True
        End If
    End Sub

    Private Sub game_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Bounds()
        Select Case e.KeyCode
            Case Keys.W
                If atas1 = True Then
                    PictureBox3.Top -= 20
                Else

                End If
            Case Keys.S
                If bawah1 = True Then
                    PictureBox3.Top += 20
                Else

                End If
            Case Keys.A
                If kiri1 = True Then
                    PictureBox3.Left -= 20
                Else

                End If
            Case Keys.D
                If kanan1 = True Then
                    PictureBox3.Left += 20
                Else

                End If
        End Select

        If PictureBox1.Bounds.IntersectsWith(PictureBox3.Bounds) Then
            Timer2.Enabled = False
            Timer1.Enabled = False
            Label1.Text = 0
            MsgBox("You Lose")
            Form1.Show()
            Me.Close()
        End If

        If PictureBox2.Bounds.IntersectsWith(PictureBox3.Bounds) Then
            Timer2.Enabled = False
            Timer1.Enabled = False
            Label1.Text = 0
            MsgBox("You Lose")
            Form1.Show()
            Me.Close()
        End If

        If PictureBox4.Bounds.IntersectsWith(PictureBox3.Bounds) Then
            Timer2.Enabled = False
            Timer1.Enabled = False
            Label1.Text = 0
            MsgBox("You Lose")
            Form1.Show()
            Me.Close()
        End If

        If PictureBox5.Bounds.IntersectsWith(PictureBox3.Bounds) Then
            Timer2.Enabled = False
            Timer1.Enabled = False
            Label1.Text = 0
            MsgBox("You Lose")
            Form1.Show()
            Me.Close()
        End If

        If PictureBox6.Bounds.IntersectsWith(PictureBox3.Bounds) Then
            Timer2.Enabled = False
            Timer1.Enabled = False
            Label1.Text = 0
            MsgBox("You Lose")
            Form1.Show()
            Me.Close()
        End If

        If PictureBox7.Bounds.IntersectsWith(PictureBox3.Bounds) Then
            Timer2.Enabled = False
            Timer1.Enabled = False
            Label1.Text = 0
            MsgBox("You Lose")
            Form1.Show()
            Me.Close()
        End If

        If PictureBox3.Bounds.IntersectsWith(PictureBox9.Bounds) Then
            PictureBox9.Visible = False
            PictureBox9.Location = New Point(65, 467)
            If PictureBox9.Visible = False Then
                Dim qwe As New MySqlCommand("update pemain set uang = uang + '500' where id = '1'", koneksi)
                qwe.ExecuteNonQuery()
            End If
           
        End If

        If PictureBox3.Bounds.IntersectsWith(PictureBox10.Bounds) Then
            PictureBox10.Visible = False
            PictureBox10.Location = New Point(65, 467)
            If PictureBox10.Visible = False Then
                Dim qwe As New MySqlCommand("update pemain set uang = uang + '1000' where id = '1'", koneksi)
                qwe.ExecuteNonQuery()
            End If
           
        End If
        If PictureBox3.Bounds.IntersectsWith(PictureBox8.Bounds) Then
            PictureBox8.Visible = False
            PictureBox8.Location = New Point(65, 467)
            If PictureBox8.Visible = False Then
                Dim qwe As New MySqlCommand("update pemain set uang = uang + '1500' where id = '1'", koneksi)
                qwe.ExecuteNonQuery()
            End If
           
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim no1 As Integer
        no1 = Label1.Text

        If Timer2.Enabled = True Then
            Label1.Text = no1 + 1
            If Label1.Text = 50 Then
                Timer2.Enabled = False
                Timer1.Enabled = False
                Label1.Text = 0
                MsgBox("TIME IS OVER, I'm Sorry You Lose. TRY AGAIN!")
                Form1.Show()
                Me.Close()

            ElseIf PictureBox9.Visible = False And PictureBox10.Visible = False And PictureBox8.Visible = False Then
                Timer2.Enabled = False
                Timer1.Enabled = False
                Label1.Text = 0
                MsgBox("Conratulations!! You Win,Perfecto")
                'Dim qwe As New MySqlCommand("update pemain set uang = uang + '1000' where id = '1'", koneksi)
                'qwe.ExecuteNonQuery()
                Form1.Show()
                Me.Close()
            End If
        End If
    End Sub
End Class