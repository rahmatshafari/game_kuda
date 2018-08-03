Imports MySql.Data.MySqlClient
Imports System.Data.Odbc

Public Class Form1
    Dim atas, kiri, kanan, bawah As Boolean
    Dim koneksi As New MySqlConnection
    Dim command As New MySqlCommand
    Dim jenis, gambar, pakan, start As String
    Dim harga_makanan, jumlah, total, uang, stok_makan, total2, id, id1, pakan1, stok, status1, status2, ktr As Integer

    Sub konek()
        start = "Server=localhost; userid=root; password=; database=peternakan"
        koneksi = New MySqlConnection(start)
        koneksi.Open()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call konek()
        Dim nak9 As New MySqlCommand("select uang from pemain where id = '1'", koneksi)
        Dim read9 As MySqlDataReader
        read9 = nak9.ExecuteReader
        read9.Read()
        If read9.HasRows Then
            uang = read9.Item("uang")
        End If
        Label1.Text = uang
        koneksi.Close()

        Call konek()
        Dim asd As New MySqlCommand("select stok_makan from pemain where id = '1'", koneksi)
        Dim rd As MySqlDataReader
        rd = asd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            stok = rd.Item("stok_makan")
        End If
        Label2.Text = stok
        koneksi.Close()

        Call konek()
        Dim na As New MySqlCommand("select status from kudaku where id = '1'", koneksi)
        Dim re As MySqlDataReader
        re = na.ExecuteReader
        re.Read()
        If re.HasRows Then
            status1 = re.Item("status")
        End If
        Label3.Text = status1
        koneksi.Close()

        Call konek()
        Dim n As New MySqlCommand("select status from kudaku where id = '2'", koneksi)
        Dim r As MySqlDataReader
        r = n.ExecuteReader
        r.Read()
        If r.HasRows Then
            status2 = r.Item("status")
        End If
        Label4.Text = status2
        koneksi.Close()


        Call konek()
        Dim f As New MySqlCommand("select kotoran from pemain where id = '1'", koneksi)
        Dim read As MySqlDataReader
        read = f.ExecuteReader
        read.Read()
        If read.HasRows Then
            ktr = read.Item("kotoran")
        End If
        Label5.Text = ktr
        koneksi.Close()
        atas = True
        bawah = True
        kiri = True
        kanan = True
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static x As Integer = 5
        Static y As Integer = 0

        If y Mod 2 = 0 Then
            Me.PictureBox19.Image = My.Resources.pohon
            Me.PictureBox18.Image = My.Resources.rumput
            Me.PictureBox20.Image = My.Resources.bt
            Me.PictureBox21.Image = My.Resources.bt
            Me.PictureBox36.Image = My.Resources.bt
            Me.PictureBox37.Image = My.Resources.kudaa
            Me.PictureBox38.Image = My.Resources.kudaa


        Else
            Me.PictureBox19.Image = My.Resources.pohon2
            Me.PictureBox18.Image = My.Resources.rumput1
            Me.PictureBox20.Image = My.Resources.bt1
            Me.PictureBox21.Image = My.Resources.bt1
            Me.PictureBox36.Image = My.Resources.bt
            Me.PictureBox37.Image = My.Resources.kudaa1
            Me.PictureBox38.Image = My.Resources.kudaa1
        End If
        y += 1

        PictureBox31.Top -= 5
        If PictureBox31.Top <= 457 Then

            PictureBox31.Location = New Point(25, 599)

        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        kasih.Show()
        Me.Close()

    End Sub

    Private Sub PictureBox28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox28.Click
        toko.Show()
        Me.Close()

    End Sub

    Private Sub PictureBox44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox44.Click
        Call konek()
        If PictureBox44.Visible = True Then
            Dim com As New MySqlCommand("update pemain set kotoran = kotoran + '1'", koneksi)
            com.ExecuteNonQuery()
            PictureBox44.Visible = False
            Me.Form1_Load(sender, e)

        End If
    End Sub



    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        game.Show()
        game.Timer2.Enabled = True
        Me.Close()
    End Sub
End Class
