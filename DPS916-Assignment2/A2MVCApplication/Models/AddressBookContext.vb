' DPS916 - Visual Basic Course
' Coded By: Raymond Hung and Stanley Tsang
' Assignment 2
' AddressBookContext.vb
' Last Modified April 8 2013

Imports System.Data.Entity      '* Important for Code-First
Imports A2MVCApplication.A2Models

' Creates database with tables for AddressBooks, Records, Addresses, CellPhoneNumbers, Emails, and PhoneNumbers
' One to many relationship between AddressBooks and rRecords in DB
' One to many relationship between Records and Addresses, CellPhoneNumbers, Emails, and PhoneNumbers in DB
Public Class AddressBookContext
    Inherits DbContext

    Public Property AddressBooks As DbSet(Of A2Models.AddressBookModel)
    Public Property Records As DbSet(Of A2Models.RecordModel)
    Public Property Addresses As DbSet(Of A2Models.AddressModel)
    Public Property CellPhoneNumbers As DbSet(Of A2Models.CellPhoneNumberModel)
    Public Property Emails As DbSet(Of A2Models.EmailModel)
    Public Property PhoneNumbers As DbSet(Of A2Models.PhoneNumberModel)

End Class
