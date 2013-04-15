' DPS916 - Visual Basic Course
' Coded By: Raymond Hung and Stanley Tsang
' Assignment 1
' Validator.vb
' Last Modified April 8 2013

Imports System.Text.RegularExpressions

Public Class ValidatorA2

    ' UserName, Email, and Cell Phone formats New for Assignment 2
    Shared userNameExpression As New System.Text.RegularExpressions.Regex("^([ \u00c0-\u01ffa-zA-Z'\-])+$")
    Shared emailFormatExpression1 As New System.Text.RegularExpressions.Regex("^([0-9a-zA-Z]+@[0-9a-zA-Z]+.(com|ca|org|net|biz|info))$")
    Shared emailFormatExpression2 As New System.Text.RegularExpressions.Regex("^([0-9a-zA-Z]+@[0-9a-zA-Z]+.[0-9a-zA-Z]+.(com|ca|org|net|biz|info))$")
    Shared cellPhoneExpression As New System.Text.RegularExpressions.Regex("^(416|647|905)\d{7}$")
    Shared addressBookNameExpression As New System.Text.RegularExpressions.Regex("/\w*((\%27)|(\'))((\%6F)|o|(\%4F))((\%72)|r|(\%52))/ix ")

    Shared phoneExpression1 As New System.Text.RegularExpressions.Regex("^\d{10}$")
    Shared phoneExpression2 As New System.Text.RegularExpressions.Regex("^\(\d{3}\)[ ]?\d{3}[ -]\d{4}$")
    Shared addressExpression As New System.Text.RegularExpressions.Regex("^\d+ [0-9a-zA-Z ]*[.]?$")

    Public Shared Function validateUserName(ByVal value As String) As Boolean
        Return userNameExpression.IsMatch(value)
    End Function

    Public Shared Function validateAddressBookName(ByVal value As String) As Boolean
        Return Not addressBookNameExpression.IsMatch(value)
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

    Public Shared Function validateCellPhoneNumber(ByVal value As String) As Boolean
        Return cellPhoneExpression.IsMatch(value)
    End Function
End Class

