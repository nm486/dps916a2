Imports System.Data.Entity
Imports A2MVCApplication.A2Models

Namespace A2MVCApplication
    Public Class CellPhoneNumberController
        Inherits System.Web.Mvc.Controller

        Private db As New AddressBookContext

        '
        ' GET: /CellPhoneNumber/

        Function Index() As ActionResult
            Dim cellphonenumbers = db.CellPhoneNumbers.Include(Function(c) c.Record)
            ViewData("IndexMilestone") = "Cell Phone Number Index"
            Return View(cellphonenumbers.ToList())
        End Function

        '
        ' GET: /CellPhoneNumber/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim cellphonenumbermodel As CellPhoneNumberModel = db.CellPhoneNumbers.Find(id)
            If IsNothing(cellphonenumbermodel) Then
                Return HttpNotFound()
            End If
            Return View(cellphonenumbermodel)
        End Function

        '
        ' GET: /CellPhoneNumber/Create

        Function Create(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim record As RecordModel = db.Records.Find(id)
            ViewData("username") = record.UserName
            ViewData("id") = id
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName")
            Return View()
        End Function

        '
        ' POST: /CellPhoneNumber/Create

        <HttpPost()> _
        Function Create(ByVal cellphonenumbermodel As CellPhoneNumberModel) As ActionResult
            ModelState.Merge(cellphonenumbermodel.ModelState)
            If ModelState.IsValid Then
                db.CellPhoneNumbers.Add(cellphonenumbermodel)
                db.SaveChanges()
                Return RedirectToAction("Edit", "Record", New With {.id = cellphonenumbermodel.RecordId})
            End If

            ViewData("Error") = cellphonenumbermodel.ModelState("Text").Errors(0).ErrorMessage
            Dim record As RecordModel = db.Records.Find(cellphonenumbermodel.RecordId)
            ViewData("username") = record.UserName
            ViewData("id") = record.RecordId
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName", cellphonenumbermodel.RecordId)
            Return View(cellphonenumbermodel)
        End Function

        '
        ' GET: /CellPhoneNumber/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim cellphonenumbermodel As CellPhoneNumberModel = db.CellPhoneNumbers.Find(id)
            Dim record As RecordModel = db.Records.Find(id)
            If IsNothing(cellphonenumbermodel) Then
                Return HttpNotFound()
            End If
            ViewData("username") = record.UserName
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName", cellphonenumbermodel.RecordId)
            Return View(cellphonenumbermodel)
        End Function

        '
        ' POST: /CellPhoneNumber/Edit/5

        <HttpPost()> _
        Function Edit(ByVal cellphonenumbermodel As CellPhoneNumberModel) As ActionResult
            ModelState.Merge(cellphonenumbermodel.ModelState)
            If ModelState.IsValid Then
                db.Entry(cellphonenumbermodel).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Edit", "Record", New With {.id = cellphonenumbermodel.RecordId})
            End If

            ViewData("Error") = cellphonenumbermodel.ModelState("Text").Errors(0).ErrorMessage
            Dim record As RecordModel = db.Records.Find(cellphonenumbermodel.RecordId)
            ViewData("username") = record.UserName
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName", cellphonenumbermodel.RecordId)
            Return View(cellphonenumbermodel)
        End Function

        '
        ' GET: /CellPhoneNumber/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim cellphonenumbermodel As CellPhoneNumberModel = db.CellPhoneNumbers.Find(id)
            If IsNothing(cellphonenumbermodel) Then
                Return HttpNotFound()
            End If
            Return View(cellphonenumbermodel)
        End Function

        '
        ' POST: /CellPhoneNumber/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim cellphonenumbermodel As CellPhoneNumberModel = db.CellPhoneNumbers.Find(id)
            db.CellPhoneNumbers.Remove(cellphonenumbermodel)
            db.SaveChanges()
            Return RedirectToAction("Edit", "Record", New With {.id = cellphonenumbermodel.RecordId})
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace