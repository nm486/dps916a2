Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports A2MVCApplication.A2MVCApplication
Imports A2MVCApplication

<TestClass()> Public Class EmailControllerTest

    Dim controller As EmailController
    Dim testEmail As A2MVCApplication.A2Models.EmailModel
    Dim testRecord As A2Models.RecordModel
    Dim db As New AddressBookContext

    <TestInitialize()>
    Public Sub Initialize()
        AppDomain.CurrentDomain.SetData("DataDirectory", Environment.CurrentDirectory)
        controller = New EmailController()
        If (testRecord Is Nothing) Then
            Dim abController = New AddressBookController()
            Dim rController = New RecordController()
            Dim ab = New A2Models.AddressBookModel()
            ab.AddressBookName = "Test Book"
            abController.Create(ab)
            Dim tempAB = db.AddressBooks.FirstOrDefault(Function(t) t.AddressBookName = "Test Book")
            testRecord = New A2Models.RecordModel()
            testRecord.UserName = "Test User Email"
            testRecord.AddressBookId = tempAB.AddressBookId
            rController.Create(testRecord)
            testRecord = db.Records.FirstOrDefault(Function(t) t.UserName = "Test User")
        End If
    End Sub

    <TestCleanup>
    Public Sub CleanUp()
        controller = Nothing
    End Sub

    Private Sub ReseedDatabase()
        Entity.Database.SetInitializer(New DatabaseInitializer("../../App_Data/seedDB.jab"))
    End Sub

    <TestMethod()>
    Public Sub Create_ValidEmailTest()
        testEmail = New A2Models.EmailModel()
        testEmail.Text = "testblahblah@seneca.ca"
        testEmail.RecordId = testRecord.RecordId

        Assert.IsTrue(testEmail.ModelState.IsValid())
        Dim result = controller.Create(testEmail)
        Assert.IsNotNull(result)
        Dim createdEmail As A2Models.EmailModel = db.Emails.FirstOrDefault(Function(t) t.Text = "testblahblah@seneca.ca")
        Assert.AreEqual(createdEmail.Text, testEmail.Text)
        Assert.IsTrue(createdEmail.ModelState.IsValid())
    End Sub

    <TestMethod()>
    Public Sub Create_InvalidEmailTest()
        testEmail = New A2Models.EmailModel()
        testEmail.Text = "Hello@seneca.eu"
        testEmail.RecordId = testRecord.RecordId
        Assert.IsFalse(testEmail.ModelState.IsValid())
        Dim result = DirectCast(DirectCast(controller.Create(testEmail), ViewResult).Model, A2Models.EmailModel)
        Assert.IsFalse(result.ModelState.IsValid())
    End Sub

    <TestMethod()>
    Public Sub Edit_ValidEmailTest()
        testEmail = db.Emails.FirstOrDefault()
        Dim id = testEmail.EmailId
        testEmail.Text = "validemail@seneca.com"
        controller.Edit(testEmail)

        Dim result = DirectCast(DirectCast(controller.Details(id), ViewResult).Model, A2Models.EmailModel)

        Assert.IsNotNull(result)
        Assert.AreEqual(testEmail.Text, result.Text)
    End Sub

    <TestMethod()>
    Public Sub Edit_InvalidEmailTest()
        testEmail = db.Emails.FirstOrDefault()
        Dim id = testEmail.EmailId
        Dim check = testEmail.Text
        testEmail.Text = "invalidemail@seneca.eu"
        controller.Edit(testEmail)

        Dim result = DirectCast(DirectCast(controller.Details(id), ViewResult).Model, A2Models.EmailModel)
        Assert.AreEqual(result.Text, check)

    End Sub

    <TestMethod()>
    Public Sub Delete_EmailTest()
        ReseedDatabase()
        testEmail = New A2Models.EmailModel()
        testEmail.Text = "deletemepls@seneca.org"
        testEmail.RecordId = db.Records.FirstOrDefault().RecordId
        controller.Create(testEmail)
        Dim pRecordId = db.Emails.FirstOrDefault(Function(t) t.Text = "deletemepls@seneca.org").RecordId
        controller.Delete(pRecordId)
        controller.DeleteConfirmed(pRecordId)
        Dim result = controller.Details(pRecordId)
        Assert.IsTrue(TypeOf (result) Is HttpNotFoundResult)
    End Sub
End Class
