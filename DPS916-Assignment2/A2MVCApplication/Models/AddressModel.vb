' DPS916 - Visual Basic Course
' Coded By: Raymond Hung and Stanley Tsang
' Assignment 1
' AddressModel.vb
' Last Modified April 8 2013

Imports A1ClassLibraryVB
Imports System.ComponentModel.DataAnnotations

Namespace A2Models
    <Schema.Table("Addresses")>
    Public Class AddressModel

        <Key()>
        Public Property AddressId As Integer
        Public Property RecordId As Integer        '* Foreign key for Record

        <Schema.ForeignKey("RecordId")>
        Public Property Record As A2Models.RecordModel

        Dim _text As String
        Dim addressState As ModelStateDictionary

        Public Sub New()
            addressState = New ModelStateDictionary
        End Sub

        Public Sub New(addressString As String, id As Integer)
            RecordId = id
            addressState = New ModelStateDictionary
            Text = addressString
        End Sub

        Public Property Text As String
            Get
                Return _text
            End Get
            Set(value As String)
                ' Call our new Validator class to validate input, then adjust ModelState as necessary
                If (A1ClassLibraryVB.ValidatorA2.validateAddress(value) = True) Then
                    _text = value
                Else
                    addressState.AddModelError("Text", "Address is of incorrect format.")
                End If
            End Set
        End Property

        Public ReadOnly Property ModelState() As ModelStateDictionary
            Get
                Return addressState
            End Get
        End Property
    End Class
End Namespace

