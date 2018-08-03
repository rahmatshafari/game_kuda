Imports MySql.Data.MySqlClient
Imports System.Data.Odbc
Public Class kasih
    Dim koneksi As New MySqlConnection
    Dim command As New MySqlCommand
    Dim makan, kasih, status, stok As Integer
    Dim start As String

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
    End Sub
    Private Sub kasih_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call konek()
        command = New MySqlCommand("select stok_makan from pemain", koneksi)
        Dim data2 As MySqlDataReader
        data2 = command.ExecuteReader
        data2.Read()
        If data2.HasRows() Then
            makan = data2.Item("stok_makan")
        End If
        koneksi.Close()

        Call konek()
        Dim pe As New MySqlDataAdapter("select id from kudaku", koneksi)
        Dim se As New DataSet
        se.Clear()
        pe.Fill(se, "kudaku")
        ComboBox1.DataSource = (se.Tables("kudaku"))
        Me.ComboBox1.ValueMember = "id"
        koneksi.Close()
        Call konek()
        kasih = 1

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
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call konek()
        If makan < 1 Then
            MsgBox("Silahkan Beli makan terlebih dahulu")
        Else
            command = New MySqlCommand("UPDATE kudaku set status = status + '" & kasih & "' WHERE id='" & ComboBox1.Text & "'", koneksi)
            command.ExecuteNonQuery()
            koneksi.Close()
            Call konek()
            command = New MySqlCommand("UPDATE pemain set stok_makan = stok_makan - '" & kasih & "' WHERE id = '1'", koneksi)
            command.ExecuteNonQuery()
            koneksi.Close()
            Call konek()
            MsgBox("Hewan Telah Berhasil Diberi Makan")
            Dim coman As New MySqlCommand("select status from kudaku where id = '" & ComboBox1.Text & "'", koneksi)
            Dim data3 As MySqlDataReader
            data3 = coman.ExecuteReader
            data3.Read()
            If data3.HasRows() Then
                status = data3.Item("status")
            End If
            koneksi.Close()
            Call konek()
            If status >= 3 Then
                Form1.PictureBox44.Visible = True
                Dim wew As New MySqlCommand("UPDATE kudaku set status = '0' WHERE id='" & ComboBox1.Text & "'", koneksi)
                wew.ExecuteNonQuery()
                koneksi.Close()
                Call konek()

            End If
            Form1.Show()
            Me.Close()
            koneksi.Close()
            Call konek()

        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Close()

    End Sub
End Class