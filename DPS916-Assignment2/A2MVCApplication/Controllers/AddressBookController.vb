Imports System.Data.Entity
Imports A2MVCApplication.A2Models

Namespace A2MVCApplication
    Public Class AddressBookController
        Inherits System.Web.Mvc.Controller

        Private db As New AddressBookContext

        '
        ' GET: /AddressBook/

        Function Index() As ActionResult
            Dim dbCopy = New AddressBookContext
            For Each item In db.AddressBooks
                Dim addressBook = item
                Dim id = addressBook.AddressBookId
                Dim records = dbCopy.Records.Where(Function(r) r.AddressBookId = id).ToList()
                addressBook.Records = records
            Next
            Return View(db.AddressBooks.ToList())
        End Function

        '
        ' GET: /AddressBook/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim dbCopy = New AddressBookContext
            Dim addressbookmodel As AddressBookModel = db.AddressBooks.Find(id)
            If IsNothing(addressbookmodel) Then
                Return HttpNotFound()
            End If

            Dim records = dbCopy.Records.Where(Function(r) r.AddressBookId = id).ToList()
            addressbookmodel.Records = records

            Return View(addressbookmodel)
        End Function

        '
        ' GET: /AddressBook/Create

        Function Create() As ActionResult
            Return View()
        End Function

        '
        ' POST: /AddressBook/Create

        <HttpPost()> _
        Function Create(ByVal addressbookmodel As AddressBookModel) As ActionResult
            If ModelState.IsValid Then
                db.AddressBooks.Add(addressbookmodel)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            '* MF: This means an exception occurred
            ViewData("Error") = addressbookmodel.ModelState("AddressBookName").Errors(0).ErrorMessage

            Return View(addressbookmodel)
        End Function

        '
        ' GET: /AddressBook/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim addressbookmodel As AddressBookModel = db.AddressBooks.Find(id)
            If IsNothing(addressbookmodel) Then
                Return HttpNotFound()
            End If
            Return View(addressbookmodel)
        End Function

        '
        ' POST: /AddressBook/Edit/5

        <HttpPost()> _
        Function Edit(ByVal addressbookmodel As AddressBookModel) As ActionResult
            If ModelState.IsValid Then
                db.Entry(addressbookmodel).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(addressbookmodel)
        End Function

        '
        ' GET: /AddressBook/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim addressbookmodel As AddressBookModel = db.AddressBooks.Find(id)
            If IsNothing(addressbookmodel) Then
                Return HttpNotFound()
            End If
            Return View(addressbookmodel)
        End Function

        '
        ' POST: /AddressBook/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim addressbookmodel As AddressBookModel = db.AddressBooks.Find(id)
            db.AddressBooks.Remove(addressbookmodel)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace