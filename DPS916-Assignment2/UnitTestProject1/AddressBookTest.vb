Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports A1ClassLibraryVB
Imports A1ClassLibraryCS

<TestClass()> Public Class UnitTest1

    Dim eventThrown As Boolean
    Dim WithEvents testAddressBook As AddressBook

    ' called before each test case
    <TestInitialize()> Public Sub Initialize()
        testAddressBook = New AddressBook()
        Dim record1 As New RecordA1()
        record1.UserName = "stsang5"
        record1.EmailAddresses.Add("stsang5@myseneca.ca")
        testAddressBook.createRecord(record1)
    End Sub

    ' called after each test case
    <TestCleanup()> Public Sub CleanUp()
        eventThrown = False
        testAddressBook = Nothing
    End Sub

    <TestMethod()> Public Sub TestCreateRecord()
        Assert.IsTrue(eventThrown)
    End Sub

    <TestMethod()> Public Sub TestUpdateRecord()
        eventThrown = False
        Dim record2 As New RecordA1()
        record2.UserName = "stsang2"
        record2.EmailAddresses.Add("stsang2@senecacollege.on.ca")
        testAddressBook.updateRecord(0, record2)
        Assert.IsTrue(eventThrown)
        Assert.AreEqual("stsang2", testAddressBook.Records(0).UserName)
    End Sub

    <TestMethod()> Public Sub TestDeleteRecord()
        eventThrown = False
        testAddressBook.deleteRecord(0)
        Assert.IsTrue(eventThrown)
        Assert.AreEqual(0, testAddressBook.Records.Count)
    End Sub

    <TestMethod()> Public Sub TestGetRecords()
        Dim record2 As New RecordA1()
        record2.UserName = "stsang2"
        record2.EmailAddresses.Add("stsang2@senecacollege.on.ca")
        testAddressBook.createRecord(record2)
        eventThrown = False
        Dim userNameList As List(Of String) = testAddressBook.getAllUserNames()
        Assert.IsTrue(eventThrown)
        Assert.AreEqual(2, userNameList.Count)
    End Sub

    ' Test that sorting works
    <TestMethod()> Public Sub TestRecordSorting()
        Dim record2 As New RecordA1()
        record2.UserName = "stsang2"
        record2.EmailAddresses.Add("stsang2@senecacollege.on.ca")
        testAddressBook.createRecord(record2)
        Dim record3 As New RecordA1()
        record3.UserName = "stsang3"
        record3.EmailAddresses.Add("stsang3@senecacollege.on.ca")
        testAddressBook.createRecord(record3)
        Assert.AreEqual("stsang2", testAddressBook.Records(0).UserName)
        Assert.AreEqual("stsang2@senecacollege.on.ca", testAddressBook.Records(0).EmailAddresses(0))
    End Sub

    ' Test that JSONSerializer can write
    <TestMethod()> Public Sub TestWriteTOJSON()
        Dim record2 As New RecordA1()
        record2.UserName = "stsang2"
        record2.EmailAddresses.Add("stsang2@senecacollege.on.ca")
        testAddressBook.createRecord(record2)
        Dim record3 As New RecordA1()
        record3.UserName = "stsang3"
        record3.EmailAddresses.Add("stsang3@senecacollege.on.ca")
        testAddressBook.createRecord(record3)
        Dim result As Boolean = testAddressBook.writeToJSON("test.txt")
        Assert.IsTrue(result)
    End Sub

    ' Test that JSONSerializer can read
    <TestMethod()> Public Sub TestReadFromJSON()
        Dim testAddressBook2 As New AddressBook()
        Dim result As Boolean = testAddressBook2.readFromJSON("test.txt")
        Assert.IsTrue(result)
        Assert.AreEqual("stsang2", testAddressBook2.Records(0).UserName)
        Assert.AreEqual("stsang2@senecacollege.on.ca", testAddressBook2.Records(0).EmailAddresses(0))
    End Sub

    ' Test that JSONSerializer can read
    <TestMethod(), ExpectedException(GetType(System.IO.FileNotFoundException))> Public Sub TestReadFromJSONGoodInvalidFile()
        Dim testAddressBook2 As New AddressBook()
        testAddressBook2.readFromJSON("fake.txt")
    End Sub

    ' createSuccess Event handler - turns global variable eventThrown into true
    Private Sub TestAddressBook_createSuccessEvent() Handles testAddressBook.createSuccessEvent
        eventThrown = True
    End Sub

    ' createSuccess Event handler - turns global variable eventThrown into true
    Private Sub TestAddressBook_updateSuccessEvent() Handles testAddressBook.updateSuccessEvent
        eventThrown = True
    End Sub

    ' createSuccess Event handler - turns global variable eventThrown into true
    Private Sub TestAddressBook_deleteSuccessEvent() Handles testAddressBook.deleteSuccessEvent
        eventThrown = True
    End Sub

    ' createSuccess Event handler - turns global variable eventThrown into true
    Private Sub TestAddressBook_getSuccessEvent() Handles testAddressBook.getSuccessEvent
        eventThrown = True
    End Sub
End Class