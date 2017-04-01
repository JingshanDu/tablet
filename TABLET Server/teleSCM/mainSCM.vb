Public Class mainSCM
    Private COMnum1 As New IO.Ports.SerialPort("COM0")
    Private COMnum2 As New IO.Ports.SerialPort("COM0")

    Public R_INTI As String = "ready"
    Public R_COOLERINTI As String = "command"
    Public R_COOLERTURN As String = "turn"
    Public R_COOLERUP As String = "up"
    Public R_COOLERDOWN As String = "down"
    Public R_DONE As String = "done"
    Public R_REACH As String = "reached"
    Public R_OPEN As String = "open"
    Public R_CLOSED As String = "closed"
    Public R_STOP As String = "stoped"
    Public R_ERROR_TIMEOUT As String = "error#1"
    Public R_ERROR_BADCOMMAND As String = "error#2"
    Public R_ERROR_UNAVAILABLE As String = "error#3"

    Public T_DOME As Integer = 40
    Public T_COVERM As Integer = 10
    Public T_COVERS As Integer = 2
    Public Delegate Sub ReachedHandler(ByVal API_name As String, ByVal IfSuccess As Boolean)
    Public Event Reached As ReachedHandler
    'Locks preventing invoking when there's already a processing in the SCM.
    Private Lock1 As Boolean
    Private Lock2 As Boolean
    'For WaitForReach sub
    Private Property API_name As String
    Private Property SCMnum As Integer
    Private Property time As Integer
    Private Property WaitingThread As Threading.Thread
    Public Function Inti(ByVal COMa As Integer, COMb As Integer) As Boolean
        On Error Resume Next
        COMnum1.Close()
        COMnum2.Close()
        COMnum1.PortName = "COM" & COMa
        COMnum2.PortName = "COM" & COMb
        COMnum1.ReadTimeout = 500
        COMnum2.ReadTimeout = 500
        COMnum1.Open()
        COMnum2.Open()
        Threading.Thread.Sleep(1500)
        COMnum1.ReadExisting()
        COMnum2.ReadExisting()
        Lock1 = False
        Lock2 = False
        Return True
    End Function
    Public Function Quit() As Boolean
        Try
            COMnum1.Close()
            COMnum2.Close()
            COMnum1.Dispose()
            COMnum2.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#Region "SCM1"
    Public Function DomeOpen() As Boolean
        If Lock1 Then
            Return False
        Else
            Lock1 = True
            Dim r As Boolean = Send("b", 1)
            If r = True Then
                Dim thr As New Threading.Thread(AddressOf WaitForReach)
                API_name = "DomeOpen"
                SCMnum = 1
                time = T_DOME
                thr.Start()
                Return True
            Else
                Lock1 = False
                Return False
            End If
        End If
    End Function
    Public Function DomeClose() As Boolean
        If Lock1 Then
            Return False
        Else
            Lock1 = True
            Dim r As Boolean = Send("c", 1)
            If r = True Then
                Dim thr As New Threading.Thread(AddressOf WaitForReach)
                API_name = "DomeClose"
                SCMnum = 1
                time = T_DOME
                thr.Start()
                Return True
            Else
                Lock1 = False
                Return False
            End If
        End If
    End Function
    Public Function DomeStop() As Boolean
        Try
            Dim thr As Threading.Thread = WaitingThread
            thr.Abort()
            thr.Join()
        Catch ex As Exception
        End Try
        Dim r As String = ISend("s", 1)
        Lock1 = False
        If r = R_STOP Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function DomeStatus() As Integer
        If Lock1 Then
            Return -1
        Else
            Dim r = GetChar(All1Status, 5)
            If r = "O" Then
                Return 1
            ElseIf r = "C" Then
                Return 0
            Else
                Return -1
            End If
        End If
    End Function
    Public Function LEDOpen() As Boolean
        If Lock1 Then
            Return False
        Else
            Dim r As Boolean = Send("d", 1)
            Return r
        End If
    End Function
    Public Function LEDClose() As Boolean
        If Lock1 Then
            Return False
        Else
            Dim r As Boolean = Send("e", 1)
            Return r
        End If
    End Function
    Public Function LEDStatus() As Integer
        If Lock1 Then
            Return -1
        Else
            Dim r = GetChar(All1Status, 3)
            If r = "O" Then
                Return 1
            ElseIf r = "C" Then
                Return 0
            Else
                Return -1
            End If
        End If
    End Function
    Public Function Power1Con() As Boolean
        If Lock1 Then
            Return False
        Else
            Dim r As Boolean = Send("g", 1)
            Return r
        End If
    End Function
    Public Function Power1Discon() As Boolean
        If Lock1 Then
            Return False
        Else
            Dim r As Boolean = Send("f", 1)
            Return r
        End If
    End Function
    Public Function Power1Status() As Integer
        If Lock1 Then
            Return -1
        Else
            Dim r = GetChar(All1Status, 1)
            If r = "O" Then
                Return 1
            ElseIf r = "C" Then
                Return 0
            Else
                Return -1
            End If
        End If
    End Function
    Public Function CoolerPwr() As Boolean
        If Lock1 Then
            Return False
        Else
            Dim r As Boolean = CoolerSend("k")
            Return r
        End If
    End Function
    Public Function CoolerUp() As Boolean
        If Lock1 Then
            Return False
        Else
            Dim r As Boolean = CoolerSend("s")
            Return r
        End If
    End Function
    Public Function CoolerDown() As Boolean
        If Lock1 Then
            Return False
        Else
            Dim r As Boolean = CoolerSend("x")
            Return r
        End If
    End Function
    Public Function All1Status() As String
        If Lock1 Then
            Return "###"
        Else
            Dim st As String = GetS("i", 1)
            Return st
        End If
    End Function
    Public Function TempGet() As Single()    '0=temp,1=hum
        If Lock1 Then
            Return {CSng(-99), CSng(-99)}
        Else
            Dim a As Boolean = ISend("a", 1)
            Dim re As String = IReceive(1)
            Dim data(2) As Single
            If a = True And re = R_INTI Then
                ISend("t", 1)
                Threading.Thread.Sleep(1000)
                Dim r1, r2 As String
                Do While r1 = Nothing Or r2 = Nothing
                    r1 = IReceive(1)
                    r2 = IReceive(1)
                Loop
                Try
                    r1 = Replace(r1, "c", "")
                    data(0) = CSng(r1)
                Catch ex As Exception
                    data(0) = -99
                End Try
                Try
                    r2 = Replace(r2, "%", "")
                    data(1) = CSng(r2)
                Catch ex As Exception
                    data(1) = -99
                End Try
                Return data
            Else
                data(0) = -99
                data(1) = -99
                Return data
            End If
        End If
    End Function
#End Region

#Region "SCM2"
    Public Function CoverMOpen() As Boolean
        If Lock2 Then
            Return False
        Else
            Lock2 = True
            Dim r As Boolean = Send("b", 2)
            If r = True Then
                Dim thr As New Threading.Thread(AddressOf WaitForReach)
                API_name = "CoverMOpen"
                SCMnum = 2
                time = T_COVERM
                thr.Start()
                Return True
            Else
                Lock2 = False
                Return False
            End If
        End If
    End Function
    Public Function CoverMClose() As Boolean
        If Lock2 Then
            Return False
        Else
            Lock2 = True
            Dim r As Boolean = Send("c", 2)
            If r = True Then
                Dim thr As New Threading.Thread(AddressOf WaitForReach)
                API_name = "CoverMClose"
                SCMnum = 2
                time = T_COVERM
                thr.Start()
                Return True
            Else
                Lock2 = False
                Return False
            End If
        End If
    End Function
    Public Function CoverMStatus() As Integer
        If Lock2 Then
            Return -1
        Else
            Dim r = GetChar(All2Status, 3)
            If r = "O" Then
                Return 1
            ElseIf r = "C" Then
                Return 0
            Else
                Return -1
            End If
        End If
    End Function
    Public Function CoverSOpen() As Boolean
        If Lock2 Then
            Return False
        Else
            Lock2 = True
            Dim r As Boolean = Send("d", 2)
            If r = True Then
                Dim thr As New Threading.Thread(AddressOf WaitForReach)
                API_name = "CoverSOpen"
                SCMnum = 2
                time = T_COVERS
                thr.Start()
                Return True
            Else
                Lock2 = False
                Return False
            End If
        End If
    End Function
    Public Function CoverSClose() As Boolean
        If Lock2 Then
            Return False
        Else
            Lock2 = True
            Dim r As Boolean = Send("e", 2)
            If r = True Then
                Dim thr As New Threading.Thread(AddressOf WaitForReach)
                API_name = "CoverSClose"
                SCMnum = 2
                time = T_COVERS
                thr.Start()
                Return True
            Else
                Lock2 = False
                Return False
            End If
        End If
    End Function
    Public Function CoverSStatus() As Integer
        If Lock2 Then
            Return -1
        Else
            Dim r = GetChar(All2Status, 1)
            If r = "O" Then
                Return 1
            ElseIf r = "C" Then
                Return 0
            Else
                Return -1
            End If
        End If
    End Function
    Public Function All2Status() As String
        If Lock2 Then
            Return "###"
        Else
            Dim st As String = GetS("f", 2)
            Return st
        End If
    End Function
#End Region

#Region "Functions"
    Private Sub WaitForReach()
        WaitingThread = Threading.Thread.CurrentThread
        Dim r As String = Nothing
        Dim n As Integer = time / 2
        Dim i As Integer
        Do
            Threading.Thread.Sleep(2000)
            r = IReceive(SCMnum)
            i += 1
        Loop Until r = R_REACH Or r = R_ERROR_TIMEOUT Or i >= n
        If SCMnum = 1 Then Lock1 = False
        If SCMnum = 2 Then Lock2 = False
        If r = R_REACH Then
            RaiseEvent Reached(API_name, True)
        ElseIf r = R_ERROR_TIMEOUT Then
            IReceive(SCMnum)
            RaiseEvent Reached(API_name, False)
        ElseIf r = Nothing Then
            RaiseEvent Reached(API_name, False)
        End If
    End Sub
    Private Function Send(ByVal text As String, ByVal SCMnum As Integer) As Boolean
        Dim a As Boolean = ISend("a", SCMnum)
        Dim re As String = IReceive(SCMnum)
        Dim r As Boolean = False
        Dim x As Boolean
        If a = True And re = R_INTI Then
            x = True
        Else
            x = False
        End If
        If x = True Then
            ISend(text, SCMnum)
            re = IReceive(SCMnum)
            If re = R_DONE Or re = R_STOP Or re = R_COOLERINTI Then
                r = True
            End If
        End If
        Return r
    End Function
    Private Function GetS(ByVal text As String, ByVal SCMnum As Integer) As String
        Dim a As Boolean = ISend("a", SCMnum)
        Dim r As String = IReceive(SCMnum)
        If a = True And r = R_INTI Then
            ISend(text, SCMnum)
            r = IReceive(SCMnum)
            'format and return
            Dim len As Integer = r.Length
            If r.Length = 1 Then
                r = "00" & r
            ElseIf r.Length = 2 Then
                r = "0" & r
            End If
            r = r.Replace("0", "C.")
            r = r.Replace("1", "O.")
            Return r
        Else
            Return "###"
        End If
    End Function
    Private Function CoolerSend(ByVal text As String) As Boolean
        Dim inti As Boolean = Send("h", 1)
        Dim r As Boolean
        Dim rr As String
        If inti = True Then
            r = ISend(text, 1)
            If r = True Then
                rr = IReceive(1)
                If rr = R_COOLERTURN Or rr = R_COOLERUP Or rr = R_COOLERDOWN Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    'core transfer
    Public Function ISend(ByVal text As String, SCMnum As Integer) As Boolean
        Dim COMnum As IO.Ports.SerialPort
        If SCMnum = 1 Then
            COMnum = COMnum1
        ElseIf SCMnum = 2 Then
            COMnum = COMnum2
        Else
            Return False
        End If

        If COMnum.IsOpen = False Then
            COMnum.Open()
        End If
        COMnum.Write(text)
        Return True
    End Function
    Public Function IReceive(ByVal SCMnum As Integer) As String
        Dim COMnum As IO.Ports.SerialPort
        If SCMnum = 1 Then
            COMnum = COMnum1
        ElseIf SCMnum = 2 Then
            COMnum = COMnum2
        Else
            Return ""
        End If
        Dim returnStr As String = ""
        Try
            If COMnum.IsOpen = False Then
                COMnum.Open()
            End If
            returnStr = COMnum.ReadLine()
        Catch ex As Exception
        End Try
        If Not returnStr = "" Then
            Dim CrI As Integer = InStr(returnStr, vbCr)
            returnStr = Left(returnStr, CrI - 1)
        End If
        Return returnStr
    End Function
#End Region

End Class
