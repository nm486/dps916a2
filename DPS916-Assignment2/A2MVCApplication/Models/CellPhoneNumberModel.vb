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

        <Required()>
        Public Property Text As String
            Get
                Return _text
            End Get
            Set(value As String)
                If (A1ClassLibraryVB.ValidatorA2.validateCellPhoneNumber(value) = True) Then
                    _text = value
                Else
                    cellphoneNumberState.AddModelError("Text", "Cell Phone number is of incorrect format.")
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

