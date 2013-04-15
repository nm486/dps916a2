'   DPS916 - Visual Basic Course
'   Coded By: Raymond Hung and Stanley Tsang
'   Assignment 1
'   PhoneNumbersForm.vb
'   Last Modified February 20 2013

Imports A1ClassLibraryVB

Public Class PhoneNumbersForm

    Public Dim numbers As List(Of String)

    Private Sub DataGridView1_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.RowValidating
        ' This check is to see if the line is empty, if it is, ignore validation
        Dim phoneNum = DataGridView1.CurrentRow.Cells("PhoneNumber").Value
        If phoneNum Is Nothing Then
            Return
        End If

        If Validator.validatePhone(phoneNum.ToString()) Then
            DataGridView1.CurrentCell.Style.BackColor = System.Drawing.Color.White
            ToolStripStatusLabel1.Text = String.Empty
        Else
            DataGridView1.CurrentCell.Style.BackColor = System.Drawing.Color.Red
            MessageBox.Show("Please fix current number before continuing.")
            ToolStripStatusLabel1.Text = "Invalid format. Use 1234567890 or (123) 456-7890"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim check As New System.Text.RegularExpressions.Regex("^\(\d{3}\)[ ]?\d{3}[ -]\d{4}$")
        numbers = New List(Of String)
        For i As Integer = 0 To (DataGridView1.RowCount - 1)
            Dim cell = DataGridView1.Rows(i).Cells("PhoneNumber")
            If cell.Value IsNot Nothing AndAlso cell.Style.BackColor <> System.Drawing.Color.Red Then

                If check.IsMatch(cell.Value.ToString()) = False Then
                    cell.Value = "(" + cell.Value.ToString().Substring(0, 3) + ") " + cell.Value.ToString().Substring(3, 3) + "-" + cell.Value.ToString().Substring(6)
                End If
                numbers.Add(cell.Value.ToString())
            End If
        Next
        Me.Close()
    End Sub

    Private Sub PhoneNumbersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Depending on the values in numbers fill in the table as required
        DataGridView1.Rows.Clear()
        If numbers IsNot Nothing AndAlso numbers.Count > 0 Then
            For Each value In numbers
                DataGridView1.Rows.Add(value)
            Next
        End If

        ' Clear status tip in case text exists
        ToolStripStatusLabel1.Text = String.Empty
    End Sub
End Class