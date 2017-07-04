Imports HP.Utils.SAPReader

Public Class Form1

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        If txt_UserName.Text <> "" And txt_UserPass.Text <> "" Then
            If connectSAP(txt_UserName.Text, txt_UserPass.Text) Then
                
                lbl_Error.Visible = True
                lbl_Error.Text = "Connected to SAP"
            Else
                lbl_Error.Visible = True
                lbl_Error.Text = "You have no access to SAP or your information was incorrect."
            End If
        Else
            lbl_Error.Visible = True
            lbl_Error.Text = "Please enter user name and password."
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Public Function connectSAP(userName As String, password As String)
        Dim result As Boolean
        result = False
        Dim sapConnection As SAPConnection
        sapConnection = New SAPConnection
        If sapConnection.Connect(userName, password, "sappn1.sapnet.hp.com", "0", "200", "SAPBOX", "ES", "10", "10") Then
            result = True
        End If
        Return result
    End Function

End Class