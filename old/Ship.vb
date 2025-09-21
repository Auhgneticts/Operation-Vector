Public Class Ship
    Inherits BaseObject
    Friend shields As New List(Of Shield)
    Friend guns As New List(Of GunProjectile)
    Friend cargo As New List(Of Collectable)
    Public Money As Integer
    Public Property Location As PointF
        Get
            Return locationValueF
        End Get
        Set(value As PointF)
            value.X -= ((sizeF.Width / 2) * scale)
            value.Y -= ((sizeF.Height / 2) * scale)
            locationValueF = value
        End Set
    End Property
    ReadOnly Property X As Integer
        Get
            Return locationValueF.X
        End Get
    End Property
    ReadOnly Property Y As Integer
        Get
            Return locationValueF.Y
        End Get
    End Property
    Public Sub DrawShip(ByVal graphics As Graphics, point As PointF) 'Get Rectangle???
        '                                                 Test SizeF * Value works???
        graphics.DrawImage(bitmapValue, New RectangleF(point, sizeF))
    End Sub
    Public Sub New()
        'remove parameters which get added by creator!!!
        'TEST VALUES'
        bitmapValue = New Bitmap("C:\Users\Bluemech\Documents\Game Source FIles\WinGame\ship.png")

        scale = 4
        sizeF = New SizeF(16 * scale, 16 * scale)

        'create and load Shields
        Dim shipShield As New Shield
        Dim shipActiveShield As New ActiveShield
        shields.Add(shipActiveShield)
        shields.Add(shipShield)

        'create and load Guns
        Dim mainGun As New GunProjectile
        guns.Add(mainGun)
        'FIX THIS MESS
        guns(0).AddAmmo(10)
        'Add Guns and all Collectable objects to cargo list 
        cargo.AddRange(guns)

    End Sub
End Class
