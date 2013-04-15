'   DPS916 - Visual Basic Course
'   Coded By: Raymond Hung and Stanley Tsang
'   Assignment 1
'   AddressForm.vb
'   Last Modified February 20 2013

Imports A1ClassLibraryVB

Public Class AddressForm
    Public addresses As List(Of String)

    Private Sub DataGridView1_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.RowValidating
        ' This check is to see if the line is empty, if it is, ignore validation
        Dim address = DataGridView1.CurrentRow.Cells("AddCol").Value
        If address Is Nothing Then
            Return
        End If

        If Validator.validateAddress(address.ToString()) Then
            DataGridView1.CurrentCell.Style.BackColor = System.Drawing.Color.White
            ToolStripStatusLabel1.Text = String.Empty
        Else
            DataGridView1.CurrentCell.Style.BackColor = System.Drawing.Color.Red
            MessageBox.Show("Please fix current address format before continuing.")
            ToolStripStatusLabel1.Text = "Invalid Address. Format is [###] [street name]"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        addresses = New List(Of String)
        For i As Integer = 0 To (DataGridView1.RowCount - 1)
            Dim cell = DataGridView1.Rows(i).Cells("AddCol")
            If cell.Value IsNot Nothing AndAlso cell.Style.BackColor <> System.Drawing.Color.Red Then
                addresses.Add(cell.Value.ToString())
            End If
        Next
        Me.Close()
    End Sub

    Private Sub PhoneaddressesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Depending on the values in addresses fill in the table as required
        DataGridView1.Rows.Clear()
        If addresses IsNot Nothing AndAlso addresses.Count > 0 Then
            For Each value In addresses
                DataGridView1.Rows.Add(value)
            Next
        End If

        ' Clear status tip in case text exists
        ToolStripStatusLabel1.Text = String.Empty
    End Sub
End Class