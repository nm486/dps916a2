Imports System.Data.Entity
Imports A2MVCApplication.A2Models

Namespace A2MVCApplication
    Public Class PhoneNumberController
        Inherits System.Web.Mvc.Controller

        Private db As New AddressBookContext

        '
        ' GET: /PhoneNumber/

        Function Index() As ActionResult
            Dim phonenumbers = db.PhoneNumbers.Include(Function(p) p.Record)
            Return View(phonenumbers.ToList())
        End Function

        '
        ' GET: /PhoneNumber/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim phonenumbermodel As PhoneNumberModel = db.PhoneNumbers.Find(id)
            If IsNothing(phonenumbermodel) Then
                Return HttpNotFound()
            End If
            Return View(phonenumbermodel)
        End Function

        '
        ' GET: /PhoneNumber/Create

        Function Create(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim record As RecordModel = db.Records.Find(id)
            ViewData("username") = record.UserName
            ViewData("id") = id
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName")
            Return View()
        End Function

        '
        ' POST: /PhoneNumber/Create

        <HttpPost()> _
        Function Create(ByVal phonenumbermodel As PhoneNumberModel) As ActionResult
            ModelState.Merge(phonenumbermodel.ModelState)
            If ModelState.IsValid Then
                db.PhoneNumbers.Add(phonenumbermodel)
                db.SaveChanges()
                Return RedirectToAction("Edit", "Record", New With {.id = phonenumbermodel.RecordId})
            End If

            ViewData("Error") = phonenumbermodel.ModelState("Text").Errors(0).ErrorMessage
            Dim record As RecordModel = db.Records.Find(phonenumbermodel.RecordId)
            ViewData("username") = record.UserName
            ViewData("id") = record.RecordId
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName", phonenumbermodel.RecordId)
            Return View(phonenumbermodel)
        End Function

        '
        ' GET: /PhoneNumber/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim phonenumbermodel As PhoneNumberModel = db.PhoneNumbers.Find(id)
            Dim record As RecordModel = db.Records.Find(id)
            If IsNothing(phonenumbermodel) Then
                Return HttpNotFound()
            End If
            ViewData("username") = record.UserName
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName", phonenumbermodel.RecordId)
            Return View(phonenumbermodel)
        End Function

        '
        ' POST: /PhoneNumber/Edit/5

        <HttpPost()> _
        Function Edit(ByVal phonenumbermodel As PhoneNumberModel) As ActionResult
            ModelState.Merge(phonenumbermodel.ModelState)
            If ModelState.IsValid Then
                db.Entry(phonenumbermodel).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Edit", "Record", New With {.id = phonenumbermodel.RecordId})
            End If

            ViewData("Error") = phonenumbermodel.ModelState("Text").Errors(0).ErrorMessage
            Dim record As RecordModel = db.Records.Find(phonenumbermodel.RecordId)
            ViewData("username") = record.UserName
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName", phonenumbermodel.RecordId)
            Return View(phonenumbermodel)
        End Function

        '
        ' GET: /PhoneNumber/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim phonenumbermodel As PhoneNumberModel = db.PhoneNumbers.Find(id)
            If IsNothing(phonenumbermodel) Then
                Return HttpNotFound()
            End If
            Return View(phonenumbermodel)
        End Function

        '
        ' POST: /PhoneNumber/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim phonenumbermodel As PhoneNumberModel = db.PhoneNumbers.Find(id)
            db.PhoneNumbers.Remove(phonenumbermodel)
            db.SaveChanges()
            Return RedirectToAction("Edit", "Record", New With {.id = phonenumbermodel.RecordId})
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace