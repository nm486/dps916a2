Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports A2MVCApplication.A2MVCApplication
Imports A2MVCApplication

<TestClass()> Public Class PhoneNumberControllerTest

    Dim controller As PhoneNumberController
    Dim testPhoneNumber As A2MVCApplication.A2Models.PhoneNumberModel
    Dim testRecord As A2Models.RecordModel
    Dim db As New AddressBookContext

    <TestInitialize()>
    Public Sub Initialize()
        AppDomain.CurrentDomain.SetData("DataDirectory", Environment.CurrentDirectory)
        controller = New PhoneNumberController()
        If (testRecord Is Nothing) Then
            Dim abController = New AddressBookController()
            Dim rController = New RecordController()
            Dim ab = New A2Models.AddressBookModel()
            ab.AddressBookName = "Test Book"
            abController.Create(ab)
            Dim tempAB = db.AddressBooks.FirstOrDefault(Function(t) t.AddressBookName = "Test Book")
            testRecord = New A2Models.RecordModel()
            testRecord.UserName = "Test User"
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
    Public Sub Create_ValidPhoneTest()
        testPhoneNumber = New A2Models.PhoneNumberModel()
        testPhoneNumber.Text = "5555555555"
        testPhoneNumber.RecordId = testRecord.RecordId

        Assert.IsTrue(testPhoneNumber.ModelState.IsValid())
        Dim result = controller.Create(testPhoneNumber)
        Assert.IsNotNull(result)
        Dim createdPhoneNumber As A2Models.PhoneNumberModel = DirectCast(DirectCast(controller.Details(4), ViewResult).Model, A2Models.PhoneNumberModel)
        Assert.AreEqual(createdPhoneNumber.Text, testPhoneNumber.Text)
        Assert.IsTrue(createdPhoneNumber.ModelState.IsValid())
    End Sub

    <TestMethod()>
    Public Sub Create_InvalidPhoneTest()
        testPhoneNumber = New A2Models.PhoneNumberModel()
        testPhoneNumber.Text = "Hello"
        testPhoneNumber.RecordId = testRecord.RecordId

        Dim result = DirectCast(DirectCast(controller.Create(testPhoneNumber), ViewResult).Model, A2Models.PhoneNumberModel)
        Assert.IsFalse(result.ModelState.IsValid())
    End Sub

    <TestMethod()>
    Public Sub Edit_ValidPhoneTest()
        ReseedDatabase()
        testPhoneNumber = New A2Models.PhoneNumberModel()
        testPhoneNumber.Text = "9876543210"
        testPhoneNumber.RecordId = testRecord.RecordId
        controller.Create(testPhoneNumber)
        testPhoneNumber = db.PhoneNumbers.FirstOrDefault(Function(t) t.Text = "(987) 654-3210")
        testPhoneNumber.Text = "1234567890"
        controller.Edit(testPhoneNumber)

        Dim result = db.PhoneNumbers.FirstOrDefault(Function(t) t.Text = "(123) 456-7890")
        Assert.IsNotNull(result)
        Assert.AreEqual(testPhoneNumber.Text, result.Text)
    End Sub

    <TestMethod()>
    Public Sub Edit_InvalidPhoneTest()
        ReseedDatabase()
        testPhoneNumber = New A2Models.PhoneNumberModel()
        testPhoneNumber.Text = "9999999999"
        testPhoneNumber.RecordId = testRecord.RecordId
        controller.Create(testPhoneNumber)
        Dim editPhone = db.PhoneNumbers.FirstOrDefault(Function(t) t.Text = "(999) 999-9999")
        editPhone.Text = "123456789s"
        controller.Edit(editPhone)

        Dim result = DirectCast(DirectCast(controller.Details(editPhone.PhoneNumberId), ViewResult).Model, A2Models.PhoneNumberModel)
        Assert.AreNotEqual("(123) 456-789s", result.Text)
    End Sub

    <TestMethod()>
    Public Sub Delete_PhoneTest()
        ReseedDatabase()
        testPhoneNumber = New A2Models.PhoneNumberModel()
        testPhoneNumber.Text = "7777777777"
        testPhoneNumber.RecordId = testRecord.RecordId
        controller.Create(testPhoneNumber)
        Dim pRecordId = db.PhoneNumbers.FirstOrDefault(Function(t) t.Text = "(777) 777-7777").RecordId
        controller.Delete(pRecordId)
        controller.DeleteConfirmed(pRecordId)
        Dim result = controller.Details(pRecordId)
        Assert.IsTrue(TypeOf (result) Is HttpNotFoundResult)
    End Sub

End Class
