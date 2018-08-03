Imports MySql.Data.MySqlClient
Imports System.Data.Odbc
Public Class jualee
    Dim koneksi As New MySqlConnection
    Dim command As New MySqlCommand
    Dim table As New DataTable
    Dim jenis, gambar, pakan, start, hewan As String
    Dim status, total, harga, id, harga1, kotoran, harga2 As Integer

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
        Label4.Text = "....."
        Label5.Text = "....."
        TextBox1.Text = ""
    End Sub

    Sub showtable()
        Dim dataadapter1 As New MySqlDataAdapter("select id from kudaku", koneksi)
        Dim dataset1 As New DataSet
        dataset1.Clear()
        dataadapter1.Fill(dataset1, "kudaku")
    End Sub
    Private Sub jualee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call konek()
        Dim dataadapter As New MySqlDataAdapter("select id from kudaku", koneksi)
        Dim dataset As New DataSet
        dataset.Clear()
        dataadapter.Fill(dataset, "kudaku")

        Dim naks As New MySqlCommand("select uang from pemain", koneksi)
        Dim reads As MySqlDataReader
        reads = naks.ExecuteReader
        reads.Read()
        If reads.HasRows Then
            harga1 = reads.Item("uang")
        End If
        koneksi.Close()
        Call konek()
        Dim ko2 As New MySqlCommand("select kotoran from pemain where id = '1'", koneksi)
        Dim ko3 As MySqlDataReader
        ko3 = ko2.ExecuteReader
        ko3.Read()
        If ko3.HasRows Then
            kotoran = ko3.Item("kotoran")
        End If
        koneksi.Close()
        Call konek()


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If kotoran < TextBox1.Text Then
            MsgBox("Kotoran Anda tidak ada")
        Else
            harga2 = 300 * TextBox1.Text
            Label4.Text = harga2
            Label5.Text = harga1
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call konek()
        total = harga1 + harga2
        Dim duit As New MySqlCommand("update pemain set kotoran = kotoran - '" & TextBox1.Text & "', uang = '" & total & "'", koneksi)
        duit.ExecuteNonQuery()
        Clear()
        Label7.Text = total
        Me.jualee_Load(sender, e)
        Me.Show()
    End Sub

   
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        toko.Show()
        Me.Close()

    End Sub
End Class