Imports System.Data.Entity      '* Important for Code-First
Imports A2MVCApplication.A2Models

' Creates database with one table, for AddressBooks
Public Class AddressBookContext
    Inherits DbContext

    Public Property AddressBooks As DbSet(Of A2Models.AddressBookModel)
    Public Property Records As DbSet(Of A2Models.RecordModel)
    Public Property Addresses As DbSet(Of A2Models.AddressModel)
    Public Property CellPhoneNumbers As DbSet(Of A2Models.CellPhoneNumberModel)
    Public Property Emails As DbSet(Of A2Models.EmailModel)
    Public Property PhoneNumbers As DbSet(Of A2Models.PhoneNumberModel)

End Class
