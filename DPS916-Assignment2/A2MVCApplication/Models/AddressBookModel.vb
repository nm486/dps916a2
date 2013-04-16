' DPS916 - Visual Basic Course
' Coded By: Raymond Hung and Stanley Tsang
' Assignment 2
' AddressBookModel.vb
' Last Modified April 8 2013

Imports A1ClassLibraryVB
Imports System.ComponentModel.DataAnnotations

Namespace A2Models
    <Schema.Table("AddressBooks")>
    Public Class AddressBookModel

        Dim addressBook As A1ClassLibraryVB.AddressBookA2
        Dim addressBookState As ModelStateDictionary
        Dim _addressBookName As String

        ' Primary key for AddressBook
        <Key()>
        <Display(Name:="Address Book Id")>
        Public Property AddressBookId As Integer

        ' AddressBooks can now be given names to identify them in our MVC application
        <Required()>
        <Display(Name:="Address Book Name")>
        Public Property AddressBookName As String
            Get
                Return _addressBookName
            End Get
            Set(value As String)
                If (A1ClassLibraryVB.ValidatorA2.validateAddressBookName(value) = True) Then
                    _addressBookName = value
                Else
                    addressBookState.AddModelError("AddressBookName", "Please don't try SQL Injection. Thanks.")
                End If
            End Set
        End Property

        Public Sub New()
            addressBook = New AddressBookA2()
            addressBookState = New ModelStateDictionary
            Records = New List(Of A2Models.RecordModel)
        End Sub

        Public Sub New(newAddressBook As A1ClassLibraryVB.AddressBookA2, id As Integer, name As String)
            addressBookState = New ModelStateDictionary
            addressBook = New A1ClassLibraryVB.AddressBookA2
            AddressBookId = id
            AddressBookName = name
            Dim mvcRecordsList As New List(Of A2Models.RecordModel)
            For Each record In newAddressBook.Records
                Dim newRecord As A2Models.RecordModel = New A2Models.RecordModel(record, id)
                mvcRecordsList.Add(newRecord)
            Next
            Records = mvcRecordsList
        End Sub

        Public Property Records As List(Of A2Models.RecordModel)

        Public ReadOnly Property ModelState() As ModelStateDictionary
            Get
                Return addressBookState
            End Get
        End Property
    End Class

End Namespace
