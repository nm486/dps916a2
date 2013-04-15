'   DPS916 - Visual Basic Course
'   Coded By: Raymond Hung and Stanley Tsang
'   Assignment 1
'   MainForm.vb
'   Last Modified February 20 2013

Imports A1ClassLibraryVB
Imports A1ClassLibraryCS

Public Class MainForm

    'Variables used to store information from other forms
    Dim addresses As List(Of String)
    Dim phones As List(Of String)
    Dim emails As List(Of String)
    Dim recIndex As Integer
    Dim record As RecordA1
    Dim WithEvents addressBook As New AddressBook

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        addressBook = New AddressBook
        record = New RecordA1
        recIndex = -1
    End Sub

    Private Sub showRecord()
        Dim rec As RecordA1
        If recIndex <> -1 Then
            rec = addressBook.Records(recIndex)
            UserNameTxtBox.BackColor = Color.White
            UserNameTxtBox.Text = rec.UserName
            PhoneNumberTxtBox.BackColor = Color.White
            PhoneNumberTxtBox.Text = If(rec.PhoneNumbers IsNot Nothing AndAlso rec.PhoneNumbers.Count <> 0, rec.PhoneNumbers(0), String.Empty)
            phones = rec.PhoneNumbers
            AddressTxtBox.BackColor = Color.White
            AddressTxtBox.Text = If(rec.Addresses IsNot Nothing AndAlso rec.Addresses.Count <> 0, rec.Addresses(0), String.Empty)
            addresses = rec.Addresses
            EmailTxtBox.BackColor = Color.White
            EmailTxtBox.Text = If(rec.EmailAddresses IsNot Nothing AndAlso rec.EmailAddresses.Count <> 0, rec.EmailAddresses(0), String.Empty)
            emails = rec.EmailAddresses
            NotesTxtBox.Text = If(rec.Notes Is Nothing, String.Empty, rec.Notes)
        End If
    End Sub

    Private Sub AddressBookListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AddressBookListBox.SelectedIndexChanged
        recIndex = AddressBookListBox.SelectedIndex
        showRecord()
    End Sub
#Region "Click Events"
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles PhoneButton.Click
        PhoneNumbersForm.numbers = phones
        PhoneNumbersForm.ShowDialog()
        updatePhoneNumbers()
    End Sub

    Private Sub EmailButton_Click(sender As Object, e As EventArgs) Handles EmailButton.Click
        EmailForm.emailList = emails
        EmailForm.ShowDialog()
        updateEmail()
    End Sub

    Private Sub AddressButton_Click(sender As Object, e As EventArgs) Handles AddressButton.Click
        AddressForm.addresses = addresses
        AddressForm.ShowDialog()
        updateAddress()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        ' Set the file name to empty so that there are no residual information left over from previous saves
        SaveFileDialog1.FileName = String.Empty
        Dim Result = SaveFileDialog1.ShowDialog()
        If Result = DialogResult.Cancel Then
            ToolStripStatusLabel1.Text = "Save cancelled"
            Return
        End If

        ' Check if file name was given
        If SaveFileDialog1.FileName <> "" Then
            Result = addressBook.writeToJSON(SaveFileDialog1.FileName)
            If Result = True Then
                ToolStripStatusLabel1.Text = "Successfully saved"
            Else
                ToolStripStatusLabel1.Text = "Unable to save. Please try again"
            End If
        End If

    End Sub

    Private Sub NewButton_Click(sender As Object, e As EventArgs) Handles NewButton.Click, RecordToolStripMenuItem.Click
        record = New RecordA1
        recIndex = -1
        AddressBookListBox.SelectedIndex = -1
        UserNameTxtBox.Text = String.Empty
        AddressTxtBox.Text = String.Empty
        EmailTxtBox.Text = String.Empty
        NotesTxtBox.Text = String.Empty
        PhoneNumberTxtBox.Text = String.Empty
        addresses = New List(Of String)
        phones = New List(Of String)
        emails = New List(Of String)
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        Dim names = addressBook.getAllUserNames()
        Dim index As Integer

        index = names.IndexOf(UserNameTxtBox.Text)
        addressBook.deleteRecord(index)
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        ' Clear file name to remove previous open attempt texts
        OpenFileDialog1.FileName = String.Empty
        Dim result As DialogResult
        ToolStripStatusLabel1.Text = "Opening address book..."
        result = OpenFileDialog1.ShowDialog()
        If result = DialogResult.Cancel Then
            ToolStripStatusLabel1.Text = "Cancelled opening existing address book"
        End If

        ' Check to see if file was selected
        If OpenFileDialog1.FileName <> "" Then
            If addressBook.readFromJSON(OpenFileDialog1.FileName) Then
                ToolStripStatusLabel1.Text = "Address book successfully loaded"
                updateListBox()
                recIndex = 0
                showRecord()
            Else
                ToolStripStatusLabel1.Text = "Address book failed to load"
            End If
        End If

    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim records = addressBook.Records

        ' Create record information
        record = New RecordA1
        record.UserName = UserNameTxtBox.Text
        record.Addresses = addresses
        record.EmailAddresses = emails
        record.PhoneNumbers = phones
        record.Notes = NotesTxtBox.Text

        ' Cannot save if user name is not given
        If UserNameTxtBox.Text = String.Empty Then
            ToolStripStatusLabel1.Text = "User name needed"
            UserNameTxtBox.BackColor = Color.Red
            UserNameTxtBox.Focus()
        End If

        ' Don't bother saving if user name is not unique
        If UserNameTxtBox.BackColor = Color.Red Then
            ToolStripStatusLabel1.Text = "Record unable to be saved because user name is not unique."
            Exit Sub
        End If

        ' If new user name, create new record. Otherwise, update record
        If recIndex = -1 Then
            ToolStripStatusLabel1.Text = "Record unable to save"
            addressBook.createRecord(record)
        Else
            ToolStripStatusLabel1.Text = "Record unable to update"
            addressBook.updateRecord(recIndex, record)
        End If

        recIndex = records.IndexOf(record)
        AddressBookListBox.SelectedIndex = recIndex
        showRecord()

    End Sub

    Private Sub AddressBookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddressBookToolStripMenuItem.Click
        addressBook = New AddressBook
        record = New RecordA1
        recIndex = -1
        UserNameTxtBox.BackColor = Color.White
        UserNameTxtBox.Text = String.Empty
        AddressTxtBox.BackColor = Color.White
        AddressTxtBox.Text = String.Empty
        EmailTxtBox.BackColor = Color.White
        EmailTxtBox.Text = String.Empty
        NotesTxtBox.Text = String.Empty
        PhoneNumberTxtBox.BackColor = Color.White
        PhoneNumberTxtBox.Text = String.Empty
        addresses = New List(Of String)
        phones = New List(Of String)
        emails = New List(Of String)
        updateListBox()
    End Sub
#End Region

#Region "Update elements"
    Private Sub updateListBox()
        AddressBookListBox.DataSource = addressBook.getAllUserNames
    End Sub

    Private Sub updateEmail()
        emails = EmailForm.emailList
        If emails IsNot Nothing AndAlso emails.Count > 0 Then
            EmailTxtBox.Text = emails(0).ToString()
        End If
        ToolStripStatusLabel1.Text = "Email Information Updated"
    End Sub

    Private Sub updateAddress()
        addresses = AddressForm.addresses
        If addresses IsNot Nothing AndAlso addresses.Count > 0 Then
            AddressTxtBox.Text = addresses(0).ToString()
        End If
        ToolStripStatusLabel1.Text = "Address Information Updated"
    End Sub

    Private Sub updatePhoneNumbers()
        phones = PhoneNumbersForm.numbers
        If phones IsNot Nothing AndAlso phones.Count > 0 Then
            PhoneNumberTxtBox.Text = phones(0).ToString()
        End If
        ToolStripStatusLabel1.Text = "Phone Information Updated"
    End Sub
#End Region

#Region "Event Handling"
    Sub addressBookCreateSuccess_eventHandler() Handles AddressBook.createSuccessEvent
        ToolStripStatusLabel1.Text = "Record successfully saved"
        recIndex = addressBook.getAllUserNames().IndexOf(UserNameTxtBox.Text)
        updateListBox()
    End Sub

    Sub addressBookUpdateSuccess_eventHandler() Handles AddressBook.updateSuccessEvent
        ToolStripStatusLabel1.Text = "Record successfully updated"
        updateListBox()
    End Sub

    Sub addressBookDeleteSuccess_eventHandler() Handles AddressBook.deleteSuccessEvent
        ToolStripStatusLabel1.Text = "Record successfully deleted"
        updateListBox()
    End Sub
#End Region

#Region "TextBox Validation"
    Private Sub AddressTxtBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles AddressTxtBox.Validating
        'Don't validate empty text
        If AddressTxtBox.Text = String.Empty Then
            Exit Sub
        End If

        If Validator.validateAddress(AddressTxtBox.Text) Then
            AddressTxtBox.BackColor = Color.White
            ToolStripStatusLabel1.Text = String.Empty
            If addresses Is Nothing Then
                addresses = New List(Of String)
                addresses.Add(AddressTxtBox.Text)
            ElseIf addresses.Count = 0 Then
                addresses.Add(AddressTxtBox.Text)
            Else
                addresses(0) = AddressTxtBox.Text
            End If
        Else
            AddressTxtBox.BackColor = Color.Red
            ToolStripStatusLabel1.Text = "Invalid address format. Address format should be [##] [Street name]"
            AddressTxtBox.Focus()
        End If
    End Sub

    Private Sub EmailTxtBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles EmailTxtBox.Validating
        'Don't validate empty text
        If EmailTxtBox.Text = String.Empty Then
            Exit Sub
        End If

        If Validator.validateEmail(EmailTxtBox.Text) Then
            EmailTxtBox.BackColor = Color.White
            ToolStripStatusLabel1.Text = String.Empty
            If emails Is Nothing Then
                emails = New List(Of String)
                emails.Add(EmailTxtBox.Text)
            ElseIf emails.Count = 0 Then
                emails.Add(EmailTxtBox.Text)
            Else
                emails(0) = EmailTxtBox.Text
            End If
        Else
            EmailTxtBox.BackColor = Color.Red
            ToolStripStatusLabel1.Text = "Invalid email format. Email domains are @myseneca.ca and @senecacollege.on.ca"
            EmailTxtBox.Focus()
        End If
    End Sub

    Private Sub PhoneNumberTxtBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PhoneNumberTxtBox.Validating
        'Don't validate empty text
        If PhoneNumberTxtBox.Text = String.Empty Then
            Exit Sub
        End If

        If Validator.validatePhone(PhoneNumberTxtBox.Text) Then
            PhoneNumberTxtBox.BackColor = Color.White
            ToolStripStatusLabel1.Text = String.Empty

            ' Formatting string to be pretty
            If PhoneNumberTxtBox.Text.Length = 10 Then
                PhoneNumberTxtBox.Text = "(" + PhoneNumberTxtBox.Text.Substring(0, 3) + ") " + PhoneNumberTxtBox.Text.Substring(3, 3) + "-" + PhoneNumberTxtBox.Text.Substring(6)
            End If

            If phones Is Nothing Then
                phones = New List(Of String)
                phones.Add(PhoneNumberTxtBox.Text)
            ElseIf phones.Count = 0 Then
                phones.Add(PhoneNumberTxtBox.Text)
            Else
                phones(0) = PhoneNumberTxtBox.Text
            End If
        Else
            PhoneNumberTxtBox.BackColor = Color.Red
            ToolStripStatusLabel1.Text = "Invalid phone format. Use 1234567890 or (123) 456-7890 format"
            PhoneNumberTxtBox.Focus()
        End If
    End Sub

    Private Sub UserNameTxtBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles UserNameTxtBox.Validating
        Dim colour = Color.Red
        Dim msg = String.Empty
        Dim check = addressBook.getAllUserNames()
        ' Checks are the following: Invalid user name format, new record but existing user name, old record with new user name but new user name is used
        If Validator.validateUserName(UserNameTxtBox.Text) = False Then
            msg = "Invalid user name format. User names must only contain alphanumeric characters, spaces, or _"
            UserNameTxtBox.Focus()
        ElseIf recIndex = -1 And addressBook.getAllUserNames().IndexOf(UserNameTxtBox.Text) <> -1 Then
            msg = "User name already exists. Please change user name to be unique"
            UserNameTxtBox.Focus()
        ElseIf recIndex <> -1 And addressBook.getAllUserNames().Contains(UserNameTxtBox.Text) _
            And addressBook.getAllUserNames().IndexOf(UserNameTxtBox.Text) <> recIndex Then
            msg = "User name already exists. Please change user name to be unique"
            UserNameTxtBox.Focus()
        Else
            colour = Color.White
        End If
        UserNameTxtBox.BackColor = colour
        ToolStripStatusLabel1.Text = msg
    End Sub
#End Region
End Class
