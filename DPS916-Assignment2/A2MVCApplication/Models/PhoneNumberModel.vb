' DPS916 - Visual Basic Course
' Coded By: Raymond Hung and Stanley Tsang
' Assignment 1
' AddressModel.vb
' Last Modified April 8 2013

Imports A1ClassLibraryVB
Imports System.ComponentModel.DataAnnotations

Namespace A2Models
    <Schema.Table("PhoneNumbers")>
    Public Class PhoneNumberModel

        <Key()>
        Public Property PhoneNumberId As Integer
        Public Property RecordId As Integer        '* Foreign key for Record

        <Schema.ForeignKey("RecordId")>
        Public Property Record As A2Models.RecordModel

        Dim _text As String
        Dim phoneNumberState As ModelStateDictionary

        Public Sub New()
            phoneNumberState = New ModelStateDictionary
        End Sub

        Public Sub New(phoneNumberString As String, id As Integer)
            RecordId = id
            phoneNumberState = New ModelStateDictionary
            Text = phoneNumberString
        End Sub

        Public Property Text As String
            Get
                Return _text
            End Get
            Set(value As String)
                If (A1ClassLibraryVB.ValidatorA2.validatePhone(value) = True) Then
                    _text = value
                Else
                    phoneNumberState.AddModelError("Text", "Phone number is of incorrect format.")
                End If
            End Set
        End Property

        Public ReadOnly Property ModelState() As ModelStateDictionary
            Get
                Return phoneNumberState
            End Get
        End Property
    End Class
End Namespace

