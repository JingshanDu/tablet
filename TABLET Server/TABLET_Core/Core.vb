'HGAO Remote Controlling Component -- TABLET Server
'TABLET Core Library
'Part of the Terminal Automation Batch Language Environment for Telescopes
'Referred to the free component Acquire.vbs (C) Diffraction Limited
'(C)2012 DU Jingshan, Hanggao Astronomical Observatory
Imports TheSky6Library
Imports MaxIm
Imports CCDSoftLib
Imports ClarityII
Imports teleSCM
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Public Class Core
    Public ReadOnly Property TABLETVersion As String
        Get
            Return "1.1"
        End Get
    End Property
#Region "GlobalSettings"
    Private T As New TheSkyRASCOMTele 'TheSky Objects (For Telescope)
    Private TS As New TheSkyRASCOMTheSky
    Private U As New Utils
    Private WithEvents C_sub As New CCDCamera 'MaxIm Objects (For Sub Camera)
    Private MaxImApp As New Application
    Private MaxImDoc As Document
    Private WithEvents C_main As New CCDSoftCamera 'CCDSoft Objects (For Main Camera)
    Private CCDSoftDoc As New CCDSoftLib.Image
    Private WithEvents SCM As New mainSCM 'teleSCM Objects (For Accessories)
    Private W As Object 'CloudSensorII Objects [optional]

    Private station As String
    Private Ca, Cb As Integer
    Public lPath As String = "AutoList.txt" 'list file path
    Public cfgPath As String = "Server.HGAO-CFG"
    Public SubSeqPath As String = "SUBSEQ"
    Event Warning(ByVal content As String)
    Private NamePath As String
    Private AssemblyVersion As String = Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString

    Dim RunMode As Mode
    Dim RA As Double
    Dim DEC As Double
    Dim SPRE As String = ""
    Dim MPRE As String = ""
    Dim MTYP As String = "light"
    Dim STYP As String = "light"
    Dim SSEQ As Integer = 1
    Dim Obj As String
    Dim HasRA As Boolean = False
    Dim HasDEC As Boolean = False
    Dim EnableSCM As Boolean = True
    Dim EnableW As Boolean = True
    Dim EnableXDB As Boolean = False
    Dim W_used As Boolean = False
    Dim T_inited As Boolean = False
    Dim EpochSet As EpochMode = EpochMode.Jnow
    Dim LineNum As Integer
    Dim GlobalError As Boolean 'if there is an serious error in another threading, terminate the program and return.
    Dim PvMainPath As String 'Preview Images' Path
    Dim PvSubPath As String

    Public Property propNamePath As String
        Set(value As String)
            If Not value.EndsWith("\") Then value = value & "\"
            NamePath = value
        End Set
        Get
            Return NamePath
        End Get
    End Property
    Public ReadOnly Property propAssemblyVersion() As String
        Get
            Return AssemblyVersion
        End Get
    End Property
    Public Property LogPath As String
    Public Property WritingLog As Boolean
    Public Enum Mode As Integer
        Script = 1
        Command = 2
    End Enum
    Public Enum EpochMode As Integer
        J2000 = 0
        Jnow = 1
    End Enum
#End Region
    Private Sub McamEvent(EventId, lWhichCCD, lpszValue, lParam1, lParam2) Handles C_main.CameraEvent
        Select Case EventId
            Case cdCameraEvent.cdAfterTakeImage
                WriteLog("MEXP_" & C_main.ExposureTime.ToString & "s")
        End Select
    End Sub
    Private Sub ScamEvent(EventId) Handles C_sub.Notify

    End Sub
    Public Function Run(ByVal Mode As Mode, Optional ByVal CmdLine As String = "") As Object
        On Error Resume Next
        RunMode = Mode
        '&&&&& initialize from config file &&&&&
        Dim hdlConfig As Long
        Dim strLine As String
        Dim I As Integer
        hdlConfig = FreeFile()
        FileOpen(hdlConfig, cfgPath, OpenMode.Input, OpenAccess.Read)
        Do While Not EOF(hdlConfig)
            strLine = LineInput(hdlConfig)
            If Not strLine = Nothing Then
                'separate name and value
                I = InStr(strLine, "$")
                If I > 0 Then
                    Dim aI As Integer = strLine.Length
                    Dim item As String = Strings.Left(strLine, I - 1)
                    Dim value As String = Strings.Right(strLine, aI - I)
                    Select Case item
                        Case "STATION"
                            station = value
                        Case "COMa"
                            If IsNumeric(value) Then Ca = value
                        Case "COMb"
                            If IsNumeric(value) Then Cb = value
                        Case "MAINPREV"
                            PvMainPath = value
                        Case "SUBPREV"
                            PvSubPath = value
                    End Select
                End If
            End If
        Loop
        FileClose(hdlConfig)

        If File.Exists(SubSeqPath) Then
            Dim sseqr As String = File.ReadAllText(SubSeqPath)
            If IsNumeric(sseqr) Then SSEQ = CInt(sseqr)
        Else
            File.WriteAllText(SubSeqPath, "1")
            SSEQ = 1
        End If

        Dim nowyear As Integer = Year(Date.Now)
        Dim nowmonth As Integer = Month(Date.Now)
        Dim nowdate As Integer = Day(Date.Now)
        Dim logName As String = NamePath + "logs\" & nowyear & "-" & nowmonth & "-" & nowdate & ".log"
        LogPath = logName
        If Directory.Exists(NamePath + "logs\") = False Then
            Directory.CreateDirectory(NamePath + "logs\")
        End If
        If File.Exists(logName) = False Then
            File.CreateText(logName).Close()
        End If

        If File.Exists(NamePath & lPath) = False And RunMode = Mode.Script Then
            RaiseEvent Warning("CANNOT_FIND_LIST")
        Else
            Dim r = Executor(CmdLine)
            Save()
            Return r
        End If
    End Function
    Private Sub ErrorHappen(ByVal err As String, errLineNum As Integer)
        Dim log As String = "Line=" & errLineNum.ToString & ", " & err
        WriteLog(log)
    End Sub
    Public Function Executor(ByVal CmdLine As String) As Object
        Dim longHandle As Long
        GlobalError = False
        'Control Variables
        Dim LoopStartTable As New Stack
        Dim LoopTimeTable As New Stack

        'Read the AutoList
        Dim line As String
        LineNum = 0
        Try
            If RunMode = Mode.Command Then
                line = CmdLine
                GoTo Entry
            End If
            longHandle = FreeFile()
            FileOpen(longHandle, NamePath & lPath, OpenMode.Input)
            Do While Not EOF(longHandle)
                If GlobalError Then Exit Function
                LineNum += 1
                line = LineInput(longHandle)
Entry:
                line = line.Trim.Trim(vbTab)
                'Analyse
                Dim I As Integer
                I = InStr(line, "#") 'anything after # is a comment
                If I > 0 Then line = Left(line, I - 1)
                If line = "" Then GoTo BlankLine
                ' the first word on the line is the command
                I = InStr(line, " ")
                If I = 0 Then
                    I = InStr(line, vbTab)
                End If
                Dim Command As String
                If I = 0 Then
                    Command = UCase(line)
                    line = ""
                Else
                    Command = UCase(Left(line, I - 1))
                    line = Right(line, Len(line) - I).Trim.Trim(vbTab)
                End If
                If line = "" Then
                    Throw New Exception("NO_PARAMETER")
                Else
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Analyse
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Left(Command, 4) = "INIT" Then
                        Dim para As String = LCase(line)
                        If EnableSCM Then
                            SCM.Inti(Ca, Cb)
                            If SCM.Power1Status = 0 Then SCM.Power1Con()
                            If RunMode = Mode.Script Then Threading.Thread.Sleep(5000) 'To ensure all the instruments are powered off.
                        End If
                        If EnableW And Not W_used Then
                            W = New CloudSensorII
                            W_used = True
                        End If
                        If para = "mount" Or para = "all" Then
                            T.Connect()
                            T.Asynchronous = 0
                            T.FindHome()
                            WriteLog("INIT_MOUNT")
                            T_inited = True
                        End If
                        If para = "mcam" Or para = "cam" Or para = "all" Then
                            C_main.Connect()
                            C_main.Asynchronous = 0
                            C_main.ImageReduction = CdImageReduction.cdNone
                            C_main.AutoSaveOn = 1
                            C_main.AutoSaveFileFormat = CdAutoSaveAs.cdFITS
                            'CCDSoftDoc.AttachToActiveImager()
                            C_main.focConnect()
                            If EnableSCM Then
                                If SCM.CoverMStatus = 0 Then
                                    SCM.CoverMOpen()
                                    If RunMode = Mode.Script Then Threading.Thread.Sleep(SCM.T_COVERM * 1000)
                                End If
                            End If
                            WriteLog("INIT_MAINCAM")
                        End If
                        If para = "scam" Or para = "cam" Or para = "all" Then
                            C_sub.LinkEnabled = True
                            MaxImApp.FocuserConnected = True
                            If EnableSCM Then
                                If SCM.CoverSStatus = 0 Then
                                    SCM.CoverSOpen()
                                    If RunMode = Mode.Script Then Threading.Thread.Sleep(SCM.T_COVERS * 1000)
                                End If
                            End If
                            WriteLog("INIT_SUBCAM")
                        End If
                    ElseIf Left(Command, 4) = "HOME" Then
                        Dim para As String = LCase(line)
                        If para = "mount" Or para = "all" Then
                            T.Park()
                            T.Disconnect()
                            WriteLog("HOME_MOUNT")
                            T_inited = False
                        End If
                        If para = "mcam" Or para = "cam" Or para = "all" Then
                            C_main.Disconnect()
                            CCDSoftDoc.SetActive()
                            C_main.focDisconnect()
                            If EnableSCM Then If SCM.CoverMStatus = 1 Then SCM.CoverMClose()
                            WriteLog("HOME_MAINCAM")
                        End If
                        If para = "scam" Or para = "cam" Or para = "all" Then
                            C_sub.LinkEnabled = False
                            MaxImApp.FocuserConnected = False
                            If EnableSCM Then If SCM.CoverSStatus = 1 Then SCM.CoverSClose()
                            WriteLog("HOME_SUBCAM")
                        End If
                        If EnableSCM Then SCM.Quit()
                    ElseIf Left(Command, 4) = "EPOC" Then
                        Select Case line.ToLower
                            Case "jnow"
                                EpochSet = EpochMode.Jnow
                            Case "j2000"
                                EpochSet = EpochMode.J2000
                            Case Else
                                Throw New Exception("EPOC_INVALID")
                        End Select
                    ElseIf Left(Command, 4) = "SSEQ" Then
                        'If CInt(line) <= 0 Then
                        ' Throw New Exception("SSEQ_OUT_OF_RANGE")
                        'Else
                        ' SSEQ = CInt(line)
                        'End If
                        If RunMode = Mode.Command Then
                            Throw New Exception("SSEQ_OUTDATED")
                        Else
                            RaiseEvent Warning("SSEQ is outdated and no longer supported.")
                        End If
                    ElseIf Left(Command, 4) = "SPRE" Then
                        If line.Contains("/") Or line.Contains("\") Or line.Contains(":") Or line.Contains("*") Or line.Contains("?") Or line.Contains(Chr(34)) Or line.Contains("<") Or line.Contains(">") Or line.Contains("|") Then
                            Throw New Exception("SPRE_INVALID")
                        Else
                            SPRE = line
                        End If
                    ElseIf Left(Command, 4) = "MPRE" Then
                        If line.Contains("/") Or line.Contains("\") Or line.Contains(":") Or line.Contains("*") Or line.Contains("?") Or line.Contains(Chr(34)) Or line.Contains("<") Or line.Contains(">") Or line.Contains("|") Then
                            Throw New Exception("MPRE_INVALID")
                        Else
                            MPRE = line
                        End If
                    ElseIf Left(Command, 2) = "RA" Then
                        If line.Contains("h ") And line.Contains("m ") And line.Contains("s") Then
                            RA = DMSToNum(line, "RA")
                            HasRA = True
                        ElseIf IsNumeric(line) Then
                            RA = CDbl(line)
                            HasRA = True
                        Else
                            Throw New Exception("RA_INVALID")
                        End If
                    ElseIf Left(Command, 3) = "DEC" Then
                        If line.Contains("d ") And line.Contains("m ") And line.Contains("s") Then
                            DEC = DMSToNum(line, "DEC")
                            HasDEC = True
                        ElseIf IsNumeric(line) Then
                            DEC = CDbl(line)
                            HasDEC = True
                        Else
                            Throw New Exception("DEC_INVALID")
                        End If
                    ElseIf Left(Command, 4) = "GOTO" Then
                        If line.ToUpper = "COOR" Then
                            If HasRA = False Or HasDEC = False Then
                                Throw New Exception("GOTO_NO_COOR")
                            Else
                                If EpochSet = EpochMode.J2000 Then
                                    Dim result As Double() = U.Precess2000ToNow(RA, DEC)
                                    RA = result(0)
                                    DEC = result(1)
                                End If
                                T.SlewToRaDec(RA, DEC, "RA/DEC")
                                Obj = Nothing
                                WriteLog("GOTO_RA=" & RA.ToString & "DEC=" & DEC.ToString)
                            End If
                        Else
                            If EnableXDB And ContainChinese(line) Then
                                Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= ExtraGotoBase.mdb"
                                Dim conn As OleDbConnection = New OleDbConnection(connectionString)
                                Dim cmd As OleDbCommand
                                Dim find As String = line
                                line = Nothing
                                cmd = New OleDbCommand("SELECT [ENG], [CHS] FROM [BrightStar] WHERE [CHS] = '" & find & "'", conn)
                                conn.Open()
                                Dim dr As OleDbDataReader = cmd.ExecuteReader()
                                While dr.Read
                                    line = dr("ENG")
                                End While
                                dr.Close()
                                conn.Close()

                                If line = Nothing Then
                                    cmd = New OleDbCommand("SELECT [ENG], [CHS] FROM [SolarSys] WHERE [CHS] = '" & find & "'", conn)
                                    conn.Open()
                                    dr = cmd.ExecuteReader
                                    While dr.Read
                                        line = dr("ENG")
                                    End While
                                    dr.Close()
                                    conn.Close()
                                End If
                            End If
                            line = line.Replace("_", " ")
                            TS.GetObjectRaDec(line)
                            T.SlewToRaDec(TS.dObjectRa, TS.dObjectDec, line)
                            Obj = line
                            WriteLog("GOTO_" & line)
                        End If
                    ElseIf Left(Command, 4) = "STYP" Then
                        Select Case line
                            Case "light", "dark", "bias", "flat"
                                STYP = line
                                Select Case line
                                    Case "light", "flat"
                                        If EnableSCM Then
                                            If SCM.CoverSStatus = 0 Then SCM.CoverSOpen()
                                        Else
                                            Throw New Exception("STYP_SCM_DISABLED")
                                        End If
                                    Case "dark", "bias"
                                        If EnableSCM Then
                                            If SCM.CoverSStatus = 1 Then SCM.CoverSClose()
                                        Else
                                            Throw New Exception("STYP_SCM_DISABLED")
                                        End If
                                End Select
                            Case Else
                                Throw New Exception("STYP_INVALID")
                        End Select
                    ElseIf Left(Command, 4) = "SEXP" Then
                        Dim Ii As Integer
                        Dim d As Single
                        Dim nn As Integer
                        If line.Contains("|") = True Then
                            Ii = InStr(line, "|")
                            d = CSng(Left(line, Ii - 1))
                            nn = CInt(Right(line, (line.Length - Ii)))
                        Else
                            d = line
                            nn = 1
                        End If
                        If d <= 0 Or d > 600 Or nn <= 0 Then
                            Throw New Exception("SEXP_OUT_OF_RANGE")
                        Else
                            Dim originSSEQ As Integer = SSEQ
                            If Obj = Nothing And T_inited Then T.GetRaDec()
                            While SSEQ - originSSEQ < nn
                                C_sub.Expose(d, 1)
                                Do While Not C_sub.ImageReady
                                Loop
                                'Set FITS Keys OBJECT/OBJCTRA/OBJCTDEC
                                If Obj = Nothing And T_inited Then
                                    C_sub.SetFITSKey("OBJCTRA", T.dRA.ToString)
                                    C_sub.SetFITSKey("OBJCTDEC", T.dDec.ToString)
                                Else
                                    If Obj IsNot Nothing Then C_sub.SetFITSKey("OBJECT", Obj)
                                End If
                                Dim path As String = GivePath(SPRE, SSEQ)
                                C_sub.SaveImage(path)
                                MaxImDoc = MaxImApp.CurrentDocument
                                'MaxImDoc.OpenFile(path)
                                MaxImDoc.SaveFile(PvSubPath, ImageFormatType.mxJPEG, True, , 50)
                                MaxImDoc.Close()
                                SSEQ += 1
                                WriteLog("SEXP_" & d.ToString & "s")
                            End While
                        End If
                    ElseIf Left(Command, 4) = "MTYP" Then
                        Select Case line
                            Case "light", "dark", "bias", "flat"
                                MTYP = line
                            Case Else
                                Throw New Exception("MTYP_INVALID")
                        End Select
                    ElseIf Left(Command, 4) = "MEXP" Then
                        Dim Ii As Integer
                        Dim d As Single
                        Dim nn As Integer
                        If line.Contains("|") = True Then
                            Ii = InStr(line, "|")
                            d = CSng(Left(line, Ii - 1))
                            nn = CInt(Right(line, (line.Length - Ii)))
                        Else
                            d = line
                            nn = 1
                        End If
                        Select Case MTYP
                            Case "light"
                                C_main.Frame = CdImageFrame.cdLight
                            Case "dark"
                                C_main.Frame = CdImageFrame.cdDark
                            Case "flat"
                                C_main.Frame = CdImageFrame.cdFlat
                            Case "bias"
                                C_main.Frame = CdImageFrame.cdBias
                        End Select
                        If (d >= 0 And d < 300) Or (d = 0 And MTYP = "bias") Then

                            C_main.AutoSavePath = NamePath
                            C_main.AutoSavePrefix = "MAIN_" + MPRE
                            C_main.ExposureTime = d
                            C_main.Series = nn
                            C_main.TakeImage()
                            If CCDSoftDoc.Path = Nothing Then CCDSoftDoc.AttachToActiveImager()
                            CCDSoftDoc.AutoContrast(CdAutoContrastMethod.cdAutoContrastSBIG, CdBjornBackground.cdBgMedium, CdBjornHighlight.cdHLMedium)
                            CCDSoftDoc.SaveAs(CdSaveAs.cdJPG, 50)
                            File.Delete(PvMainPath)
                            File.Move(CCDSoftDoc.Path, PvMainPath)
                        Else
                            Throw New Exception("MEXP_OUT_OF_RANGE")
                        End If
                    ElseIf Left(Command, 4) = "MFIL" Then
                        Dim f As Integer
                        Select Case LCase(line)
                            Case C_main.szFilterName(0), "0"
                                f = 0
                            Case C_main.szFilterName(1), "1"
                                f = 1
                            Case C_main.szFilterName(2), "2"
                                f = 2
                            Case C_main.szFilterName(3), "3"
                                f = 3
                            Case C_main.szFilterName(4), "4"
                                f = 4
                            Case "-1"
                            Case Else
                                Throw New Exception("MFIL_INVALID")
                        End Select
                        C_main.FilterIndexZeroBased = f
                        WriteLog("MFIL_" & line)
                    ElseIf Left(Command, 4) = "SFOC" Then
                        Dim d As Single = CSng(line)
                        If d <= 0 Or d > 10 Then
                            Throw New Exception("SFOC_OUT_OF_RANGE")
                        Else
                            MaxImApp.Autofocus(d)
                            WriteLog("SFOC_" & line)
                        End If
                    ElseIf Left(Command, 4) = "MFOC" Then
                        Dim d As Single = CSng(line)
                        If d <= 0 Or d > 10 Then
                            Throw New Exception("MFOC_OUT_OF_RANGE")
                        Else
                            C_main.AtFocusSamples = 10
                            C_main.AtFocusAveraging = 2
                            C_main.FocusExposureTime = d
                            C_main.AtFocus()
                            WriteLog("MFOC_" & line)
                        End If
                    ElseIf Left(Command, 4) = "STEM" Then
                        If IsNumeric(line) Then
                            If CDbl(line) < 20 And CDbl(line) > -40 Then
                                C_sub.TemperatureSetpoint = CDbl(line)
                                C_sub.CoolerOn = True
                                WriteLog("STEM_" & line)
                            End If
                        ElseIf LCase(line) = "off" Then
                            C_sub.CoolerOn = False
                            WriteLog("STEM_OFF")
                        Else
                            Throw New Exception("STEM_INVALID")
                        End If
                    ElseIf Left(Command, 4) = "MTEM" Then
                        If IsNumeric(line) Then
                            If CDbl(line) < 20 And CDbl(line) > -40 Then
                                C_main.TemperatureSetPoint = CDbl(line)
                                C_main.RegulateTemperature = 1
                                WriteLog("MTEM_" & line)
                            End If
                        ElseIf LCase(line) = "off" Then
                            C_main.RegulateTemperature = 0
                            WriteLog("MTEM_OFF")
                        Else
                            Throw New Exception("MTEM_INVALID")
                        End If
                    ElseIf Left(Command, 4) = "SBIN" Then
                        Select Case line
                            Case "1*1"
                                C_sub.BinX = C_sub.BinY = 1
                            Case "2*2"
                                C_sub.BinX = C_sub.BinY = 2
                            Case "4*4"
                                C_sub.BinX = C_sub.BinY = 4
                            Case Else
                                Throw New Exception("SBIN_INVALID")
                        End Select
                    ElseIf Left(Command, 4) = "MBIN" Then
                        Select Case line
                            Case "1*1"
                                C_main.BinX = C_main.BinY = 1
                            Case "2*2"
                                C_main.BinX = C_main.BinY = 2
                            Case "4*4"
                                C_main.BinX = C_main.BinY = 4
                            Case Else
                                Throw New Exception("MBIN_INVALID")
                        End Select
                    ElseIf Left(Command, 4) = "OPEN" Then
                        If EnableSCM = False Then Throw New Exception("SCM_DISABLED")
                        Dim para As String = LCase(line)
                        Dim r As Boolean
                        Select Case para
                            Case "dome"
                                r = SCM.DomeOpen
                                If RunMode = Mode.Script Then Threading.Thread.Sleep(SCM.T_DOME * 1000)
                            Case "led"
                                r = SCM.LEDOpen
                            Case "mcover"
                                r = SCM.CoverMOpen
                                If RunMode = Mode.Script Then Threading.Thread.Sleep(SCM.T_COVERM * 1000)
                            Case "scover"
                                r = SCM.CoverSOpen
                                If RunMode = Mode.Script Then Threading.Thread.Sleep(SCM.T_COVERS * 1000)
                            Case "power"
                                r = SCM.Power1Con
                                If RunMode = Mode.Script Then Threading.Thread.Sleep(5000)
                            Case Else
                                Throw New Exception("OPEN_INVALID")
                        End Select
                        If r = False Then Throw New Exception("OPEN_" & UCase(para) & "_FAIL")
                        WriteLog("OPEN_" & UCase(para))
                    ElseIf Left(Command, 4) = "CLOS" Then
                        If EnableSCM = False Then Throw New Exception("SCM_DISABLED")
                        Dim para As String = LCase(line)
                        Dim r As Boolean
                        Select Case para
                            Case "dome"
                                r = SCM.DomeClose
                                If RunMode = Mode.Script Then Threading.Thread.Sleep(SCM.T_DOME * 1000)
                            Case "led"
                                r = SCM.LEDClose
                            Case "mcover"
                                r = SCM.CoverMClose
                                If RunMode = Mode.Script Then Threading.Thread.Sleep(SCM.T_COVERM * 1000)
                            Case "scover"
                                r = SCM.CoverSClose
                                If RunMode = Mode.Script Then Threading.Thread.Sleep(SCM.T_COVERS * 1000)
                            Case "power"
                                r = SCM.Power1Discon
                            Case Else
                                Throw New Exception("CLOS_INVALID")
                        End Select
                        If r = False Then Throw New Exception("OPEN_" & UCase(para) & "_FAIL")
                        WriteLog("CLOSE_" & UCase(para))
                    ElseIf Left(Command, 4) = "STOP" Then
                        If EnableSCM = False Then Throw New Exception("SCM_DISABLED")
                        Dim para As String = LCase(line)
                        Dim r As Boolean
                        Select Case para
                            Case "dome"
                                r = SCM.DomeStop
                            Case Else
                                Throw New Exception("STOP_INVALID")
                        End Select
                        If r = False Then Throw New Exception("STOP_" & UCase(para) & "_FAIL")
                        WriteLog("STOP_" & UCase(para))
                    ElseIf Left(Command, 3) = "OFF" Then
                        Dim para As String = LCase(line)
                        If para = "scm" Then EnableSCM = False
                        If para = "weather" Then EnableW = False
                        If para = "xbase" Then EnableXDB = False
                    ElseIf Left(Command, 2) = "ON" Then
                        Dim para As String = LCase(line)
                        If para = "scm" Then EnableSCM = True
                        If para = "weather" Then EnableW = True
                        If para = "xbase" Then EnableXDB = True
                    ElseIf Left(Command, 4) = "AIRC" Then
                        Dim r As Boolean
                        Dim para As String = LCase(line)
                        If station = "HGXnR" Then
                            Select Case para
                                Case "power"
                                    r = SCM.CoolerPwr()
                                Case "up"
                                    r = SCM.CoolerUp()
                                Case "down"
                                    r = SCM.CoolerDown()
                            End Select
                            If r = False Then Throw New Exception("AIRC_" & UCase(para) & "_FAIL")
                            WriteLog("AIRC_" & UCase(para))
                        Else
                            Throw New Exception("AIRC_NOT_AVAILABLE")
                        End If
                        ''''' For Script Mode Only '''''
                    ElseIf Left(Command, 4) = "LOOP" And RunMode = Mode.Script Then
                        If RunMode = Mode.Script Then
                            LoopTimeTable.Push(CInt(line))
                            LoopStartTable.Push(Seek(longHandle))
                        Else
                            GoTo CommandInvalid
                        End If
                    ElseIf Left(Command, 3) = "END" And RunMode = Mode.Script Then
                        Dim para As String = LCase(line)
                        Dim LoopTime As Integer
                        Select Case para
                            Case "loop"
                                LoopTime = LoopTimeTable.Pop - 1
                                If LoopTime > 0 Then
                                    If LoopStartTable.Count > 0 Then
                                        Seek(longHandle, LoopStartTable.Peek)
                                    Else
                                        Throw New Exception("LOOP_WRONG_LAYER")
                                    End If
                                    LoopTimeTable.Push(LoopTime)
                                Else
                                    LoopStartTable.Pop()
                                End If
                            Case Else
                                Throw New Exception("END_INVALID")
                        End Select
                    ElseIf Left(Command, 4) = "INFO" Then
                        Dim para As String = LCase(line)
                        Dim status As Integer = -999
                        Dim r As String = Nothing
                        WriteLog("INFO_" & para.ToUpper)
                        Select Case para
                            Case "dome"
                                If EnableSCM Then
                                    status = SCM.DomeStatus
                                Else
                                    WriteLog("SCM_DISABLED")
                                End If
                            Case "mcover"
                                If EnableSCM Then
                                    status = SCM.CoverMStatus
                                Else
                                    WriteLog("SCM_DISABLED")
                                End If
                            Case "scover"
                                If EnableSCM Then
                                    status = SCM.CoverSStatus
                                Else
                                    WriteLog("SCM_DISABLED")
                                End If
                            Case "led"
                                If EnableSCM Then
                                    status = SCM.LEDStatus
                                Else
                                    WriteLog("SCM_DISABLED")
                                End If
                            Case "power"
                                If EnableSCM Then
                                    status = SCM.Power1Status
                                Else
                                    WriteLog("SCM_DISABLED")
                                End If
                            Case "mtemp"
                                r = C_main.Temperature
                            Case "mtempsp"
                                r = C_main.TemperatureSetPoint
                            Case "mfilter"
                                r = C_main.FilterIndexZeroBased
                                If r = Nothing Then
                                    r = -1
                                End If
                            Case "stemp"
                                r = (C_sub.Temperature)
                            Case "stempsp"
                                r = (C_sub.TemperatureSetpoint)
                            Case "ra"
                                T.GetRaDec()
                                r = (T.dRA)
                                If EpochSet = EpochMode.J2000 Then r = "O" & r
                            Case "dec"
                                T.GetRaDec()
                                r = (T.dDec)
                                If EpochSet = EpochMode.J2000 Then r = "O" & r
                            Case "az"
                                T.GetAzAlt()
                                r = (T.dAz)
                            Case "alt"
                                T.GetAzAlt()
                                r = (T.dAlt)
                            Case "ha"
                                T.GetRaDec()
                                r = (U.ComputeHourAngle(T.dRA))
                            Case "epoch"
                                Return EpochSet
                            Case "ambtemp"
                                If EnableW Then
                                    r = W.AmbientT
                                Else
                                    WriteLog("WEATHER_DISABLED")
                                End If
                            Case "ambhum"
                                If EnableW Then
                                    r = W.HumidityPercent
                                Else
                                    WriteLog("WEATHER_DISABLED")
                                End If
                            Case "wind"
                                If EnableW Then
                                    r = (W.Wind)
                                Else
                                    WriteLog("WEATHER_DISABLED")
                                End If
                            Case "cloud"
                                If EnableW Then
                                    r = W.CloudCondition
                                Else
                                    WriteLog("WEATHER_DISABLED")
                                End If
                            Case "intemp"
                                If EnableSCM Then
                                    r = SCM.TempGet(0)
                                Else
                                    WriteLog("SCM_DISABLED")
                                End If
                            Case "inhum"
                                If EnableSCM Then
                                    r = SCM.TempGet(1)
                                Else
                                    WriteLog("SCM_DISABLED")
                                End If
                            Case "ver"
                                r = "TABLET " & TABLETVersion & " / Core " & AssemblyVersion
                            Case "station"
                                r = station
                            Case Else
                                r = "INFO_INVALID"
                                WriteLog("INFO_INVALID")
                        End Select
                        Select Case status
                            Case 0
                                r = "close"
                            Case 1
                                r = "open"
                            Case -1
                                r = "INFO_SCM_FAILED"
                                WriteLog("INFO_SCM_FAILED")
                        End Select
                        If RunMode = Mode.Command Then Return r
                        If RunMode = Mode.Script Then WriteLog(para & ": " & r)
                    ElseIf Left(Command, 4) = "WAIT" Then
                        Threading.Thread.Sleep(CInt(line) * 1000)
                    Else
CommandInvalid:
                        Throw New Exception("COMMAND_INVALID")
                    End If
                End If
BlankLine:
                If RunMode = Mode.Command Then Exit Try
            Loop
            FileClose(longHandle)
        Catch ex As Exception
            ErrorHappen(ex.Message, LineNum)
            FileClose(longHandle)
            Return ex.Message
        End Try
    End Function
    Public Function Save() As Boolean
        File.WriteAllText(SubSeqPath, SSEQ.ToString)
        Return True
    End Function
#Region "acc"
    Private Function DMSToNum(ByVal str As String, ByVal func As String) As String
        Dim I1, I2, I3 As Integer
        Dim d, m, s As Double
        Dim out As Double
        If func = "RA" Then
            I1 = InStr(str, "h")
        ElseIf func = "DEC" Then
            I1 = InStr(str, "d")
        End If
        I2 = InStr(str, "m")
        I3 = InStr(str, "s")
        d = CDbl(Left(str, I1 - 1).Trim)
        m = CDbl(str.Substring(I1 + 1, I2 - I1 - 2).Trim)
        s = CDbl(str.Substring(I2 + 1, I3 - I2 - 2).Trim)
        out = d + (m / 60) + (s / 3600)
        Return out
    End Function
    Private Sub WriteLog(ByVal action As String)
        While WritingLog = False
            WritingLog = True
            Dim now As String = Date.Now
            Dim logName As String = LogPath
            If Directory.Exists(NamePath + "logs\") = False Then
                Directory.CreateDirectory(NamePath + "logs\")
            End If
            If File.Exists(logName) = False Then
                File.CreateText(logName).Close()
            End If
            Dim stread As TextReader = File.OpenText(logName)
            Dim st As String = stread.ReadToEnd
            Dim writechr As Boolean = False
            If Not st = Nothing Then
                If st.EndsWith(Chr(10)) = False Then
                    writechr = True
                End If
            End If
            stread.Close()
            Dim longHandle As Long
            longHandle = FreeFile()
            FileOpen(longHandle, logName, OpenMode.Append)
            If writechr = True Then
                PrintLine(longHandle, "")
            End If
            Dim line As String = "[" + now.ToString + "] " + action
            PrintLine(longHandle, line)
            FileClose(longHandle)
        End While
        WritingLog = False
        If RunMode = Mode.Script Then RaiseEvent Warning(action)
    End Sub
    Private Function GivePath(prefix As String, ca As Integer) As String
        Dim caL As String = ca.ToString.PadLeft(8, "0")
        Dim path1 As String = NamePath + "SUB_" + prefix + "." + caL
        Do While File.Exists(path1 + ".fit") = True
            prefix = prefix + "+"
            path1 = NamePath + "SUB_" + prefix + "_" + ca.ToString
        Loop
        Dim path As String = path1 + ".fit"
        Return path
    End Function
    Private Function ContainChinese(str As String) As Boolean
        Dim TmmP As String
        For i As Integer = 0 To str.Length - 1
            TmmP = str.Substring(i, 1)
            Dim sarr() As Byte = System.Text.Encoding.GetEncoding("gb2312").GetBytes(TmmP)
            If sarr.Length = 2 Then Return True
        Next
        Return False
    End Function
    Private Sub SCM_Reached(ByVal API_name As String, ByVal IfSuccess As Boolean) Handles SCM.Reached
        If IfSuccess Then
            WriteLog(API_name & "_REACHED")
            If RunMode = Mode.Command Then RaiseEvent Warning(API_name & "_REACHED")
        Else
            ErrorHappen(API_name & "_Failed(OutOfTime)", LineNum)
            GlobalError = True
        End If
    End Sub
#End Region
End Class
