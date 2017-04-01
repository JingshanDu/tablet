Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Serialization.Formatters
Imports TabletServer
<Serializable()> Public Class TCC
    Public Class LocalEcho
        Public Const ConnectionError As String = "Connection Error"
    End Class
    Private v(2) As String
    Private ServerObj As TabletServer.TabletServer
    Public Event Warning(ByVal content As String)
    Public Function Connect(Address As String, veri() As String) As Boolean
        Try
            Dim serverProvider As New BinaryServerFormatterSinkProvider
            Dim clientProvider As New BinaryClientFormatterSinkProvider
            serverProvider.TypeFilterLevel = TypeFilterLevel.Full
            Dim props As IDictionary = New Hashtable
            props("port") = 0

            Dim channel As HttpChannel = New HttpChannel(props, clientProvider, serverProvider)
            ChannelServices.RegisterChannel(channel)
            ServerObj = Activator.GetObject(GetType(TabletServer.TabletServer), Address)
            Dim wrapper As New EventWrapper

            AddHandler ServerObj.Warning, New WarningHandler(AddressOf wrapper.LocalRaiseWarning)
            AddHandler wrapper.LocalWarning, New WarningHandler(AddressOf WarningH)

            If IsNothing(ServerObj) Then Return False
            v = veri

            Return ServerObj.Init(v)
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Command(ByVal cmd As String) As String
        Try
            Return ServerObj.Command(cmd, v)
        Catch ex As Exception
            Return LocalEcho.ConnectionError
        End Try
    End Function
    Public Function Script(ByVal scr As String) As String
        Try
            Return ServerObj.Script(scr, v)
        Catch ex As Exception
            Return LocalEcho.ConnectionError
        End Try
    End Function
    Private Sub WarningH(ByVal content)
        RaiseEvent Warning(content)
    End Sub
End Class