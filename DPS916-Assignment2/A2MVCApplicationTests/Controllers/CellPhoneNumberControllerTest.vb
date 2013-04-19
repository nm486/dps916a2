Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports A2MVCApplication.A2MVCApplication
Imports A2MVCApplication

<TestClass()> Public Class CellCellPhoneNumberControllerTest

    Dim controller As CellPhoneNumberController
    Dim testCellPhoneNumber As A2MVCApplication.A2Models.CellPhoneNumberModel
    Dim testRecord As A2Models.RecordModel
    Dim db As New AddressBookContext

    <TestInitialize()>
    Public Sub Initialize()
        AppDomain.CurrentDomain.SetData("DataDirectory", Environment.CurrentDirectory)
        controller = New CellPhoneNumberController()
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
    Public Sub Create_ValidCellPhoneTest()
        testCellPhoneNumber = New A2Models.CellPhoneNumberModel()
        testCellPhoneNumber.Text = "4165555555"
        testCellPhoneNumber.RecordId = testRecord.RecordId

        Assert.IsTrue(testCellPhoneNumber.ModelState.IsValid())
        Dim result = controller.Create(testCellPhoneNumber)
        Assert.IsNotNull(result)
        Dim createdCellPhoneNumber As A2Models.CellPhoneNumberModel = db.CellPhoneNumbers.FirstOrDefault(Function(t) t.Text = "(416) 555-5555")
        Assert.AreEqual(createdCellPhoneNumber.Text, testCellPhoneNumber.Text)
        Assert.IsTrue(createdCellPhoneNumber.ModelState.IsValid())
    End Sub

    <TestMethod()>
    Public Sub Create_InvalidCellPhoneTest()
        testCellPhoneNumber = New A2Models.CellPhoneNumberModel()
        testCellPhoneNumber.Text = "5555555555"
        testCellPhoneNumber.RecordId = testRecord.RecordId

        Dim result = DirectCast(DirectCast(controller.Create(testCellPhoneNumber), ViewResult).Model, A2Models.CellPhoneNumberModel)
        Assert.IsFalse(result.ModelState.IsValid())
    End Sub

    <TestMethod()>
    Public Sub Edit_ValidCellPhoneTest()
        ReseedDatabase()
        testCellPhoneNumber = New A2Models.CellPhoneNumberModel()
        testCellPhoneNumber.Text = "6476543210"
        testCellPhoneNumber.RecordId = testRecord.RecordId
        controller.Create(testCellPhoneNumber)
        Dim editPhone = db.CellPhoneNumbers.FirstOrDefault(Function(t) t.Text = "(647) 654-3210")
        editPhone.Text = "4161234567"
        controller.Edit(editPhone)

        Dim result = DirectCast(DirectCast(controller.Details(editPhone.CellPhoneId), ViewResult).Model, A2Models.CellPhoneNumberModel)
        Assert.AreEqual(editPhone.Text, result.Text)
    End Sub

    <TestMethod()>
    Public Sub Edit_InvalidCellPhoneTest()
        ReseedDatabase()
        testCellPhoneNumber = New A2Models.CellPhoneNumberModel()
        testCellPhoneNumber.Text = "6479999999"
        testCellPhoneNumber.RecordId = testRecord.RecordId
        controller.Create(testCellPhoneNumber)
        Dim editPhone = db.CellPhoneNumbers.FirstOrDefault(Function(t) t.Text = "(647) 999-9999")
        editPhone.Text = "9999999999"
        controller.Edit(editPhone)

        Dim result = DirectCast(DirectCast(controller.Details(editPhone.CellPhoneId), ViewResult).Model, A2Models.CellPhoneNumberModel)
        Assert.AreNotEqual("(999) 999-9999", result.Text)
        Assert.AreEqual("(647) 999-9999", result.Text)
    End Sub

    <TestMethod()>
    Public Sub Delete_CellPhoneTest()
        ReseedDatabase()
        testCellPhoneNumber = New A2Models.CellPhoneNumberModel()
        testCellPhoneNumber.Text = "4167777777"
        testCellPhoneNumber.RecordId = testRecord.RecordId
        controller.Create(testCellPhoneNumber)
        Dim pRecordId = db.CellPhoneNumbers.FirstOrDefault(Function(t) t.Text = "(416) 777-7777").RecordId
        controller.Delete(pRecordId)
        controller.DeleteConfirmed(pRecordId)
        Dim result = controller.Details(pRecordId)
        Assert.IsTrue(TypeOf (result) Is HttpNotFoundResult)
    End Sub

End Class
