Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports A2MVCApplication.A2MVCApplication

<TestClass()> Public Class RecordControllerTest

    <TestMethod()> Public Sub Index()
        ' Arrange
        Dim controller As New RecordController()

        ' Act
        Dim result As ViewResult = DirectCast(controller.Index(), ViewResult)

        ' Assert
        Dim viewData As ViewDataDictionary = result.ViewData
        Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", viewData("Message"))
    End Sub

End Class
