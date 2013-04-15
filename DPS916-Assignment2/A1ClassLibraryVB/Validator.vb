' DPS916 - Visual Basic Course
' Coded By: Raymond Hung and Stanley Tsang
' Assignment 1
' Validator.vb
' Last Modified February 20 2013

Imports System.Text.RegularExpressions

Public Class Validator

    Shared userNameExpression As New System.Text.RegularExpressions.Regex("[^a-zA-z0-9 _]+")
    Shared emailFormatExpression1 As New System.Text.RegularExpressions.Regex("^([0-9a-zA-Z]+@myseneca.ca)$")
    Shared emailFormatExpression2 As New System.Text.RegularExpressions.Regex("^([0-9a-zA-Z]([.]{0,1}[0-9a-zA-Z])*@senecacollege.on.ca)$")
    Shared phoneExpression1 As New System.Text.RegularExpressions.Regex("^\d{10}$")
    Shared phoneExpression2 As New System.Text.RegularExpressions.Regex("^\(\d{3}\)[ ]?\d{3}[ -]\d{4}$")
    Shared addressExpression As New System.Text.RegularExpressions.Regex("^\d+ [0-9a-zA-Z ]*[.]?$")

    Public Shared Function validateUserName(ByVal value As String) As Boolean
        Return Not userNameExpression.IsMatch(value)
    End Function

    Public Shared Function validateEmail(ByVal value As String) As Boolean
        Return emailFormatExpression1.IsMatch(value) Or emailFormatExpression2.IsMatch(value)
    End Function

    Public Shared Function validatePhone(ByVal value As String) As Boolean
        Return phoneExpression1.IsMatch(value) Or phoneExpression2.IsMatch(value)
    End Function

    Public Shared Function validateAddress(ByVal value As String) As Boolean
        Return addressExpression.IsMatch(value)
    End Function

End Class

