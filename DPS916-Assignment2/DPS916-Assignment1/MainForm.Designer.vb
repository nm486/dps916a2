<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.AddressBookListBox = New System.Windows.Forms.ListBox()
        Me.NewButton = New System.Windows.Forms.Button()
        Me.DeleteButton = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.AddressButton = New System.Windows.Forms.Button()
        Me.PhoneButton = New System.Windows.Forms.Button()
        Me.EmailButton = New System.Windows.Forms.Button()
        Me.NotesTxtBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.AddressTxtBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PhoneNumberTxtBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EmailTxtBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UserNameTxtBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddressBookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AddressBookListBox
        '
        Me.AddressBookListBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.AddressBookListBox.FormattingEnabled = True
        Me.AddressBookListBox.Location = New System.Drawing.Point(4, 28)
        Me.AddressBookListBox.Name = "AddressBookListBox"
        Me.AddressBookListBox.Size = New System.Drawing.Size(157, 316)
        Me.AddressBookListBox.TabIndex = 0
        '
        'NewButton
        '
        Me.NewButton.Location = New System.Drawing.Point(4, 348)
        Me.NewButton.Name = "NewButton"
        Me.NewButton.Size = New System.Drawing.Size(75, 23)
        Me.NewButton.TabIndex = 1
        Me.NewButton.Text = "New"
        Me.NewButton.UseVisualStyleBackColor = True
        '
        'DeleteButton
        '
        Me.DeleteButton.Location = New System.Drawing.Point(85, 348)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(75, 23)
        Me.DeleteButton.TabIndex = 2
        Me.DeleteButton.Text = "Delete"
        Me.DeleteButton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Ivory
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.AddressButton)
        Me.Panel1.Controls.Add(Me.PhoneButton)
        Me.Panel1.Controls.Add(Me.EmailButton)
        Me.Panel1.Controls.Add(Me.NotesTxtBox)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.AddressTxtBox)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.PhoneNumberTxtBox)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.EmailTxtBox)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.UserNameTxtBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.SaveButton)
        Me.Panel1.Location = New System.Drawing.Point(165, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(538, 347)
        Me.Panel1.TabIndex = 3
        '
        'AddressButton
        '
        Me.AddressButton.Location = New System.Drawing.Point(486, 147)
        Me.AddressButton.Name = "AddressButton"
        Me.AddressButton.Size = New System.Drawing.Size(34, 20)
        Me.AddressButton.TabIndex = 13
        Me.AddressButton.Text = "..."
        Me.AddressButton.UseVisualStyleBackColor = True
        '
        'PhoneButton
        '
        Me.PhoneButton.Location = New System.Drawing.Point(487, 106)
        Me.PhoneButton.Name = "PhoneButton"
        Me.PhoneButton.Size = New System.Drawing.Size(34, 20)
        Me.PhoneButton.TabIndex = 12
        Me.PhoneButton.Text = "..."
        Me.PhoneButton.UseVisualStyleBackColor = True
        '
        'EmailButton
        '
        Me.EmailButton.Location = New System.Drawing.Point(486, 64)
        Me.EmailButton.Name = "EmailButton"
        Me.EmailButton.Size = New System.Drawing.Size(34, 20)
        Me.EmailButton.TabIndex = 11
        Me.EmailButton.Text = "..."
        Me.EmailButton.UseVisualStyleBackColor = True
        '
        'NotesTxtBox
        '
        Me.NotesTxtBox.Location = New System.Drawing.Point(104, 188)
        Me.NotesTxtBox.MaxLength = 5000
        Me.NotesTxtBox.Multiline = True
        Me.NotesTxtBox.Name = "NotesTxtBox"
        Me.NotesTxtBox.Size = New System.Drawing.Size(417, 99)
        Me.NotesTxtBox.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(64, 191)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Notes:"
        '
        'AddressTxtBox
        '
        Me.AddressTxtBox.Location = New System.Drawing.Point(104, 147)
        Me.AddressTxtBox.Name = "AddressTxtBox"
        Me.AddressTxtBox.Size = New System.Drawing.Size(376, 20)
        Me.AddressTxtBox.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(53, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Address:"
        '
        'PhoneNumberTxtBox
        '
        Me.PhoneNumberTxtBox.Location = New System.Drawing.Point(104, 106)
        Me.PhoneNumberTxtBox.Name = "PhoneNumberTxtBox"
        Me.PhoneNumberTxtBox.Size = New System.Drawing.Size(376, 20)
        Me.PhoneNumberTxtBox.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Phone Number:"
        '
        'EmailTxtBox
        '
        Me.EmailTxtBox.Location = New System.Drawing.Point(104, 64)
        Me.EmailTxtBox.Name = "EmailTxtBox"
        Me.EmailTxtBox.Size = New System.Drawing.Size(376, 20)
        Me.EmailTxtBox.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(67, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Email:"
        '
        'UserNameTxtBox
        '
        Me.UserNameTxtBox.Location = New System.Drawing.Point(104, 24)
        Me.UserNameTxtBox.MaxLength = 50
        Me.UserNameTxtBox.Name = "UserNameTxtBox"
        Me.UserNameTxtBox.Size = New System.Drawing.Size(417, 20)
        Me.UserNameTxtBox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "User Name:"
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(430, 310)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(91, 23)
        Me.SaveButton.TabIndex = 0
        Me.SaveButton.Text = "Save Record"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 379)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(709, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(709, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.MenuToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddressBookToolStripMenuItem, Me.RecordToolStripMenuItem})
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'AddressBookToolStripMenuItem
        '
        Me.AddressBookToolStripMenuItem.Name = "AddressBookToolStripMenuItem"
        Me.AddressBookToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.AddressBookToolStripMenuItem.Text = "&Address Book"
        '
        'RecordToolStripMenuItem
        '
        Me.RecordToolStripMenuItem.Name = "RecordToolStripMenuItem"
        Me.RecordToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.RecordToolStripMenuItem.Text = "&Record"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.OpenToolStripMenuItem.Text = "&Open Address Book"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(178, 22)
        Me.ToolStripMenuItem1.Text = "&Save Address Book"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(175, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "jab"
        Me.OpenFileDialog1.Filter = "Address Book|*.jab"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "jab"
        Me.SaveFileDialog1.Filter = "Address Book|*.jab"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(709, 401)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.NewButton)
        Me.Controls.Add(Me.AddressBookListBox)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(725, 439)
        Me.MinimumSize = New System.Drawing.Size(725, 439)
        Me.Name = "MainForm"
        Me.Text = "Raymond and Stanley's Address Book Application"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AddressBookListBox As System.Windows.Forms.ListBox
    Friend WithEvents NewButton As System.Windows.Forms.Button
    Friend WithEvents DeleteButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SaveButton As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddressBookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotesTxtBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents AddressTxtBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PhoneNumberTxtBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents EmailTxtBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UserNameTxtBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AddressButton As System.Windows.Forms.Button
    Friend WithEvents PhoneButton As System.Windows.Forms.Button
    Friend WithEvents EmailButton As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog

End Class
