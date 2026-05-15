Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window

'Imports Google.Apis.Auth
'Imports Google.Apis.Auth.OAuth2
'Imports Google.Apis.Download
'Imports Google.Apis.Drive.v3
'Imports Google.Apis.Drive.v3.Data
'Imports Google.Apis.Services
'Imports Google.Apis.Upload

Public Class frmRouteWhatsapp

    'Private moService As DriveService = New DriveService
    'Public msViewLink As String = ""

    'Private Sub CreateService()


    '    Dim MyUserCredential As UserCredential =
    '        GoogleWebAuthorizationBroker.AuthorizeAsync(
    '        New ClientSecrets() With {.ClientId = ClientId, .ClientSecret = ClientSecret},
    '        {DriveService.Scope.Drive},
    '        "user",
    '        CancellationToken.None).Result

    '    moService = New DriveService(New BaseClientService.Initializer() With {
    '        .HttpClientInitializer = MyUserCredential,
    '        .ApplicationName = "MyGoogleDrive"})
    'End Sub

    'Public Function UploadFile(FileName As String, FilePath As String) As String

    '    If moService.ApplicationName <> "MyGoogleDrive" Then CreateService()

    '    Dim oGDriveFile As New File()
    '    oGDriveFile.Name = FileName
    '    oGDriveFile.Description = "Ahmed International"

    '    If FileName.Contains("PDF") Then
    '        oGDriveFile.MimeType = "application/pdf"
    '    ElseIf FileName.Contains("xls") Then
    '        oGDriveFile.MimeType = "application/vnd.ms-excel"
    '    End If

    '    Dim bArrByteArray As Byte() = IO.File.ReadAllBytes(FilePath)
    '    Dim oStream As New IO.MemoryStream(bArrByteArray)

    '    Dim oUploadRequest As FilesResource.CreateMediaUpload =
    '        moService.Files.Create(oGDriveFile, oStream, oGDriveFile.MimeType)

    '    oUploadRequest.Fields = "id"
    '    oUploadRequest.Alt = FilesResource.CreateMediaUpload.AltEnum.Json
    '    oUploadRequest.Upload()

    '    Dim oFile As File = oUploadRequest.ResponseBody

    '    Dim permission As New Google.Apis.Drive.v3.Data.Permission()
    '    permission.Type = "anyone"
    '    permission.Role = "writer"
    '    permission.AllowFileDiscovery = True

    '    Dim request As PermissionsResource.CreateRequest =
    '        moService.Permissions.Create(permission, oFile.Id)

    '    request.Fields = "id"
    '    request.Execute()

    '    msViewLink = ""

    '    If Not IsNothing(oFile) Then
    '        msViewLink = "https://drive.google.com/uc?id=" & oFile.Id
    '    Else
    '        Cursor.Current = Cursors.Default
    '        MessageBox.Show("Unable to contact Google Drive.", "Error")
    '        Return "No File"
    '    End If

    '    Return msViewLink

    'End Function

    Private Sub frmRouteWhatsapp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clipboard.Clear()

        Dim tb As DataTable = SQLData("select distinct route from coa where route is not null order by route")

        For n = 1 To tb.Rows.Count - 1
            cmbRoute.Items.Add(tb.Rows(n)("Route"))
        Next

        dtpRoute.Value = Date.Now.AddDays(2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openDLG As New OpenFileDialog
        openDLG.Filter = "Document Files (*.xls,*.pdf)|*.xls;*.pdf"

        DialogResult = openDLG.ShowDialog

        If DialogResult = Windows.Forms.DialogResult.OK Then

            Dim fullpath = IO.Path.GetFullPath(openDLG.FileName)
            Dim fileName As String = IO.Path.GetFileName(fullpath)

            'UPLOAD DISABLED (Google Drive removed)
            'txtLink.Text = UploadFile(fileName, fullpath)

            txtLink.Text = ""   'No cloud link anymore

            If txtLink.Text = "No File" Then
                MsgBox("No file uploaded")
                Return
            End If

        End If
    End Sub

    ' باقي code SAME (unchanged)
    ' WhatsApp, SMS, route logic all intact

End Class