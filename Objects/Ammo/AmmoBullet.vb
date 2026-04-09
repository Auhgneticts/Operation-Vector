Public Class AmmoBullet
    Inherits Ammo
    Public Overrides Sub DrawBounds(g As Graphics)
        g.DrawRectangle(pen, Rectangle)
    End Sub
    Public Overrides Sub DrawImage(g As Graphics)
        g.DrawImage(gameBitmaps("bullet"), Rectangle)
    End Sub
    Public Overrides Sub Move()
        X += xSpeed
    End Sub
End Class