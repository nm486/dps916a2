Imports System.Data.Entity
Imports A2MVCApplication.A2Models

Namespace A2MVCApplication
    Public Class RecordController
        Inherits System.Web.Mvc.Controller

        Private db As New AddressBookContext

        '
        ' GET: /Record/

        Function Index() As ActionResult
            Dim records = db.Records.Include(Function(r) r.AddressBook)
            ViewData("IndexMilestone") = "Record Index"
            Return View(records.ToList())
        End Function

        '
        ' GET: /Record/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim dbCopy = New AddressBookContext
            Dim recordmodel As RecordModel = db.Records.Find(id)
            If IsNothing(recordmodel) Then
                Return HttpNotFound()
            End If
            ' Populate all properties of current record from DB
            Dim emails = dbCopy.Emails.Where(Function(e) e.RecordId = recordmodel.RecordId).ToList()
            recordmodel.EmailAddresses = emails

            Dim phoneNumbers = dbCopy.PhoneNumbers.Where(Function(e) e.RecordId = recordmodel.RecordId).ToList()
            recordmodel.PhoneNumbers = phoneNumbers

            Dim cellPhoneNumbers = dbCopy.CellPhoneNumbers.Where(Function(e) e.RecordId = recordmodel.RecordId).ToList()
            recordmodel.CellPhoneNumbers = cellPhoneNumbers

            Dim addresses = dbCopy.Addresses.Where(Function(e) e.RecordId = recordmodel.RecordId).ToList()
            recordmodel.Addresses = addresses

            Return View(recordmodel)
        End Function

        '
        ' GET: /Record/Create

        Function Create(Optional ByVal id As Integer = Nothing) As ActionResult
            ViewData("id") = id
            ViewBag.AddressBookId = New SelectList(db.AddressBooks, "AddressBookId", "AddressBookId")
            Return View()
        End Function

        '
        ' POST: /Record/Create

        <HttpPost()> _
        Function Create(ByVal recordmodel As RecordModel) As ActionResult
            ModelState.Merge(recordmodel.ModelState)
            If ModelState.IsValid Then
                db.Records.Add(recordmodel)
                db.SaveChanges()
                Return RedirectToAction("Details", "AddressBook", New With {.id = recordmodel.AddressBookId})
            End If
            ViewBag.AddressBookId = New SelectList(db.AddressBooks, "AddressBookId", "AddressBookId", recordmodel.AddressBookId)
            Return View(recordmodel)
        End Function

        '
        ' GET: /Record/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim dbCopy = New AddressBookContext
            Dim recordmodel As RecordModel = db.Records.Find(id)
            If IsNothing(recordmodel) Then
                Return HttpNotFound()
            End If

            Dim emails = dbCopy.Emails.Where(Function(e) e.RecordId = recordmodel.RecordId).ToList()
            recordmodel.EmailAddresses = emails

            Dim phoneNumbers = dbCopy.PhoneNumbers.Where(Function(e) e.RecordId = recordmodel.RecordId).ToList()
            recordmodel.PhoneNumbers = phoneNumbers

            Dim cellPhoneNumbers = dbCopy.CellPhoneNumbers.Where(Function(e) e.RecordId = recordmodel.RecordId).ToList()
            recordmodel.CellPhoneNumbers = cellPhoneNumbers

            Dim addresses = dbCopy.Addresses.Where(Function(e) e.RecordId = recordmodel.RecordId).ToList()
            recordmodel.Addresses = addresses

            ViewBag.AddressBookId = New SelectList(db.AddressBooks, "AddressBookId", "AddressBookId", recordmodel.AddressBookId)
            Return View(recordmodel)
        End Function

        '
        ' POST: /Record/Edit/5

        <HttpPost()> _
        Function Edit(ByVal recordmodel As RecordModel) As ActionResult
            ModelState.Merge(recordmodel.ModelState)
            If ModelState.IsValid Then
                Dim dbCopy = New AddressBookContext
                ' Need to repopulate the remaining properties of the record before trying to update the DB otherwise we get errors
                If recordmodel.CellPhoneNumbers.Count = 0 Then
                    Dim cellPhoneNumbers = dbCopy.CellPhoneNumbers.Where(Function(e) e.RecordId = recordmodel.RecordId).ToList()
                    recordmodel.CellPhoneNumbers = cellPhoneNumbers
                End If
                If recordmodel.EmailAddresses.Count = 0 Then
                    Dim emails = dbCopy.Emails.Where(Function(e) e.RecordId = recordmodel.RecordId).ToList()
                    recordmodel.EmailAddresses = emails
                End If
                If recordmodel.Addresses.Count = 0 Then
                    Dim addresses = dbCopy.Addresses.Where(Function(e) e.RecordId = recordmodel.RecordId).ToList()
                    recordmodel.Addresses = addresses
                End If
                If recordmodel.PhoneNumbers.Count = 0 Then
                    Dim phoneNumbers = dbCopy.PhoneNumbers.Where(Function(e) e.RecordId = recordmodel.RecordId).ToList()
                    recordmodel.PhoneNumbers = phoneNumbers
                End If
                db.Entry(recordmodel).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Details", "AddressBook", New With {.id = recordmodel.AddressBookId})
            End If

            ViewBag.AddressBookId = New SelectList(db.AddressBooks, "AddressBookId", "AddressBookId", recordmodel.AddressBookId)
            Return View(recordmodel)
        End Function

        '
        ' GET: /Record/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim recordmodel As RecordModel = db.Records.Find(id)
            If IsNothing(recordmodel) Then
                Return HttpNotFound()
            End If
            Return View(recordmodel)
        End Function

        '
        ' POST: /Record/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim recordmodel As RecordModel = db.Records.Find(id)
            db.Records.Remove(recordmodel)
            db.SaveChanges()
            Return RedirectToAction("Details", "AddressBook", New With {.id = recordmodel.AddressBookId})
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace