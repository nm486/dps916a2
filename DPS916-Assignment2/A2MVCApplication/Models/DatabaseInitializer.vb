' DPS916 - Visual Basic Course
' Coded By: Raymond Hung and Stanley Tsang
' Assignment 2
' DatabaseInitializer.vb
' Last Modified April 8 2013

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data.Entity
Imports A2MVCApplication.A2Models
Imports A1ClassLibraryCS
Imports A1ClassLibraryVB

Public Class DatabaseInitializer
    Inherits DropCreateDatabaseAlways(Of AddressBookContext)

    Dim jsonFile As String

    Public Sub New()
        jsonFile = HttpContext.Current.Server.MapPath("~/App_Data/seedDB.jab")
    End Sub

    Public Sub New(jsonFilename As String)
        jsonFile = jsonFilename
    End Sub

    Protected Overrides Sub Seed(context As AddressBookContext)

        '* read from json file stored in App_Data folder
        Dim jsonAddressBook As New A1ClassLibraryVB.AddressBookA2
        Dim jsonRecords As New List(Of A1ClassLibraryCS.RecordA2)

        jsonAddressBook.readFromJSON(jsonFile)

        Dim id As Integer = 0

        Dim mvcAddressBook As New A2Models.AddressBookModel(jsonAddressBook, id, "Seed Address Book")
        
        context.AddressBooks.Add(mvcAddressBook)
        
        '* Free records
        jsonAddressBook = Nothing
        mvcAddressBook = Nothing

        MyBase.Seed(context)
    End Sub

End Class
