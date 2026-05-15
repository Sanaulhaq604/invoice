Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Windows.Forms

Public Class frmImageViewer
    Inherits Form

    ' ======================== FIELDS ========================

    Private ReadOnly _docId As Integer
    Private ReadOnly _docType As String

    Private _image As Image           ' current working image (may be rotated)
    Private _originalImage As Image   ' clean copy loaded from bytes, for reference
    Private _pictureBox As PictureBox
    Private _scrollPanel As Panel
    Private _topBar As Panel

    Private _zoom As Double = 1.0
    Private _isDragging As Boolean = False
    Private _dragStart As Point
    Private _isFullscreen As Boolean = False
    Private _isModified As Boolean = False

    ' ======================== CONSTRUCTOR ========================

    Public Sub New(docId As Integer, docType As String)
        _docId = docId
        _docType = docType
        InitializeComponent()
        ConfigureForm()
    End Sub

    ' ======================== INIT ========================

    Private Sub InitializeComponent()
        Me.ClientSize = New Size(800, 600)
        Me.Text = "Image Viewer"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.KeyPreview = True
        AddHandler Me.KeyDown, AddressOf frmImageViewer_KeyDown
        AddHandler Me.Load, AddressOf frmImageViewer_Load
    End Sub

    Private Sub ConfigureForm()

        ' ===== SCROLL PANEL (added first so top bar docks on top) =====
        _scrollPanel = New Panel With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True,
            .BackColor = Color.Black
        }
        Me.Controls.Add(_scrollPanel)

        ' ===== TOP BAR =====
        _topBar = New Panel With {
            .Height = 45,
            .Dock = DockStyle.Top,
            .BackColor = Color.FromArgb(30, 30, 30)
        }
        Me.Controls.Add(_topBar)

        ' ===== PICTURE BOX =====
        _pictureBox = New PictureBox With {
            .SizeMode = PictureBoxSizeMode.StretchImage,
            .Cursor = Cursors.Hand,
            .Location = New Point(0, 0)
        }

        AddHandler _pictureBox.MouseDown, AddressOf Picture_MouseDown
        AddHandler _pictureBox.MouseMove, AddressOf Picture_MouseMove
        AddHandler _pictureBox.MouseUp, AddressOf Picture_MouseUp
        AddHandler _pictureBox.MouseWheel, AddressOf Picture_MouseWheel
        AddHandler _pictureBox.DoubleClick, AddressOf ActualSize

        _scrollPanel.Controls.Add(_pictureBox)

        ' ===== BUTTONS =====
        '                  Label     Left  Handler
        AddButton("⟲ Left", 5, AddressOf RotateLeft)
        AddButton("⟳ Right", 75, AddressOf RotateRight)
        AddButton("+", 155, AddressOf ZoomIn)
        AddButton("−", 215, AddressOf ZoomOut)
        AddButton("Fit", 275, AddressOf FitToScreen)
        AddButton("100%", 340, AddressOf ActualSize)
        AddButton("Save", 415, AddressOf SaveImage)
        AddButton("Full", 490, AddressOf ToggleFullscreen)

    End Sub

    ' ======================== LOAD HANDLER ========================

    Private Sub frmImageViewer_Load(sender As Object, e As EventArgs)
        ' Nothing needed here now; image is loaded via LoadImage(bytes)
    End Sub

    ' ======================== LOAD IMAGE (from bytes) ========================

    ''' <summary>
    ''' Call this after New() to supply the image bytes fetched from DB.
    ''' </summary>
    Public Sub LoadImage(imgBytes() As Byte)

        If imgBytes Is Nothing OrElse imgBytes.Length = 0 Then
            Throw New ArgumentException("imgBytes is empty or Nothing.")
        End If

        ' Dispose old images safely
        DisposeImages()

        Using ms As New MemoryStream(imgBytes)
            ' Create a new Bitmap from the stream (stream can close after this)
            _image = New Bitmap(Image.FromStream(ms))
        End Using

        ' Keep a pristine copy (not used for display, reserved for future use)
        _originalImage = CType(_image.Clone(), Image)

        _zoom = 1.0
        _isModified = False

    End Sub

    ' ======================== SHOW IMAGE WITH MAX HEIGHT ========================
    Private _skipInitialAdjust As Boolean = False
    Private _forceNoScroll As Boolean = False
    Private _initializing As Boolean = False

    ''' <summary>
    ''' Load and show image with initial height equal to working area height (max visibility).
    ''' </summary>
    Public Sub ShowImageMaxHeight(imgBytes() As Byte)
        LoadImage(imgBytes)
        If _image Is Nothing Then
            Me.ShowDialog()
            Return
        End If
        Dim wa As Rectangle = Screen.FromControl(Me).WorkingArea
        ' Compute zoom so the image fits both width and height of the working area (no scrollbars)
        Dim zoomByH As Double = (wa.Height - _topBar.Height) / _image.Height
        Dim zoomByW As Double = wa.Width / _image.Width
        _zoom = Math.Min(zoomByH, zoomByW)
        If _zoom <= 0 Then _zoom = 1.0
        _skipInitialAdjust = True
        ' During initial display enforce no-scroll fit; afterwards allow larger zoom
        _initializing = True
        _forceNoScroll = True
        ResizeFormToZoom()
        ' Position the form at the left-most side of the working area and top for initial show
        Me.Left = wa.Left
        Me.Top = wa.Top
        ' Clear initialization flags so future zooms are unconstrained
        _initializing = False
        _forceNoScroll = False
        Me.ShowDialog()
    End Sub

    ' ======================== FORM SHOWN ========================

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        ' On first show, fit the form to the image unless overridden
        If Not _skipInitialAdjust Then AdjustFormToImage()
    End Sub

    ' ======================== FIT FORM TO IMAGE (initial / fit button) ========================

    ''' <summary>
    ''' Calculates the best zoom so the image fills the screen,
    ''' then resizes the form accordingly. Called on first show and Fit button.
    ''' </summary>
    Private Sub AdjustFormToImage()

        If _image Is Nothing Then Return

        Dim wa As Rectangle = Screen.FromControl(Me).WorkingArea

        Dim imgW As Double = _image.Width
        Dim imgH As Double = _image.Height

        ' Choose zoom that fits the image inside the working area
        ' (account for top bar height)
        Dim zoomByH As Double = (wa.Height - _topBar.Height) / imgH
        Dim zoomByW As Double = wa.Width / imgW

        ' Use whichever zoom is smaller so the whole image is visible
        _zoom = Math.Min(zoomByH, zoomByW)

        ' Now resize form around that zoom level
        ResizeFormToZoom()

    End Sub

    ' ======================== RESIZE FORM TO CURRENT ZOOM ========================

    ''' <summary>
    ''' Resizes the form to fit the zoomed image, capped at the screen working area.
    ''' Shows scrollbars when the zoomed image is larger than the screen.
    ''' Called by all zoom actions.
    ''' </summary>
    Private Sub ResizeFormToZoom()

        If _image Is Nothing Then Return

        Dim wa As Rectangle = Screen.FromControl(Me).WorkingArea

        Dim scaledW As Integer = CInt(_image.Width * _zoom)
        Dim scaledH As Integer = CInt(_image.Height * _zoom)

        ' Desired form dimensions (image + top bar)
        Dim desiredFormW As Integer = scaledW
        Dim desiredFormH As Integer = scaledH + _topBar.Height

        ' Will scrollbars be needed?
        Dim needVScroll As Boolean = desiredFormH > wa.Height
        Dim needHScroll As Boolean = desiredFormW > wa.Width

        ' Add scrollbar thickness to avoid the *other* scrollbar appearing unnecessarily
        If needVScroll Then desiredFormW += SystemInformation.VerticalScrollBarWidth
        If needHScroll Then desiredFormH += SystemInformation.HorizontalScrollBarHeight

        ' Cap form to screen
        Dim finalW As Integer = Math.Min(desiredFormW, wa.Width)
        Dim finalH As Integer = Math.Min(desiredFormH, wa.Height)

        ' If caller requested no scrollbars only during initialization, ensure the scaled image fits within the working area
        If _forceNoScroll And _initializing Then
            ' adjust zoom so both dimensions fit exactly
            If scaledW > wa.Width Then
                Dim adj As Double = wa.Width / _image.Width
                _zoom = Math.Min(_zoom, adj)
                scaledW = CInt(_image.Width * _zoom)
            End If
            If scaledH > wa.Height - _topBar.Height Then
                Dim adj As Double = (wa.Height - _topBar.Height) / _image.Height
                _zoom = Math.Min(_zoom, adj)
                scaledH = CInt(_image.Height * _zoom)
            End If
            desiredFormW = scaledW
            desiredFormH = scaledH + _topBar.Height
            finalW = Math.Min(desiredFormW, wa.Width)
            finalH = Math.Min(desiredFormH, wa.Height)
        End If

        ' Skip re-centering if fullscreen (window is maximised)
        If Not _isFullscreen Then
            Me.Width = finalW
            Me.Height = finalH
            If _forceNoScroll Then
                ' position at left-top of working area
                Me.Left = wa.Left
                Me.Top = wa.Top
            Else
                Me.Left = wa.Left + (wa.Width - Me.Width) \ 2
                Me.Top = wa.Top + (wa.Height - Me.Height) \ 2
            End If
        End If

        ' Apply picture box size and image
        _pictureBox.Size = New Size(scaledW, scaledH)
        _pictureBox.Location = New Point(0, 0)
        _pictureBox.Image = _image

        ' Scroll panel: enable scrolling when image exceeds visible area unless forced off
        _scrollPanel.AutoScrollMinSize = New Size(scaledW, scaledH)
        If _forceNoScroll Then
            _scrollPanel.AutoScroll = False
        Else
            _scrollPanel.AutoScroll = (scaledH > _scrollPanel.ClientSize.Height OrElse scaledW > _scrollPanel.ClientSize.Width)
        End If

    End Sub

    ' ======================== BUTTON HELPER ========================

    Private Sub AddButton(text As String, left As Integer, handler As EventHandler)
        Dim btn As New Button With {
            .Text = text,
            .Width = 65,
            .Height = 30,
            .Left = left,
            .Top = 7,
            .ForeColor = Color.White,
            .BackColor = Color.FromArgb(60, 60, 60),
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 9)
        }
        btn.FlatAppearance.BorderSize = 0
        AddHandler btn.Click, handler
        _topBar.Controls.Add(btn)
    End Sub

    ' ======================== ZOOM ========================

    Private Sub ZoomIn(sender As Object, e As EventArgs)
        _zoom = Math.Round(_zoom + 0.1, 2)
        ResizeFormToZoom()
    End Sub

    Private Sub ZoomOut(sender As Object, e As EventArgs)
        If _zoom > 0.15 Then
            _zoom = Math.Round(_zoom - 0.1, 2)
            ResizeFormToZoom()
        End If
    End Sub

    ''' <summary>Reset zoom to 100% (actual pixels).</summary>
    Private Sub ActualSize(sender As Object, e As EventArgs)
        _zoom = 1.0
        ResizeFormToZoom()
    End Sub

    Private Sub FitToScreen(sender As Object, e As EventArgs)
        AdjustFormToImage()
    End Sub

    Private Sub Picture_MouseWheel(sender As Object, e As MouseEventArgs)
        If e.Delta > 0 Then
            _zoom = Math.Round(_zoom + 0.1, 2)
        ElseIf _zoom > 0.15 Then
            _zoom = Math.Round(_zoom - 0.1, 2)
        End If
        ResizeFormToZoom()
    End Sub

    ' ======================== DRAG TO PAN ========================

    Private Sub Picture_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            _isDragging = True
            _dragStart = e.Location
            _pictureBox.Cursor = Cursors.SizeAll
        End If
    End Sub

    Private Sub Picture_MouseMove(sender As Object, e As MouseEventArgs)
        If _isDragging Then
            ' Shift the picture box within the scroll panel for panning
            Dim newLeft As Integer = _pictureBox.Left + (e.X - _dragStart.X)
            Dim newTop As Integer = _pictureBox.Top + (e.Y - _dragStart.Y)
            _pictureBox.Left = newLeft
            _pictureBox.Top = newTop
        End If
    End Sub

    Private Sub Picture_MouseUp(sender As Object, e As MouseEventArgs)
        _isDragging = False
        _pictureBox.Cursor = Cursors.Hand
    End Sub

    ' ======================== ROTATE ========================

    Private Sub RotateLeft(sender As Object, e As EventArgs)
        If _image Is Nothing Then Return
        _image.RotateFlip(RotateFlipType.Rotate270FlipNone)
        _isModified = True
        ResizeFormToZoom()   ' keep current zoom, just re-layout
    End Sub

    Private Sub RotateRight(sender As Object, e As EventArgs)
        If _image Is Nothing Then Return
        _image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        _isModified = True
        ResizeFormToZoom()
    End Sub

    ' ======================== SAVE TO FILE ========================

    Private Sub SaveImage(sender As Object, e As EventArgs)
        If _image Is Nothing Then Return

        Using sfd As New SaveFileDialog With {
            .Title = "Save Image",
            .Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap|*.bmp",
            .DefaultExt = "jpg"
        }
            If sfd.ShowDialog() = DialogResult.OK Then
                Select Case Path.GetExtension(sfd.FileName).ToLower()
                    Case ".png"
                        _image.Save(sfd.FileName, ImageFormat.Png)
                    Case ".bmp"
                        _image.Save(sfd.FileName, ImageFormat.Bmp)
                    Case Else
                        _image.Save(sfd.FileName, ImageFormat.Jpeg)
                End Select
            End If
        End Using
    End Sub

    ' ======================== SAVE TO DATABASE ========================

    Private Sub SaveImageToDatabase()

        If _image Is Nothing Then Return

        Dim imgBytes() As Byte

        Using ms As New MemoryStream()
            _image.Save(ms, ImageFormat.Jpeg)
            imgBytes = ms.ToArray()
        End Using

        Dim connStr As String =
            "Data Source=" & frmLogin.MySqlServer &
            ";Database=images;User ID=sa;Password=Ai;"

        Using con As New SqlConnection(connStr)
            con.Open()
            Dim cmd As New SqlCommand(
                "UPDATE name_reciepts SET image = @img " &
                "WHERE doc = @docId AND type = @docType", con)
            cmd.Parameters.AddWithValue("@img", imgBytes)
            cmd.Parameters.AddWithValue("@docId", _docId)
            cmd.Parameters.AddWithValue("@docType", _docType)
            cmd.ExecuteNonQuery()
        End Using

    End Sub

    ' ======================== FULLSCREEN ========================

    Private Sub ToggleFullscreen(sender As Object, e As EventArgs)

        _isFullscreen = Not _isFullscreen

        If _isFullscreen Then
            Me.FormBorderStyle = FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.FormBorderStyle = FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Normal
            ResizeFormToZoom()   ' restore size based on current zoom
        End If

        UpdateScrollPanel()

    End Sub

    ''' <summary>
    ''' Refreshes the scroll panel and picture box without changing form size.
    ''' Used after fullscreen toggle.
    ''' </summary>
    Private Sub UpdateScrollPanel()
        If _image Is Nothing Then Return

        Dim scaledW As Integer = CInt(_image.Width * _zoom)
        Dim scaledH As Integer = CInt(_image.Height * _zoom)

        _pictureBox.Size = New Size(scaledW, scaledH)
        _pictureBox.Location = New Point(0, 0)
        _pictureBox.Image = _image

        _scrollPanel.AutoScrollMinSize = New Size(scaledW, scaledH)
        _scrollPanel.AutoScroll = (scaledH > _scrollPanel.ClientSize.Height OrElse
                                   scaledW > _scrollPanel.ClientSize.Width)
    End Sub

    ' ======================== KEYBOARD ========================

    Private Sub frmImageViewer_KeyDown(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.Left
                RotateLeft(Nothing, EventArgs.Empty)
            Case Keys.Right
                RotateRight(Nothing, EventArgs.Empty)
            Case Keys.Add, Keys.Oemplus
                ZoomIn(Nothing, EventArgs.Empty)
            Case Keys.Subtract, Keys.OemMinus
                ZoomOut(Nothing, EventArgs.Empty)
            Case Keys.F
                ToggleFullscreen(Nothing, EventArgs.Empty)
            Case Keys.D0, Keys.NumPad0
                ActualSize(Nothing, EventArgs.Empty)
        End Select
    End Sub

    ' ======================== DISPOSE HELPERS ========================

    Private Sub DisposeImages()
        If _pictureBox IsNot Nothing Then _pictureBox.Image = Nothing
        If _image IsNot Nothing Then
            _image.Dispose()
            _image = Nothing
        End If
        If _originalImage IsNot Nothing Then
            _originalImage.Dispose()
            _originalImage = Nothing
        End If
    End Sub

    ' ======================== CLOSE ========================

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        MyBase.OnFormClosed(e)

        Try
            If _isModified Then
                SaveImageToDatabase()
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving image to database: " & ex.Message,
                            "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DisposeImages()
        End Try

    End Sub

End Class