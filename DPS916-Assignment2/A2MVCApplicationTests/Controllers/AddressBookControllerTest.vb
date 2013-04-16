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
        Console.WriteLine("DataDirectory is: {0}", Environment.CurrentDirectory)
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

    <TestMethod()> Public Sub Index()
        ' Arrange
        Dim controller As New AddressBookController()

        ' Act
        Dim result As ViewResult = DirectCast(controller.Index(), ViewResult)

        ' Assert
        Dim viewData As ViewDataDictionary = result.ViewData
        Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", viewData("Message"))
    End Sub

End Class
