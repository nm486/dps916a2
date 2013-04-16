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

    Private Sub ReseedDatabase()
        Entity.Database.SetInitializer(New DatabaseInitializer("../../App_Data/seedDB.jab"))
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
        Dim createdBook As A2Models.AddressBookModel = DirectCast(DirectCast(controller.Details(2), ViewResult).Model, A2Models.AddressBookModel)
        Assert.AreEqual(createdBook.AddressBookName, validAddressBook.AddressBookName)

    End Sub

    <TestMethod()> Public Sub Create_InvalidAddressBookTest()
        Dim invalidAddressBook = New A2Models.AddressBookModel
        invalidAddressBook.AddressBookName = ""

        'Add it
        Dim result = DirectCast(controller.Create(invalidAddressBook), ViewResult)
        Assert.IsNotNull(result)
        Assert.AreEqual(result.ViewData("Error"), "Please don't try SQL Injection. Thanks.")
    End Sub

    <TestMethod()> Public Sub Edit_ValidAddressBookTest()
        Dim validAddressBook As A2Models.AddressBookModel = DirectCast(DirectCast(controller.Details(1), ViewResult).Model, A2Models.AddressBookModel)
        validAddressBook.AddressBookName = "Changed Name"

        Dim check = DirectCast(DirectCast(controller.Details(1), ViewResult).Model, A2Models.AddressBookModel)
        Assert.AreEqual(check.AddressBookName, "Changed Name")
    End Sub

    <TestMethod()> Public Sub Edit_InvalidAddressBookTest()
        Dim validAddressBook As A2Models.AddressBookModel = DirectCast(DirectCast(controller.Details(1), ViewResult).Model, A2Models.AddressBookModel)
        Dim prevName As String = validAddressBook.AddressBookName
        validAddressBook.AddressBookName = ""

        Dim check = DirectCast(DirectCast(controller.Details(1), ViewResult).Model, A2Models.AddressBookModel)
        Assert.AreNotEqual(check.AddressBookName, "")
        Assert.AreEqual(check.AddressBookName, prevName)
    End Sub

    <TestMethod()> Public Sub Delete_AddressBookTest()
        ' Clean database
        Using addressbooks = New AddressBookContext
            Entity.Database.SetInitializer(New DatabaseInitializer("../../App_Data/seedDB.jab"))
        End Using

        Dim id As Integer = DirectCast(DirectCast(controller.Index(), ViewResult).Model(0), A2Models.AddressBookModel).AddressBookId
        controller.DeleteConfirmed(id)

        Dim result = controller.Details(id)
        Assert.IsNull(result)
    End Sub

End Class
