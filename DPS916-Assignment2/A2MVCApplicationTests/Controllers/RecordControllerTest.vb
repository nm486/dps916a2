Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports A2MVCApplication.A2MVCApplication
Imports A2MVCApplication

<TestClass()> Public Class RecordControllerTest

    Dim controller As RecordController
    Dim testRecord As A2MVCApplication.A2Models.RecordModel
    Dim testAddressBook As A2Models.AddressBookModel
    Dim db As New AddressBookContext
    Dim valid_userName As String = "Test Record User"
    Dim valid_note As String = "Always testing things"

    <TestInitialize()>
    Public Sub Initialize()
        AppDomain.CurrentDomain.SetData("DataDirectory", Environment.CurrentDirectory)
        controller = New RecordController()
        Dim abController = New AddressBookController()
        If (testAddressBook Is Nothing) Then
            testAddressBook = New A2Models.AddressBookModel()
            testAddressBook.AddressBookName = "Test Book"
            abController.Create(testAddressBook)
            testAddressBook = DirectCast(DirectCast(abController.Details(2), ViewResult).Model, A2Models.AddressBookModel)
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
    Public Sub Create_ValidRecordTest()
        ReseedDatabase()
        testRecord = New A2Models.RecordModel()
        testRecord.UserName = valid_userName
        testRecord.Notes = valid_note
        testRecord.AddressBookId = testAddressBook.AddressBookId

        Assert.IsTrue(testRecord.ModelState.IsValid())
        Dim result = controller.Create(testRecord)
        Assert.IsNotNull(result)

        Dim createdRecord As A2Models.RecordModel = db.Records.FirstOrDefault(Function(t) t.UserName = valid_userName)
        Assert.AreEqual(createdRecord.UserName, valid_userName)
        Assert.AreEqual(createdRecord.Notes, valid_note)
        Assert.IsTrue(createdRecord.ModelState.IsValid())
    End Sub

    <TestMethod()>
    Public Sub Create_InvalidRecordTest()
        testRecord = New A2Models.RecordModel()
        testRecord.UserName = "Test User!"
        testRecord.Notes = valid_note
        testRecord.AddressBookId = testAddressBook.AddressBookId

        Dim result = DirectCast(DirectCast(controller.Create(testRecord), ViewResult).Model, A2Models.RecordModel)
        Assert.IsFalse(result.ModelState.IsValid())
    End Sub

    <TestMethod()>
    Public Sub Edit_ValidRecordTest()
        ReseedDatabase()
        testRecord = New A2Models.RecordModel()
        testRecord.UserName = valid_userName
        testRecord.Notes = valid_note
        testRecord.AddressBookId = testAddressBook.AddressBookId
        controller.Create(testRecord)
        Dim editRecord = db.Records.FirstOrDefault(Function(t) t.UserName = valid_userName)
        editRecord.Notes = "This is a new note"
        controller.Edit(editRecord)

        Dim result = db.Records.FirstOrDefault(Function(t) t.UserName = valid_userName)
        Assert.AreEqual(editRecord.Notes, result.Notes)
    End Sub

    <TestMethod()>
    Public Sub Edit_InvalidRecordTest()
        ReseedDatabase()
        testRecord = New A2Models.RecordModel()
        testRecord.UserName = valid_userName
        testRecord.Notes = valid_note
        testRecord.AddressBookId = testAddressBook.AddressBookId
        controller.Create(testRecord)
        Dim editRecord = db.Records.FirstOrDefault(Function(t) t.UserName = valid_userName)
        editRecord.UserName = "Invalid User!"
        Dim result = DirectCast(controller.Edit(editRecord), ViewResult)

        Assert.IsFalse(result.ViewData.ModelState.IsValid())
    End Sub

    <TestMethod()>
    Public Sub Delete_RecordTest()
        ReseedDatabase()
        testRecord = New A2Models.RecordModel()
        testRecord.UserName = valid_userName
        testRecord.Notes = valid_note
        testRecord.AddressBookId = testAddressBook.AddressBookId
        Dim recordId = db.Records.FirstOrDefault(Function(t) t.UserName = valid_userName).RecordId
        controller.Delete(recordId)
        controller.DeleteConfirmed(recordId)
        Dim result = controller.Details(recordId)
        Assert.IsTrue(TypeOf (result) Is HttpNotFoundResult)
    End Sub
End Class
