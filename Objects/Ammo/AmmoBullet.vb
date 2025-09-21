Public Class AmmoBullet
    Inherits Ammo
    Public Overrides Sub DrawPolly(g As Graphics)
        g.FillRectangle(New SolidBrush(pen.Color), Rectangle)
    End Sub
    Public Overrides Sub DrawImage(g As Graphics)
        g.DrawImage(gameBitmaps("bullet"), Rectangle)
    End Sub
    Public Overrides Sub Move()
        X += xSpeed
    End Sub
End Class