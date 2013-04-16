' DPS916 - Visual Basic Course
' Coded By: Raymond Hung and Stanley Tsang
' Assignment 2
' RecordModel.vb
' Last Modified April 8 2013

Imports A1ClassLibraryVB
Imports System.ComponentModel.DataAnnotations

Namespace A2Models
    <Schema.Table("Records")>
    Public Class RecordModel

        '* Required for MVC to work correctly
        <Key()>
        Public Property RecordId As Integer
        Public Property AddressBookId As Integer        '* Foreign key for AddressBook

        <Schema.ForeignKey("AddressBookId")>
        Public Property AddressBook As A2Models.AddressBookModel

        '* wrapper object for the DLL message class
        'Dim record As A1ClassLibraryCS.RecordA2
        Dim recordState As ModelStateDictionary

        Dim _userName As String

        <Required()>
        <Display(Name:="User Name")>
        Public Property UserName As String
            Get
                Return _userName
            End Get
            Set(value As String)
                If (Not value Is Nothing) Then
                    If (A1ClassLibraryVB.ValidatorA2.validateUserName(value) = True) Then
                        _userName = value
                    Else
                        recordState.AddModelError("UserName", "User Name is of incorrect format")
                    End If
                End If
            End Set
        End Property

        <Display(Name:="Cell Phone Numbers")>
        Public Property CellPhoneNumbers As List(Of A2Models.CellPhoneNumberModel)

        <Display(Name:="Phone Numbers")>
        Public Property PhoneNumbers As List(Of A2Models.PhoneNumberModel)

        <Display(Name:="Email Addresses")>
        Public Property EmailAddresses As List(Of A2Models.EmailModel)

        <Display(Name:="Addresses")>
        Public Property Addresses As List(Of A2Models.AddressModel)

        <Display(Name:="Notes")>
        Public Property Notes As String

        Public Sub New()
            'record = New A1ClassLibraryCS.RecordA2
            recordState = New ModelStateDictionary
            Addresses = New List(Of AddressModel)
            CellPhoneNumbers = New List(Of CellPhoneNumberModel)
            PhoneNumbers = New List(Of PhoneNumberModel)
            EmailAddresses = New List(Of EmailModel)
        End Sub

        Public Sub New(newRecord As A1ClassLibraryCS.RecordA2, id As Integer)
            RecordId = id
            recordState = New ModelStateDictionary
            Addresses = New List(Of AddressModel)
            CellPhoneNumbers = New List(Of CellPhoneNumberModel)
            PhoneNumbers = New List(Of PhoneNumberModel)
            EmailAddresses = New List(Of EmailModel)
            UserName = newRecord.UserName
            Notes = newRecord.Notes

            'record = New A1ClassLibraryCS.RecordA2

            For Each address In newRecord.Addresses
                Dim tempAddress As A2Models.AddressModel = New AddressModel(address, id)
                Addresses.Add(tempAddress)
            Next

            For Each email In newRecord.EmailAddresses
                Dim tempEmail As A2Models.EmailModel = New EmailModel(email, id)
                EmailAddresses.Add(tempEmail)
            Next

            For Each phoneNumber In newRecord.PhoneNumbers
                Dim tempNumber As A2Models.PhoneNumberModel = New PhoneNumberModel(phoneNumber, id)
                PhoneNumbers.Add(tempNumber)
            Next

            For Each cellPhoneNumber In newRecord.CellPhoneNumbers
                Dim tempNumber As A2Models.CellPhoneNumberModel = New CellPhoneNumberModel(cellPhoneNumber, id)
                CellPhoneNumbers.Add(tempNumber)
            Next
        End Sub

        Public ReadOnly Property ModelState() As ModelStateDictionary
            Get
                Return recordState
            End Get
        End Property

    End Class
End Namespace

