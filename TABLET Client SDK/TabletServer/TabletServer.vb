'Psydo-object
Public Delegate Sub WarningHandler(ByVal content As String)
Public Class TabletServer
    Inherits MarshalByRefObject
    Public Event Warning As WarningHandler
    Public Function Command(ByVal cmd As String, ByVal veri() As String) As String
    End Function
    Public Function Script(ByVal scr As String, ByVal veri() As String) As String
    End Function
    Public Function Init(ByVal veri() As String) As Boolean
    End Function
    Public Overrides Function InitializeLifetimeService() As Object
        Return Nothing
    End Function
End Class
Public Class EventWrapper
    Inherits MarshalByRefObject
    Public Event LocalWarning As WarningHandler
    Public Sub LocalRaiseWarning(ByVal content As String)
        RaiseEvent LocalWarning(content)
    End Sub
End Class


'Public Delegate Sub WarningHandler(ByVal content As String)
'Public Class TabletServer
'    Inherits MarshalByRefObject

'    Private Const VeriFail As String = "Verification Fail"
'    Public Event Warning As WarningHandler
'    Public Function Command(ByVal cmd As String, ByVal veri() As String) As String

'    End Function
'    Public Function Script(ByVal scr As String, ByVal veri() As String) As String

'    End Function
'    Public Function Init(ByVal veri() As String) As Boolean

'    End Function
'    Friend Sub RaiseWarning(ByVal content As String)

'    End Sub
'    Public Overrides Function InitializeLifetimeService() As Object
'        Return Nothing
'    End Function
'#Region "Handler"
'    Private NamePath As String
'    Private Function hInit(newNamePath As String) As Boolean

'    End Function
'    Private Function hCommand(ByVal com As String) As String

'    End Function
'    Public Function hScript(ByVal scr As String) As String

'    End Function
'#End Region
'End Class
'Public Class EventWrapper
'    Inherits MarshalByRefObject
'    Public Event LocalWarning As WarningHandler
'    Public Sub LocalRaiseWarning(ByVal content As String)
'        RaiseEvent LocalWarning(content)
'    End Sub
'End Class