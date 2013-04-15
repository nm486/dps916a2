Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports A1ClassLibraryVB

<TestClass()> Public Class ValidatorTest

    Dim testValidator As Validator

    ' called before each test case
    <TestInitialize()> Public Sub Initialize()
    End Sub

    ' called after each test case
    <TestCleanup()> Public Sub CleanUp()
    End Sub

    <TestMethod()> Public Sub TestUserNameValidationGood()
        Assert.IsTrue(Validator.validateUserName("stsang1"))
    End Sub

    <TestMethod()> Public Sub TestUserNameValidationBad()
        Assert.IsFalse(Validator.validateUserName("@st 541"))
    End Sub

    <TestMethod()> Public Sub TestEmailFormat1ValidationGood()
        Assert.IsTrue(Validator.validateEmail("stsang1@myseneca.ca"))
    End Sub

    <TestMethod()> Public Sub TestEmailFormat1ValidationBad()
        Assert.IsFalse(Validator.validateEmail("stsang1-bad@senecacollege.on.ca"))
    End Sub

    <TestMethod()> Public Sub TestEmailFormat2ValidationGood()
        Assert.IsTrue(Validator.validateEmail("stanley.tsang@senecacollege.on.ca"))
    End Sub

    <TestMethod()> Public Sub TestEmailFormat2ValidationBad()
        Assert.IsFalse(Validator.validateEmail("stsang1-bad@myseneca.on.ca"))
    End Sub

    <TestMethod()> Public Sub TestPhoneNumberValidationGood()
        Assert.IsTrue(Validator.validatePhone("1234567890"))
    End Sub


    <TestMethod()> Public Sub TestPhoneNumberValidationBad()
        Assert.IsFalse(Validator.validatePhone("7412058"))
    End Sub

    <TestMethod()> Public Sub TestPhoneNumberWithCharactersValidationGood()
        Assert.IsTrue(Validator.validatePhone("(123) 456-7890"))
    End Sub

    <TestMethod()> Public Sub TestPhoneNumberWithCharactersValidationBad()
        Assert.IsFalse(Validator.validatePhone("(123( 456-7890"))
    End Sub

    <TestMethod()> Public Sub TestAddressValidationGood()
        Assert.IsTrue(Validator.validateAddress("70 The Pond Road"))
    End Sub

    <TestMethod()> Public Sub TestAddressWithPeriodValidationGood()
        Assert.IsTrue(Validator.validateAddress("70 The Pond Road."))
    End Sub

    <TestMethod()> Public Sub TestAddressWithNoNumberValidationBad()
        Assert.IsFalse(Validator.validateAddress("The Pond Road"))
    End Sub

    <TestMethod()> Public Sub TestAddressWithQuestionMarkValidationBad()
        Assert.IsFalse(Validator.validateAddress("70 The Pond Road?"))
    End Sub

End Class