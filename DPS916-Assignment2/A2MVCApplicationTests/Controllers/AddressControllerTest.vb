Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports A2MVCApplication.A2MVCApplication
Imports A2MVCApplication

<TestClass()> Public Class AddressControllerTest

    Dim controller As AddressController
    Dim testAddress As A2MVCApplication.A2Models.AddressModel

    Dim db As New AddressBookContext

    <TestInitialize()>
    Public Sub Initialize()
        AppDomain.CurrentDomain.SetData("DataDirectory", Environment.CurrentDirectory)
        controller = New AddressController()
        Dim testRecord As A2Models.RecordModel
        Dim abController = New AddressBookController()
        Dim rController = New RecordController()
        Dim ab = New A2Models.AddressBookModel()
        ab.AddressBookName = "Test Book"
        abController.Create(ab)
        Dim tempAB = db.AddressBooks.FirstOrDefault(Function(t) t.AddressBookName = "Test Book")
        testRecord = New A2Models.RecordModel()
        testRecord.UserName = "Test User Address"
        testRecord.AddressBookId = tempAB.AddressBookId
        rController.Create(testRecord)
    End Sub

    <TestCleanup>
    Public Sub CleanUp()
        controller = Nothing
    End Sub

    Private Sub ReseedDatabase()
        Entity.Database.SetInitializer(New DatabaseInitializer("../../App_Data/seedDB.jab"))
    End Sub

    <TestMethod()>
    Public Sub Create_ValidAddressTest()
        ReseedDatabase()
        testAddress = New A2Models.AddressModel()
        testAddress.Text = "70 The Pond Road"
        testAddress.RecordId = db.Records.First().RecordId

        Assert.IsTrue(testAddress.ModelState.IsValid())
        Dim result = controller.Create(testAddress)
        Assert.IsNotNull(result)
        Dim createdAddress As A2Models.AddressModel = db.Addresses.FirstOrDefault(Function(t) t.Text = "70 The Pond Road")
        Assert.AreEqual(createdAddress.Text, testAddress.Text)
        Assert.IsTrue(createdAddress.ModelState.IsValid())
    End Sub

    <TestMethod()>
    Public Sub Create_InvalidAddressTest()
        ReseedDatabase()
        testAddress = New A2Models.AddressModel()
        testAddress.Text = "70! The Pond Road"
        testAddress.RecordId = db.Records.First().RecordId
        Assert.IsFalse(testAddress.ModelState.IsValid())
        Dim result = DirectCast(DirectCast(controller.Create(testAddress), ViewResult).Model, A2Models.AddressModel)
        Assert.IsFalse(result.ModelState.IsValid())
    End Sub

    <TestMethod()>
    Public Sub Edit_ValidAddressTest()
        ReseedDatabase()
        testAddress = db.Addresses.FirstOrDefault()
        Dim id = testAddress.AddressId
        testAddress.Text = "1800 Testing Road"
        controller.Edit(testAddress)

        Dim result = DirectCast(DirectCast(controller.Details(id), ViewResult).Model, A2Models.AddressModel)

        Assert.IsNotNull(result)
        Assert.AreEqual(testAddress.Text, result.Text)
    End Sub

    <TestMethod()>
    Public Sub Edit_InvalidAddressTest()
        ReseedDatabase()
        testAddress = db.Addresses.FirstOrDefault()
        Dim id = testAddress.AddressId
        Dim check = testAddress.Text
        testAddress.Text = "1800@ Testing Road"
        controller.Edit(testAddress)

        Dim result = DirectCast(DirectCast(controller.Details(id), ViewResult).Model, A2Models.AddressModel)
        Assert.AreEqual(result.Text, check)

    End Sub

    <TestMethod()>
    Public Sub Delete_AddressTest()
        ReseedDatabase()
        testAddress = New A2Models.AddressModel()
        testAddress.Text = "24 Sussex Drive"
        testAddress.RecordId = db.Records.First().RecordId
        controller.Create(testAddress)
        Dim pRecordId = db.Addresses.FirstOrDefault(Function(t) t.Text = testAddress.Text).RecordId
        controller.Delete(pRecordId)
        controller.DeleteConfirmed(pRecordId)
        Dim result = controller.Details(pRecordId)
        Assert.IsTrue(TypeOf (result) Is HttpNotFoundResult)
    End Sub
End Class
