Imports TCConnection
Imports TCVerification

Module ClientCmd
    Public WithEvents tcc As New TCC
    Public tcv As New TCV
    Public settings As New ClientSetting
    Sub Main()
        Console.WriteLine("TABLET Client SDK Sample Client Command-line")
        Console.WriteLine("Version " & SampleClient.My.Application.Info.Version.ToString)
sVeri:
        Console.WriteLine("TC: Verification")
        Console.WriteLine("Choose verification mode: (O)nline; (M)anual.")
        Dim veri(2) As String
        Select Case Char.ToLower(Console.ReadKey().KeyChar)
            Case "o"
                Console.WriteLine()
                Dim user, pass As String
                Console.WriteLine("Input User Name:")
                user = Console.ReadLine()
                Console.WriteLine("Input Password:")
                pass = Console.ReadLine
                veri = tcv.GetVeriInfo(user, pass)
            Case ("m")
                Console.WriteLine()
                Console.WriteLine("Input User Name:")
                veri(0) = Console.ReadLine
                Console.WriteLine("Input Key:")
                veri(1) = Console.ReadLine
            Case Else
                GoTo sVeri
        End Select

sCon:
        Console.WriteLine("TC: Connection")
        Console.WriteLine("Connecting to " & settings.ServerURL)
        If tcc.Connect(settings.ServerURL, veri) = False Then
            Console.WriteLine( _
                "Connection fail. Please check the settings.If you have chosen to do manual verification, you may check your key input.")
            Console.WriteLine("Press any key to exit.")
            Console.ReadKey(True)
            System.Environment.Exit(0)
        End If

        Console.WriteLine(vbNewLine & _
                          "Now you are in TABLET Command Mode. Type 'exit' to quit the program, 'login' to do the verification again, 'connect' to re-connect to the server.")
        Console.Write(tcc.Command("info ver") & vbNewLine)

sLoop:
        While (True)
            Console.Write("TABLET>")
            Dim line As String = Console.ReadLine()
            If line = "exit" Then System.Environment.Exit(0)
            If line = "login" Then GoTo sVeri
            If line = "connect" Then GoTo sCon
            Console.Write(tcc.Command(line) & vbNewLine)
        End While
    End Sub
    Sub OnWarning(ByVal content As String) Handles tcc.Warning
        Console.WriteLine("~MESSAGE~")
        Console.Write(content & vbNewLine)
    End Sub
End Module
