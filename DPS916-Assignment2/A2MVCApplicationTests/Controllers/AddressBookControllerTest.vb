Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports A2MVCApplication.A2MVCApplication
Imports A2MVCApplication

<TestClass()> Public Class AddressBookControllerTest

    Dim controller As AddressBookController
    Dim testAddressBook As A2MVCApplication.A2Models.AddressBookModel

    <TestInitialize()>
    Public Sub Initialize()
        AppDomain.CurrentDomain.SetData("DataDirectory", Environment.CurrentDirectory)
        ' Debug line
        'Console.WriteLine("DataDirectory is: {0}", Environment.CurrentDirectory)
        controller = New AddressBookController()
    End Sub

    <TestCleanup>
    Public Sub CleanUp()
        controller = Nothing
    End Sub

    <TestMethod> Public Sub AddressBookController_SeedFromJson()
        Using addressbooks = New AddressBookContext
            Entity.Database.SetInitializer(New DatabaseInitializer("../../App_Data/seedDB.jab"))
            Dim result As ViewResult = controller.Index
            Assert.IsNotNull(result)
        End Using
    End Sub

    <TestMethod()> Public Sub AddressBookController_IndexTest()
        
        Dim result As ViewResult = DirectCast(controller.Index(), ViewResult)

        ' Assert
        Assert.IsNotNull(result)
        Assert.AreEqual(result.ViewData("IndexMilestone"), "Address Book Index")
    End Sub

    <TestMethod()> Public Sub AddressBookController_FirstValueCheck()
        Dim addressBook As A2Models.AddressBookModel = DirectCast(controller.Index(), ViewResult).Model(0)

        Assert.IsNotNull(addressBook)
        Assert.IsNotNull(addressBook.AddressBookId)
        Assert.IsNotNull(addressBook.AddressBookName)

    End Sub

    <TestMethod()> Public Sub Create_ValidAddressBookTest()
        Dim validAddressBook = New A2Models.AddressBookModel
        validAddressBook.AddressBookName = "DPS916 Address Book"

        ' Add it
        Dim result = controller.Create(validAddressBook)
        Dim createdBook As A2Models.AddressBookModel = DirectCast(DirectCast(controller.Details, ViewResult).Model, A2Models.AddressBookModel)
        Assert.AreEqual(createdBook.AddressBookName, validAddressBook.AddressBookName)

    End Sub

    <TestMethod()> Public Sub Create_InvalidAddressBookTest()

    End Sub

    <TestMethod()> Public Sub Edit_ValidAddressBookTest()

    End Sub

    <TestMethod()> Public Sub Edit_InvalidAddressBookTest()

    End Sub

    <TestMethod()> Public Sub Delete_AddressBookTest()

    End Sub

End Class
