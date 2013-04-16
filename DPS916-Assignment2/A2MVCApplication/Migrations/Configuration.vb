Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Namespace Migrations

    Friend NotInheritable Class Configuration 
        Inherits DbMigrationsConfiguration(Of AddressBookContext)

        Public Sub New()
            AutomaticMigrationsEnabled = False
        End Sub

        Protected Overrides Sub Seed(context As AddressBookContext)
            Dim jsonAddressBook As New A1ClassLibraryVB.AddressBookA2
            Dim jsonRecords As New List(Of A1ClassLibraryCS.RecordA2)

            jsonAddressBook.readFromJSON("~/App_Data/seedDB.jab")

            Dim id As Integer = 0

            Dim mvcAddressBook As New A2Models.AddressBookModel(jsonAddressBook, id, "Seed Address Book")

            context.AddressBooks.Add(mvcAddressBook)

            '* Free records
            jsonAddressBook = Nothing
            mvcAddressBook = Nothing

            MyBase.Seed(context)
        End Sub

    End Class

End Namespace
