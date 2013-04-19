' DPS916 - Visual Basic Course
' Coded By: Raymond Hung and Stanley Tsang
' Assignment 2
' CellPhoneNumberModel.vb
' Last Modified April 8 2013

Imports A1ClassLibraryVB
Imports System.ComponentModel.DataAnnotations

Namespace A2Models
    <Schema.Table("CellPhoneNumbers")>
    Public Class CellPhoneNumberModel

        <Key()>
        Public Property CellPhoneId As Integer
        Public Property RecordId As Integer        '* Foreign key for Record

        <Schema.ForeignKey("RecordId")>
        Public Property Record As A2Models.RecordModel

        Dim _text As String
        Dim cellphoneNumberState As ModelStateDictionary

        Public Sub New(cellPhoneNumberString As String, id As Integer)
            RecordId = id
            cellphoneNumberState = New ModelStateDictionary
            Text = cellPhoneNumberString
        End Sub

        Public Sub New()
            cellphoneNumberState = New ModelStateDictionary
        End Sub

        <Display(Name:="Number")>
        Public Property Text As String
            Get
                Return _text
            End Get
            Set(value As String)
                If (A1ClassLibraryVB.ValidatorA2.validateCellPhoneNumber(value) = True) Then
                    Dim check As New Regex("[0-9]")
                    Dim filtered As String = ""
                    ' Remove all unnecessary characters
                    For Each letter In value
                        If (check.IsMatch(letter.ToString())) Then
                            filtered += letter
                        End If
                    Next
                    _text = "(" + filtered.Substring(0, 3) + ") " + filtered.Substring(3, 3) + "-" + filtered.Substring(6)
                Else
                    cellphoneNumberState.AddModelError("Text", "Cell Phone number is of incorrect format.  Must be 416/647/905 area code, and 7 digits.")
                End If
            End Set
        End Property

        Public ReadOnly Property ModelState() As ModelStateDictionary
            Get
                Return cellphoneNumberState
            End Get
        End Property
    End Class
End Namespace

