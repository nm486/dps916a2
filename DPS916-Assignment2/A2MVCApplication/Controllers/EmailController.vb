Imports System.Data.Entity
Imports A2MVCApplication.A2Models

Namespace A2MVCApplication
    Public Class EmailController
        Inherits System.Web.Mvc.Controller

        Private db As New AddressBookContext

        '
        ' GET: /Email/

        Function Index() As ActionResult
            Dim emails = db.Emails.Include(Function(e) e.Record)
            ViewData("IndexMilestone") = "Email Index"
            ViewData("Message") = "Modify this template to jump-start your ASP.NET MVC application."
            Return View(emails.ToList())
        End Function

        '
        ' GET: /Email/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim emailmodel As EmailModel = db.Emails.Find(id)
            If IsNothing(emailmodel) Then
                Return HttpNotFound()
            End If
            Return View(emailmodel)
        End Function

        '
        ' GET: /Email/Create

        Function Create(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim record As RecordModel = db.Records.Find(id)
            ViewData("username") = record.UserName
            ViewData("id") = id
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName")
            Return View()
        End Function

        '
        ' POST: /Email/Create

        <HttpPost()> _
        Function Create(ByVal emailmodel As EmailModel) As ActionResult
            ModelState.Merge(emailmodel.ModelState)
            If ModelState.IsValid Then
                db.Emails.Add(emailmodel)
                db.SaveChanges()
                Return RedirectToAction("Edit", "Record", New With {.id = emailmodel.RecordId})
            End If

            ViewData("Error") = emailmodel.ModelState("Text").Errors(0).ErrorMessage
            Dim record As RecordModel = db.Records.Find(emailmodel.RecordId)
            ViewData("username") = record.UserName
            ViewData("id") = record.RecordId
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName", emailmodel.RecordId)
            Return View(emailmodel)
        End Function

        '
        ' GET: /Email/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim emailmodel As EmailModel = db.Emails.Find(id)
            Dim record As RecordModel = db.Records.Find(id)
            If IsNothing(emailmodel) Then
                Return HttpNotFound()
            End If
            ViewData("username") = record.UserName
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName", emailmodel.RecordId)
            Return View(emailmodel)
        End Function

        '
        ' POST: /Email/Edit/5

        <HttpPost()> _
        Function Edit(ByVal emailmodel As EmailModel) As ActionResult
            ModelState.Merge(emailmodel.ModelState)
            If ModelState.IsValid Then
                db.Entry(emailmodel).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Edit", "Record", New With {.id = emailmodel.RecordId})
            End If

            ViewData("Error") = emailmodel.ModelState("Text").Errors(0).ErrorMessage
            Dim record As RecordModel = db.Records.Find(emailmodel.RecordId)
            ViewData("username") = record.UserName
            ViewBag.RecordId = New SelectList(db.Records, "RecordId", "UserName", emailmodel.RecordId)
            Return View(emailmodel)
        End Function

        '
        ' GET: /Email/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim emailmodel As EmailModel = db.Emails.Find(id)
            If IsNothing(emailmodel) Then
                Return HttpNotFound()
            End If
            Return View(emailmodel)
        End Function

        '
        ' POST: /Email/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim numOfEmails = db.Emails.Include(Function(t) t.RecordId).Count()
            Dim emailmodel As EmailModel = db.Emails.Find(id)
            If (numOfEmails > 1) Then
                db.Emails.Remove(emailmodel)
                db.SaveChanges()
            End If
            ' Consider adding a message to indicate deletion cannot be done if only 1 email.
            Return RedirectToAction("Edit", "Record", New With {.id = emailmodel.RecordId})
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace