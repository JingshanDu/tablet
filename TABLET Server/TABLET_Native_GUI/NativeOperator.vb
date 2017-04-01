'HGAO Remote Controlling Component -- TABLET Server
'TABLET Background Handler & Native Operator
'Part of the Terminal Automation Batch Language Environment for Telescopes
'Referred to the free component Acquire.vbs (C) Diffraction Limited
'(C)2012 DU Jingshan, Hanggao Astronomical Observatory 
Imports System.IO
Imports TABLET_Core
Imports System.Windows.Forms
Imports System.Security.Cryptography
Imports System.Text
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Serialization.Formatters
Public Class NativeOperator
    Friend weather As New ClarityII.CloudSensorII
    Dim TS As New TabletServer
    Dim tsv As New TSV.main
    ReadOnly Lv() As String = tsv.Local

#Region "Native Window"
    Private Sub NativeOperator_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Remoting
        Dim serverProvider As New BinaryServerFormatterSinkProvider
        Dim clientProvider As New BinaryClientFormatterSinkProvider
        serverProvider.TypeFilterLevel = TypeFilterLevel.Full
        Dim props As IDictionary = New Hashtable
        props("port") = 19951
  
        Dim channel As New HttpChannel(props, clientProvider, serverProvider)
        ChannelServices.RegisterChannel(channel)
        Dim objref As ObjRef = RemotingServices.Marshal(TS, "ServiceMessage")
        TS.Init(Lv)

        lblRainDrop.Visible = False
        TS.Command("init scm", Lv)
    End Sub
    Private Sub btnScriptDo_Click(sender As System.Object, e As System.EventArgs) Handles btnScriptDo.Click
        TS.Script(txtScriptInput.Text, Lv)
    End Sub
    Private Sub btnScriptClear_Click(sender As System.Object, e As System.EventArgs) Handles btnScriptClear.Click
        txtScriptInput.Text = Nothing
    End Sub
    Private Sub btnCommandDo_Click(sender As System.Object, e As System.EventArgs) Handles btnCommandDo.Click
        txtCommandHistory.Text &= ">" & txtCommandInput.Text & vbNewLine
        If Not txtCommandHistory.Text = Nothing Then
            Dim r As String = TS.Command(txtCommandInput.Text, Lv)
            txtCommandInput.Text = Nothing
        End If
    End Sub
    Private Sub txtCommandInput_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCommandInput.KeyPress
        If e.KeyChar = ChrW(13) Then
            btnCommandDo.PerformClick()
        End If
    End Sub
    Private Sub btnCmdHisClear_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnCmdHisClear.LinkClicked
        txtCommandHistory.Text = Nothing
    End Sub
    Private Sub btnSetNamePath_Click(sender As System.Object, e As System.EventArgs) Handles btnSetNamePath.Click
        TS.Init(Lv)
    End Sub
    Private Sub NativeOperator_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim r As String = InputBox("Input the CONFIRMATION CODE to close the Server", "TABLET Server")
        If MD5(r, 16).ToUpper = "A4917C4B47281D36" Then 'hgtwlong
            TS.Command("home scm", Lv)
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub
    Private Sub NotifyIco_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub
    Private Sub TrayMenuShow_Click(sender As System.Object, e As System.EventArgs) Handles TrayMenuShow.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub
    Private Sub TrayMenuExit_Click(sender As System.Object, e As System.EventArgs) Handles TrayMenuExit.Click
        Me.Close()
    End Sub
#End Region

#Region "Others"
    Private Function MD5(ByVal StrSource As String, ByVal Code As Int16) As String
        '这里用的是ascii编码密码原文，如果要用汉字做密码，可以用UnicodeEncoding，但会与ASP中的MD5函数不兼容
        Dim DataToHash As Byte() = (New System.Text.ASCIIEncoding).GetBytes(StrSource)
        Dim Hashvalue As Byte() = CType(System.Security.Cryptography.CryptoConfig.CreateFromName("MD5"), System.Security.Cryptography.HashAlgorithm).ComputeHash(DataToHash)
        Dim i As Integer
        Dim Str_MD5 As String = ""
        Select Case Code
            Case 16  '选择16位字符的加密结果
                For i = 4 To 11
                    Str_MD5 += Hex(Hashvalue(i)).ToLower
                Next

            Case Else   'Code错误时或者选择32位字符加密时，返回全部字符串，即32位字符
                For i = 0 To Hashvalue.Length - 1
                    Str_MD5 += Hex(Hashvalue(i)).ToLower
                Next
        End Select
        MD5 = Str_MD5
    End Function
    Private Sub btnAbout_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnAbout.LinkClicked
        AboutBox1.Show()
    End Sub
#End Region

    Private Sub timerCheckRain_Tick(sender As System.Object, e As System.EventArgs) Handles timerCheckRain.Tick
        Try
            TS.ShowEcho = False
            Dim r As String = TS.Command("info dome", Lv)
            TS.ShowEcho = False
            If weather.RainF And r.ToLower = "open" Then
                lblRainDrop.Visible = True
                TS.RaiseWarning("RAIN DROP. Dome closing started.")
                TS.Command("close dome", Lv)
                MsgBox("Rain drop detected! Dome closed forcibly!", MsgBoxStyle.Exclamation, "TABLET Server")
            Else
                lblRainDrop.Visible = False
            End If
            lblRainDetectErr.Visible = False
        Catch ex As Exception
            lblRainDetectErr.Visible = True
        End Try
        

    End Sub
End Class

'Remoting
Public Delegate Sub WarningHandler(ByVal content As String)
Public Class TabletServer
    Inherits MarshalByRefObject
    Private WithEvents cCore As New Core
    Private objTSV As New TSV.main
    Private Const VeriFail As String = "Verification Fail"
    Private TaskCache As New Queue
    Friend ShowEcho As Boolean = True
    Public Event Warning As WarningHandler

    Public Function Command(ByVal cmd As String, ByVal veri() As String) As String
        Dim tasksign As Object = {cmd, TimeOfDay}
        If objTSV.Login(veri(0), veri(1)) Then
            If cmd.ToLower = "stop dome" Then Return hCommand(cmd)
            TaskCache.Enqueue(tasksign)
            While TaskCache.Peek IsNot tasksign
                Threading.Thread.Sleep(500)
            End While
            Dim r As String = hCommand(cmd)
            If cmd.ToLower IsNot "stop dome" Then TaskCache.Dequeue()
            Return r
        Else
            Return VeriFail
        End If
    End Function
    Public Function Script(ByVal scr As String, ByVal veri() As String) As String
        Dim tasksign As Object = {scr, TimeOfDay}
        If objTSV.Login(veri(0), veri(1)) Then
            TaskCache.Enqueue(tasksign)
            While TaskCache.Peek IsNot tasksign
                Threading.Thread.Sleep(500)
            End While
            Dim r As String = hScript(scr)
            TaskCache.Dequeue()
            Return r
        Else
            Return VeriFail
        End If
    End Function
    Public Function Init(ByVal veri() As String) As Boolean
        If objTSV.Login(veri(0), veri(1)) Then
            Dim np As String = "D:\Data\" & veri(0) & "_" & GiveMissionSn()
            hInit(np)
            Return True
        End If
        Return False
    End Function
    <Messaging.OneWay()>
    Friend Sub RaiseWarning(ByVal content As String) Handles cCore.Warning
        NativeOperator.txtCommandHistory.Text &= content & vbNewLine
        NativeOperator.txtCommandHistory.SelectionStart = NativeOperator.txtCommandHistory.Text.Length
        NativeOperator.txtCommandHistory.ScrollToCaret()
        RaiseEvent Warning(content)
    End Sub
    Public Overrides Function InitializeLifetimeService() As Object
        Return Nothing
    End Function
#Region "Handler"
    Private NamePath As String
    Private Function hInit(newNamePath As String) As Boolean
        NativeOperator.lblTABLETV.Text = cCore.TABLETVersion
        NativeOperator.lblTABLETC.Text = Strings.Left(cCore.propAssemblyVersion, 3)
        If Not newNamePath = Nothing Then
            NativeOperator.txtNamePath.Text = newNamePath
        End If
        If Not NativeOperator.txtNamePath.Text.EndsWith("\") Then NativeOperator.txtNamePath.Text &= "\"
        NamePath = NativeOperator.txtNamePath.Text
        cCore.propNamePath = NamePath
        If Not Directory.Exists(NamePath) Then Directory.CreateDirectory(NamePath)
        Return True
    End Function
    Private Function hCommand(ByVal com As String) As String
        Dim r As String = cCore.Run(Core.Mode.Command, com)
        If r <> Nothing And ShowEcho Then
            NativeOperator.txtCommandHistory.Text &= r & vbNewLine
            NativeOperator.txtCommandHistory.SelectionStart = NativeOperator.txtCommandHistory.Text.Length
            NativeOperator.txtCommandHistory.ScrollToCaret()
        End If
        Return r
    End Function
    Public Function hScript(ByVal scr As String) As String
        File.WriteAllText(NamePath & cCore.lPath, NativeOperator.txtScriptInput.Text)
        Dim r As String = cCore.Run(Core.Mode.Script)
    End Function
#End Region
    Private Function GiveMissionSn() As String
        Dim yr As String = Year(Now)
        Dim fd As Date = yr & "/1/1 00:00:00"
        Dim wk As String = DateDiff(DateInterval.Day, fd, Now).ToString
        Return yr & wk
    End Function
End Class
Public Class EventWrapper
    Inherits MarshalByRefObject
    Public Event LocalWarning As WarningHandler
    Public Sub LocalRaiseWarning(ByVal content As String)
        RaiseEvent LocalWarning(content)
    End Sub
End Class