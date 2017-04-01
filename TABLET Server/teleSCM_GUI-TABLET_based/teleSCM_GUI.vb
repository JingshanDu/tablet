'HGAO Remote Controlling Component -- TABLET Server
'TABLET-based SCM Controller; Branch of teleSCM_GUI
'This project is the preparation for the TCC component in the TABLET Client SDK
'Part of the Terminal Automation Batch Language Environment for Telescopes
'(C)2012 DU Jingshan, Hanggao Astronomical Observatory
Imports System.Runtime.Remoting
Imports teleSCM_GUI.TS
Public Class teleSCM_GUI
    Public N_FINISHED = "Action FINISHED."
    Public N_FAILED = "Action FAILED."
    Public N_ACTING = "Acting..."

    Private Property pCa As Integer
    Private Property pCb As Integer
    Private Addr As String
    Friend M As New Midium

    Private Sub GUI_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Remoting
        Dim channel As Channels.Http.HttpChannel = New Channels.Http.HttpChannel
        Channels.ChannelServices.RegisterChannel(channel, False)
        Addr = txtAddr.Text
        ActivateChannel()
        Login.ShowDialog()

        'Control.CheckForIllegalCrossThreadCalls = False
    End Sub
    Private Sub GUI_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        M.Command("home scm")
    End Sub
    Sub init()
        Dim title As String

        M.Command("init scm")

        If M.Command("info station") = "HGTHP" Then
            grpAir.Visible = False
            title &= "[HGTHP]"
        Else
            title &= "[HGXnR}"
        End If
        Me.Text = title
    End Sub
#Region "Control Buttons"
    Private Sub btnDomeOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnDomeOpen.Click
        txtMsg.Text = N_ACTING
        btnDomeOpen.Enabled = False
        btnDomeClose.Enabled = False
        M.Command("open dome")
        txtMsg.Text = N_ACTING
    End Sub
    Private Sub btnDomeClose_Click(sender As System.Object, e As System.EventArgs) Handles btnDomeClose.Click
        btnDomeOpen.Enabled = False
        btnDomeClose.Enabled = False
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Command("clos dome")
        If r = True Then
            txtMsg.Text = N_ACTING
        Else
            txtMsg.Text = N_FAILED
            btnDomeOpen.Enabled = True
            btnDomeClose.Enabled = True
        End If
    End Sub
    Private Sub btnDomeStop_Click(sender As System.Object, e As System.EventArgs) Handles btnDomeStop.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Command("stop dome")
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
        btnDomeOpen.Enabled = True
        btnDomeClose.Enabled = True
    End Sub
    Private Sub btnCoverMOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnCoverMOpen.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Command("open mcover")
        If r = True Then
            txtMsg.Text = N_ACTING

        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnCoverMClose_Click(sender As System.Object, e As System.EventArgs) Handles btnCoverMClose.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Command("clos mcover")
        If r = True Then
            txtMsg.Text = N_ACTING
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnCoverSOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnCoverSOpen.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Command("open scover")
        If r = True Then
            txtMsg.Text = N_ACTING
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnCoverSClose_Click(sender As System.Object, e As System.EventArgs) Handles btnCoverSClose.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Command("clos scover")
        If r = True Then
            txtMsg.Text = N_ACTING
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnPower1Con_Click(sender As System.Object, e As System.EventArgs) Handles btnPower1Con.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Command("open power")
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnPower1Discon_Click(sender As System.Object, e As System.EventArgs) Handles btnPower1Discon.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Command("clos power")
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnCoolerPwr_Click(sender As System.Object, e As System.EventArgs) Handles btnCoolerPwr.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Command("airc power")
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnCoolerUp_Click(sender As System.Object, e As System.EventArgs) Handles btnCoolerUp.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Command("airc up")
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnCoolerDown_Click(sender As System.Object, e As System.EventArgs) Handles btnCoolerDown.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Command("airc down")
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnLEDOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnLEDOpen.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Command("open led")
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnLEDClose_Click(sender As System.Object, e As System.EventArgs) Handles btnLEDClose.Click
        txtMsg.Text = N_ACTING
        Dim r As Boolean = M.Command("clos led")
        If r = True Then
            txtMsg.Text = N_FINISHED
        Else
            txtMsg.Text = N_FAILED
        End If
    End Sub
    Private Sub btnTempGet_Click(sender As System.Object, e As System.EventArgs) Handles btnTempGet.Click
        Dim txt As String = M.Command("info intemp")
        Replace(txt, "-99", "err")
        txtTemp.Text = txt
    End Sub
    Private Sub btnHumGet_Click(sender As System.Object, e As System.EventArgs) Handles btnHumGet.Click
        Dim txt As String = M.Command("info inhum")
        Replace(txt, "-99", "err")
        txtTemp.Text = txt
    End Sub

    Private Sub btnResetCOM_Click(sender As System.Object, e As System.EventArgs) Handles btnResetCOM.Click
        M.Command("home scm")
        M.Command("init scm")
    End Sub
    'Status Group
    Private Sub btnGetRelay1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnGetRelay1.LinkClicked
        txtStatus1.Text = M.Command("info power")
    End Sub
    Private Sub btnGetDome_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnGetDome.LinkClicked
        txtStatus1.Text = M.Command("info dome")
    End Sub
    Private Sub btnGetLED_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnGetLED.LinkClicked
        txtStatus1.Text = M.Command("info led")
    End Sub

    Private Sub btnGetCoverS_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnGetCoverS.LinkClicked
        txtStatus2.Text = M.Command("info scover")
    End Sub
    Private Sub btnGetCoverM_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnGetCoverM.LinkClicked
        txtStatus2.Text = M.Command("info mcover")
    End Sub
#End Region

    Private Sub ActivateChannel()
        M.server = Nothing
        M.server = Activator.GetObject(GetType(TabletServer.TabletServer), Addr)
    End Sub
    Private Sub btnSetAddr_Click(sender As System.Object, e As System.EventArgs) Handles btnSetAddr.Click
        Addr = txtAddr.Text
        ActivateChannel()
    End Sub
    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        Login.ShowDialog()
    End Sub
End Class

Public Class Midium
    Public server As TabletServer.TabletServer
    Public veri(2) As String
    Public Function Command(cmd As String) As String
        Return server.Command(cmd, veri)
    End Function
    Public Function Script(scr As String) As String
        Return server.Script(scr, veri)
    End Function
End Class

