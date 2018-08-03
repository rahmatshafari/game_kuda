Imports MySql.Data.MySqlClient
Imports System.Data.Odbc
Public Class makan
    Dim koneksi As New MySqlConnection
    Dim command As New MySqlCommand
    Dim jenis, gambar, pakan, start, makan As String
    Dim harga_makanan, jumlah, total, uang, stok_makan, total2, id, id1, pakan1 As Integer

    Sub konek()
        start = "Server=localhost; userid=root; password=; database=peternakan"
        koneksi = New MySqlConnection(start)
        koneksi.Open()
    End Sub

    Sub Clear()
        Dim ctl As Control
        For Each ctl In Me.Controls
            If TypeOf ctl Is ComboBox Then
                ctl.Text = ""
            End If
        Next
        TextBox1.Text = ""
        Label10.Text = "....."
        Label5.Text = "....."
    End Sub

    Private Sub makan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call konek()
        Dim co As New MySqlCommand("select jenis_makanan, harga_makanan from makan where id = '1'", koneksi)
        Dim data2 As MySqlDataReader
        data2 = co.ExecuteReader
        data2.Read()
        If data2.HasRows() Then
            makan = data2.Item("jenis_makanan")
            harga_makanan = data2.Item("harga_makanan")
        End If
        koneksi.Close()
        Call konek()

        Dim command1 As New MySqlCommand("select stok_makan, uang from pemain where id = '1'", koneksi)
        Dim data1 As MySqlDataReader
        data1 = command1.ExecuteReader
        data1.Read()
        If data1.HasRows() Then
            uang = data1.Item("uang")
            stok_makan = data1.Item("stok_makan")
        End If

        koneksi.Close()
        Call konek()


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label10.Text = uang
        jumlah = TextBox1.Text
        total = harga_makanan * jumlah
        Label5.Text = total
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call konek()
        If uang < total Then
            MsgBox("Uang Anda Tidak Mencukupi")
        Else
            Dim pakan As New MySqlCommand("update pemain set stok_makan = stok_makan + '" & jumlah & "'", koneksi)
            pakan.ExecuteNonQuery()
            koneksi.Close()
            Call konek()
            Dim nak2 As New MySqlCommand("select stok_makan from pemain", koneksi)
            Dim read2 As MySqlDataReader
            read2 = nak2.ExecuteReader()
            read2.Read()
            If read2.HasRows Then
                pakan1 = read2.Item("stok_makan")
            End If
            koneksi.Close()
            Call konek()
            If pakan1 > 99 Then
                MsgBox("Jumlah Rumput Yang Anda Miliki Melebihi Batas")
                Dim pakan2 As New MySqlCommand("update pemain set stok_makan = stok_makan - '" & jumlah & "'", koneksi)
                pakan2.ExecuteNonQuery()
                Clear()
            Else
                total2 = uang - total
                Label11.Text = total2
                Dim duit As New MySqlCommand("update pemain set uang = '" & total2 & "'", koneksi)
                duit.ExecuteNonQuery()
                Clear()
                Me.makan_Load(sender, e)
                Me.Show()
            End If
        End If
    End Sub

 
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        toko.Show()
        Me.Close()
    End Sub
End Class