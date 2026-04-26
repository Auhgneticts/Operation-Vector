Public Class PowerBullet
    Inherits Collectable
    Private ammo As New List(Of Ammo)
    Friend ammoType As AmmoFactory.AmmoType

    Public ReadOnly Property GetAmmo
        Get
            Return ammo
        End Get
    End Property
    Public Overrides Sub DrawBounds(g As Graphics)
        MyBase.DrawBounds(g)
    End Sub
    Public Overrides Sub DrawImage(g As Graphics)
        g.DrawImage(gameBitmaps(MyBase.imageName), New RectangleF(MyBase.Location, MyBase.Size))
    End Sub
    Public Sub New(type As AmmoFactory.AmmoType, ammoAmount As Integer)
        'Number of rounds to refill
        ammoType = type
        ammo = GetAmmoList(AmmoFactory.AmmoType.Bullet, ammoAmount)
    End Sub
End Class
