Public Class Login

    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        teleSCM_GUI.M.veri = {txtUser.Text, txtKey.Text}
        teleSCM_GUI.init()
        Me.Close()
    End Sub
End Class