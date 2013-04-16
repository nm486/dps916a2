Imports System.Data.Entity
Imports A2MVCApplication.A2Models

Namespace A2MVCApplication
    Public Class AddressController
        Inherits System.Web.Mvc.Controller

        Private db As New AddressBookContext

        '
        ' GET: /Address/

        Function Index() As ActionResult
            Dim addresses = db.Addresses.Include(Function(a) a.Record)
            ViewData("IndexMilestone") = "Address Index"
            Return View(addresses.ToList())
        End Function

        '
        ' GET: /Address/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim addressmodel As AddressModel = db.Addresses.Find(id)
            If IsNothing(addressmodel) Then
                Return HttpNotFound()
            End If
            Return View(addressmodel)
        End Function

        '
        ' GET: /Address/Create

        Function Create(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim record As RecordModel = db.Records.Find(id)
            ViewData("username") = record.UserName
            ViewData("id") = id
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName")
            Return View()
        End Function

        '
        ' POST: /Address/Create

        <HttpPost()> _
        Function Create(ByVal addressmodel As AddressModel) As ActionResult
            ModelState.Merge(addressmodel.ModelState)
            If ModelState.IsValid Then
                db.Addresses.Add(addressmodel)
                db.SaveChanges()
                Return RedirectToAction("Edit", "Record", New With {.id = addressmodel.RecordId})
            End If

            ViewData("Error") = addressmodel.ModelState("Text").Errors(0).ErrorMessage
            Dim record As RecordModel = db.Records.Find(addressmodel.RecordId)
            ViewData("username") = record.UserName
            ViewData("id") = record.RecordId
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName", addressmodel.RecordId)
            Return View(addressmodel)
        End Function

        '
        ' GET: /Address/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim addressmodel As AddressModel = db.Addresses.Find(id)
            Dim record As RecordModel = db.Records.Find(id)
            If IsNothing(addressmodel) Then
                Return HttpNotFound()
            End If
            ViewData("username") = record.UserName
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName", addressmodel.RecordId)
            Return View(addressmodel)
        End Function

        '
        ' POST: /Address/Edit/5

        <HttpPost()> _
        Function Edit(ByVal addressmodel As AddressModel) As ActionResult
            ModelState.Merge(addressmodel.ModelState)
            If ModelState.IsValid Then
                db.Entry(addressmodel).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Edit", "Record", New With {.id = addressmodel.RecordId})
            End If

            ViewData("Error") = addressmodel.ModelState("Text").Errors(0).ErrorMessage
            Dim record As RecordModel = db.Records.Find(addressmodel.RecordId)
            ViewData("username") = record.UserName
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName", addressmodel.RecordId)
            Return View(addressmodel)
        End Function

        '
        ' GET: /Address/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim addressmodel As AddressModel = db.Addresses.Find(id)
            If IsNothing(addressmodel) Then
                Return HttpNotFound()
            End If
            Return View(addressmodel)
        End Function

        '
        ' POST: /Address/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim addressmodel As AddressModel = db.Addresses.Find(id)
            db.Addresses.Remove(addressmodel)
            db.SaveChanges()
            Return RedirectToAction("Edit", "Record", New With {.id = addressmodel.RecordId})
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace