' DPS916 - Visual Basic Course
' Coded By: Raymond Hung and Stanley Tsang
' Assignment 1
' AddressBook.vb
' Last Modified February 20 2013

Imports A1ClassLibraryCS
Imports Newtonsoft.Json
Imports System.Linq

' The main address book class.  Contains a list of Records and provides functions for manipulating Records.
Public Class AddressBook
    Implements IJSONSerializer

    Dim recordsList As New List(Of RecordA1)

    ' Events that are thrown when Record manipulation functions complete successfully
    Public Event createSuccessEvent()
    Public Event updateSuccessEvent()
    Public Event deleteSuccessEvent()
    Public Event getSuccessEvent()

    ' Read-only property that returns the list of Records
    Public ReadOnly Property Records() As List(Of RecordA1)
        Get
            Return recordsList
        End Get
    End Property

    ' Insert a new record entry into the address book and sort the new list of Records.
    Public Sub createRecord(ByVal record As RecordA1)
        recordsList.Add(record)
        ' Using LINQ to specify the data member of a record to sort by (userName).
        recordsList = recordsList.OrderBy(Function(x) x.UserName).ToList()
        RaiseEvent createSuccessEvent()
    End Sub

    ' Update an existing record by overwriting
    Public Sub updateRecord(ByVal index As Integer, ByVal record As RecordA1)
        recordsList.Item(index) = record
        RaiseEvent updateSuccessEvent()
    End Sub

    ' Delete an entire record from list
    Public Sub deleteRecord(ByVal index As Integer)
        recordsList.RemoveAt(index)
        RaiseEvent deleteSuccessEvent()
    End Sub

    ' Returns all record user names to populate the GUI
    Public Function getAllUserNames() As List(Of String)
        Dim userNameList As New List(Of String)
        For Each record As RecordA1 In recordsList
            userNameList.Add(record.UserName)
        Next
        RaiseEvent getSuccessEvent()
        Return userNameList
    End Function

    ' Implementation of IJSONSerializer interface function.  Reads from a JSON file the serialized version of the records list and populates
    ' this class' records list.
    Public Function readFromJSON(ByVal file As String) As Boolean Implements IJSONSerializer.readFromJSON
        Dim result As Boolean = True
        Using readFile As New IO.StreamReader(file)
            Try
                Dim jsonString As String = readFile.ReadToEnd
                Dim records As List(Of RecordA1) = JsonConvert.DeserializeObject(Of List(Of RecordA1))(jsonString)
                Me.recordsList = records
            Catch ex As Exception
                result = False
            End Try
        End Using
        Return result
    End Function

    ' Implementation of IJSONSerializer interface function.  Writes to a JSON file the serialized version of the records list.
    Public Function writeToJSON(file As String) As Boolean Implements IJSONSerializer.writeToJSON
        Dim result As Boolean = True
        Using writeFile As New IO.StreamWriter(file)
            Try
                Dim jsonString = JsonConvert.SerializeObject(Me.recordsList, Formatting.Indented)
                writeFile.Write(jsonString)
            Catch ex As Exception
                result = False
            End Try
        End Using
        Return result
    End Function

End Class
