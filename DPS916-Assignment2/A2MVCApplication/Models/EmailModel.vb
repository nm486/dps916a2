' DPS916 - Visual Basic Course
' Coded By: Raymond Hung and Stanley Tsang
' Assignment 1
' EmailModel.vb
' Last Modified April 8 2013

Imports A1ClassLibraryVB
Imports System.ComponentModel.DataAnnotations

Namespace A2Models
    <Schema.Table("Emails")>
    Public Class EmailModel

        <Key()>
        Public Property EmailId As Integer
        Public Property RecordId As Integer        '* Foreign key for Record

        <Schema.ForeignKey("RecordId")>
        Public Property Record As A2Models.RecordModel

        Dim _text As String
        Dim emailState As ModelStateDictionary

        Public Sub New()
            emailState = New ModelStateDictionary
        End Sub

        Public Sub New(emailString As String, id As Integer)
            RecordId = id
            emailState = New ModelStateDictionary
            Text = emailString
        End Sub

        Public Property Text As String
            Get
                Return _text
            End Get
            Set(value As String)
                If (A1ClassLibraryVB.ValidatorA2.validateEmail(value) = True) Then
                    _text = value
                Else
                    emailState.AddModelError("Text", "Email is of incorrect format.")
                End If
            End Set
        End Property

        Public ReadOnly Property ModelState() As ModelStateDictionary
            Get
                Return emailState
            End Get
        End Property
    End Class
End Namespace

