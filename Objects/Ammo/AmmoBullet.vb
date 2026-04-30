Public Class AmmoBullet
    Inherits Ammo
    Public Overrides Sub DrawImage(g As Graphics)
        g.DrawImage(gameBitmaps("Bullet"), Rectangle)
    End Sub
End Class