'   DPS916 - Visual Basic Course
'   Coded By: Raymond Hung and Stanley Tsang
'   Assignment 1
'   EmailForm.vb
'   Last Modified February 20 2013

Imports A1ClassLibraryVB

Public Class EmailForm
    Public emailList As List(Of String)

    Private Sub DataGridView1_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.RowValidating
        ' This check is to see if the line is empty, if it is, ignore validation
        Dim email = DataGridView1.CurrentRow.Cells("EmailCol").Value
        If email Is Nothing Then
            Return
        End If

        If Validator.validateEmail(email.ToString()) Then
            DataGridView1.CurrentCell.Style.BackColor = System.Drawing.Color.White
            ToolStripStatusLabel1.Text = String.Empty
        Else
            DataGridView1.CurrentCell.Style.BackColor = System.Drawing.Color.Red
            MessageBox.Show("Please fix current email before continuing.")
            ToolStripStatusLabel1.Text = "Invalid email."
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        emailList = New List(Of String)
        For i As Integer = 0 To (DataGridView1.RowCount - 1)
            Dim cell = DataGridView1.Rows(i).Cells("EmailCol")
            If cell.Value IsNot Nothing AndAlso cell.Style.BackColor <> System.Drawing.Color.Red Then
                emailList.Add(cell.Value.ToString())
            End If
        Next
        Me.Close()
    End Sub

    Private Sub EmailListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Depending on the values in emailList fill in the table as required
        DataGridView1.Rows.Clear()
        If emailList IsNot Nothing AndAlso emailList.Count > 0 Then
            For Each value In emailList
                DataGridView1.Rows.Add(value)
            Next
        End If

        ' Clear status tip in case text exists
        ToolStripStatusLabel1.Text = String.Empty
    End Sub
End Class