Public Class Form1
    Public Ship As New Ship
    Public BitmapList As New ImageList
    Public BulletBitmap As Bitmap
    Public graphics As Graphics
    Dim formKey As Keys
    Dim currentMouse As Point
    Dim shipBitmap As Bitmap

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'BitmapList.ImageSize = New Size(16, 16)
        BulletBitmap = New Bitmap("C:\Users\Bluemech\Documents\Game Source FIles\WinGame\bullet.bmp")
        'BitmapList.TransparentColor = Color.Magenta
        Cursor.Hide()
        BackColor = Color.Black
        TimerDraw.Interval = 14
        TimerDraw.Enabled = True
        TimerDraw.Start()
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        formKey = e.KeyCode
        Select Case formKey
            Case Keys.Space
                'Ship.guns(0).Shoot()

            Case Keys.OemMinus

            Case Keys.Escape
                End
        End Select

    End Sub
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        graphics = Me.CreateGraphics
        graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.None

        Ship.DrawShip(graphics, Ship.Location)
    End Sub
    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        currentMouse = e.Location
        Ship.Location = currentMouse
    End Sub
    Private Sub TimerDraw_Tick(sender As Object, e As EventArgs) Handles TimerDraw.Tick
        Me.Invalidate()
    End Sub
    Private Sub Form1_Leave(sender As Object, e As EventArgs) Handles Me.Leave

    End Sub
    Private Sub TimerShots_Tick(sender As Object, e As EventArgs) Handles TimerShots.Tick
        'Make guns referable by names ex. FrontGun
        If Ship.guns(0).ShotList.Count > 0 Then
            'Proccess Ammo Movement and Life span
            ' do NOT Draw here
            'only change Positions
            For Each projectile As AmmoProjectile In Ship.guns(0).AmmoList
                projectile.DrawProjectile()
            Next
        End If
    End Sub
End Class
